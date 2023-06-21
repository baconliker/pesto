using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Services
{
	class FlymasterApi
	{
		public enum LoginResult
		{
			Success,
			InvalidUsernamePassword,
			NetworkError
		}

		private const string m_baseUrl = "https://lt.flymaster.net/";

		private readonly WebClient m_client = new WebClient();

		public FlymasterApi()
		{
		}

		public async Task<LoginResult> Login(string username, string password)
		{
			var data = new System.Collections.Specialized.NameValueCollection();

			data.Add("email", username);
			data.Add("password", password);
			data.Add("mfa", "");

			try
			{
				JObject response = await SendPostRequestAsync("bslogin.php", data, m_client).ConfigureAwait(false);

				if ((int)response["id"] != -1)
				{
					// Retrieve and set the cookie for subsequent requests. The cookie contain the PHP session id which is necessary so that the server recognises that we're logged-in

					string cookie = m_client.ResponseHeaders["Set-Cookie"];

					int semiColonIndex = cookie.IndexOf(';');
					if (semiColonIndex != -1)
					{
						cookie = cookie.Substring(0, semiColonIndex);
					}

					m_client.Headers.Add("Cookie", cookie);

					return LoginResult.Success;
				}
				else
				{
					return LoginResult.InvalidUsernamePassword;
				}
			}
			catch (WebException)
			{
				return LoginResult.NetworkError;
			}
		}

		public async Task<(int rcode, string id, Uri url)> CheckGroupIgcAsync(string groupId, DateTime utcDay)
		{
			var data = new System.Collections.Specialized.NameValueCollection();

			data.Add("groupId", groupId);
			data.Add("date", utcDay.ToString("yyyy-MM-dd"));
			data.Add("onlycheck", "1");

			JObject response = await SendPostRequestAsync("bsRequestGroupIGC.php", data, m_client).ConfigureAwait(false);

			int rcode = (int)response["rcode"];

			return (rcode, response["id"] != null ? (string)response["id"] : string.Empty, rcode == 2 ? new Uri((string)response["url"]) : null);
		}

		public async Task<(int rcode, Uri url)> CheckGroupIgcAsync(string id)
		{
			var data = new System.Collections.Specialized.NameValueCollection();

			data.Add("id", id);

			JObject response = await SendPostRequestAsync("bsRequestGroupIGC.php", data, m_client).ConfigureAwait(false);

			return ((int)response["rcode"], (int)response["rcode"] == 2 ? new Uri((string)response["url"]) : null);
		}

		public async Task<(int rcode, string id, Uri url)> GenerateGroupIgcAsync(string groupId, DateTime utcDay, string deleteId)
		{
			var data = new System.Collections.Specialized.NameValueCollection();

			data.Add("groupId", groupId);
			data.Add("date", utcDay.ToString("yyyy-MM-dd"));
			if (!string.IsNullOrEmpty(deleteId))
			{
				data.Add("delid", deleteId);
			}

			JObject response = await SendPostRequestAsync("bsRequestGroupIGC.php", data, m_client).ConfigureAwait(false);

			return ((int)response["rcode"], (string)response["id"], (int)response["rcode"] == 2 ? new Uri((string)response["url"]) : null);
		}

		public async Task DownloadTracks(string groupId, DateTime utcDay, bool regenerate, string destinationFilePath)
		{
			var data = new System.Collections.Specialized.NameValueCollection();
			Uri downloadUrl = null;

			(int rcode, string id, Uri url) = await CheckGroupIgcAsync(groupId, utcDay).ConfigureAwait(false);

			if (rcode != 2 || regenerate)
			{
				(rcode, id, url) = await GenerateGroupIgcAsync(groupId, utcDay, id).ConfigureAwait(false);

				if (rcode != 2)
				{
					// The file is not available immediately, keep polling until it is
					do
					{
						await Task.Delay(1000).ConfigureAwait(false);

						(rcode, url) = await CheckGroupIgcAsync(id).ConfigureAwait(false);

						if (rcode == 2)
						{
							downloadUrl = url;
						}

					} while (downloadUrl == null);
				}
				else
				{
					// The file is available for immediate download (this is unlikely to happen but perhaps if there is very little track data to process)
					downloadUrl = url;
				}
			}
			else
			{
				// The file has been generated before and is available for download
				downloadUrl = url;
			}

			await m_client.DownloadFileTaskAsync(downloadUrl, destinationFilePath).ConfigureAwait(false);
		}

		private static async Task<JObject> SendPostRequestAsync(string page, System.Collections.Specialized.NameValueCollection data, WebClient client)
		{
			Debug.WriteLine($"Sending request to {m_baseUrl + page}, {FormatRequestData(data)}");

			string response = client.Encoding.GetString(await client.UploadValuesTaskAsync(m_baseUrl + page, data).ConfigureAwait(false));

			Debug.WriteLine($"Received response: {response}");

			using (StringReader reader = new StringReader(response))
			{
				return (JObject)JToken.ReadFrom(new JsonTextReader(reader));
			}
		}

		private static string FormatRequestData(System.Collections.Specialized.NameValueCollection data)
		{
			string formattedData = string.Empty;

			foreach (var key in data.AllKeys)
			{
				if (formattedData.Length > 0)
				{
					formattedData += "; ";
				}

				formattedData += $"{key}: {data[key]}";
			}

			return formattedData;
		}
	}
}
