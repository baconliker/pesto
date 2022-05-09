using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Xml;

namespace ColinBaker.Pesto.Services
{
    public class ApplicationUpdater : IDisposable
    {
        public EventHandler<System.Net.DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DownloadComplete;

        private const string m_versionControlFileUri = "https://colinbaker.me.uk/software/pesto/version.xml";

        private System.Net.WebClient m_webClient = new System.Net.WebClient();

        private XmlDocument m_versionDocument = null;
        
        private static readonly Guid m_downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

        #region IDisposable Support

        private bool m_disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_webClient.Dispose();
                }

                m_disposed = true;
            }
        }

        #endregion

        public ApplicationUpdater()
        {
            m_webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(m_webClient_DownloadProgressChanged);
            m_webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(m_webClient_DownloadFileCompleted);
        }

        public bool IsUpdateAvailable()
        {
            if (m_versionDocument == null)
            {
                DownloadVersionDocument();
            }
            
            System.Version availableVersion = System.Version.Parse(m_versionDocument.SelectSingleNode("/Pesto/CurrentVersion/Number").InnerText);
            System.Version installedVersion = System.Version.Parse(System.Windows.Forms.Application.ProductVersion);

            if (availableVersion > installedVersion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetDefaultDownloadFolderPath()
        {
            string downloads;

            int result = SHGetKnownFolderPath(m_downloads, 0, IntPtr.Zero, out downloads);

            if (result == 0)
            {
                return downloads;
            }
            else
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
        }

        public string GetDefaultDownloadFileName()
        {
            if (m_versionDocument == null)
            {
                DownloadVersionDocument();
            }

            Uri downloadUri = GetDownloadUrl();

            return downloadUri.Segments[downloadUri.Segments.Length - 1];
        }

        public void DownloadLatestVersionAsync(string saveFilePath)
        {
            if (m_versionDocument == null)
            {
                DownloadVersionDocument();
            }

            m_webClient.DownloadFileAsync(GetDownloadUrl(), saveFilePath);
        }

        public void CancelAsync()
        {
            m_webClient.CancelAsync();
        }

        protected void OnDownloadProgressChanged(System.Net.DownloadProgressChangedEventArgs e)
        {
            if (DownloadProgressChanged != null)
            {
                DownloadProgressChanged(this, e);
            }
        }

        protected void OnDownloadComplete(System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (DownloadComplete != null)
            {
                DownloadComplete(this, e);
            }
        }

        private void DownloadVersionDocument()
        {
            string xml = m_webClient.DownloadString(m_versionControlFileUri);

            m_versionDocument = new System.Xml.XmlDocument();
            m_versionDocument.LoadXml(xml);
        }

        private Uri GetDownloadUrl()
        {
            return new Uri(m_versionDocument.SelectSingleNode("/Pesto/CurrentVersion/URL").InnerText);
        }

        private void m_webClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            OnDownloadProgressChanged(e);
        }

        private void m_webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            OnDownloadComplete(e);
        }
    }
}
