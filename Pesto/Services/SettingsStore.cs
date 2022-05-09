using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Services
{
    class SettingsStore
    {
        private readonly string m_rootRegistryPath = string.Join(@"\", new string[] { "Software", System.Windows.Forms.Application.CompanyName, System.Windows.Forms.Application.ProductName });
        private readonly string m_mruRegistryPath = string.Join(@"\", new string[] { "Software", System.Windows.Forms.Application.CompanyName, System.Windows.Forms.Application.ProductName, "MRU" });

        // TODO: Remove after verifying IKVM/FOP usage
        public string FopPath
        {
            get
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(m_rootRegistryPath, false))
                {
                    if (key == null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return key.GetValue("FOP Path", string.Empty) as string;
                    }
                }
            }
            set
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(m_rootRegistryPath))
                {
                    key.SetValue("FOP Path", value);
                }
            }
        }

        public string[] RecentCompetitionPaths
        {
            get
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(m_mruRegistryPath, false))
                {
                    List<string> mruItems = new List<string>();

                    if (key != null)
                    {
                        string mruItem;
                        int i = 0;
                        
                        while (!string.IsNullOrEmpty(mruItem = key.GetValue(i.ToString(), string.Empty) as string))
                        {
                            mruItems.Add(mruItem);

                            i++;
                        }
                    }

                    return mruItems.ToArray();
                }
            }
            set
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(m_mruRegistryPath))
                {
                    // Delete the exiting MRU items
                    foreach (string valueName in key.GetValueNames())
                    {
                        key.DeleteValue(valueName);
                    }

                    // Add new MRU items
                    for (int i = 0; i < value.Length; i++)
                    {
                        key.SetValue(i.ToString(), value[i]);
                    }
                }
            }
        }

        public string GoogleMapsApiKey
        {
            get
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(m_rootRegistryPath, false))
                {
                    if (key == null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return key.GetValue("Google Maps API Key", string.Empty) as string;
                    }
                }
            }
            set
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(m_rootRegistryPath))
                {
                    key.SetValue("Google Maps API Key", value);
                }
            }
        }

        public string BytescoutSpreadsheetRegistrationName
        {
            get
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(m_rootRegistryPath, false))
                {
                    if (key == null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return key.GetValue("Bytescout Spreadsheet Registration Name", string.Empty) as string;
                    }
                }
            }
            set
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(m_rootRegistryPath))
                {
                    key.SetValue("Bytescout Spreadsheet Registration Name", value);
                }
            }
        }

        public string BytescoutSpreadsheetRegistrationKey
        {
            get
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(m_rootRegistryPath, false))
                {
                    if (key == null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return key.GetValue("Bytescout Spreadsheet Registration Key", string.Empty) as string;
                    }
                }
            }
            set
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(m_rootRegistryPath))
                {
                    key.SetValue("Bytescout Spreadsheet Registration Key", value);
                }
            }
        }
    }
}
