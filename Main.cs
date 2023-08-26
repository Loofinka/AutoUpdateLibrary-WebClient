using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace AULib
{
    public class Main
    {
        public static string lastUpdateLink;
        public static string applicationFolder;
        public static string applicationName;

        public static void UpdateCheck(string link, string version)
        {
            using(WebClient client = new WebClient())
            {
                Link1:
                if(Internet.IsAvailable())
                {
                    string readversion = client.DownloadString(link);

                    if (version == readversion)
                    {
                        
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Your version outdate! Current Version : " + version + " | New Version : " + readversion, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        if(result == DialogResult.Retry)
                        {
                            goto Link1;
                        }
                        else
                        {
                            if(result == DialogResult.Ignore)
                            {
                                DownloadLastUpdate();
                            }
                        }
                    }
                }
                else
                {
                    Internet.isNotAvailable();
                }
            }
        }
        private static void DownloadLastUpdate()
        {
            Download(lastUpdateLink, applicationFolder, applicationName);
        }

        public static void Download(string link, string path, string name)
        {
            using(WebClient client = new WebClient()) 
            {
                if (Internet.IsAvailable())
                {
                    client.DownloadFileAsync(new Uri(link), path + name);
                }
                else
                {
                    Internet.isNotAvailable();
                }
            }
        }
    }
}