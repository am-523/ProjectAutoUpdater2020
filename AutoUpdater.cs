using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace ProjectAutoUpdater
{
    class AutoUpdater
    {

        class Data
        {
            public decimal version { get; set; }
            public string downloadlink { get; set; }
            public string Message { get; set; }
            public string changelog { get; set; }
            public bool isClose { get; set; }

        }
        static void Close() { Process.GetCurrentProcess().Kill(); }
        static WebClient wb = new WebClient();

        public static decimal CheckUpdate(decimal currentVersion)
        {

            try
            {
                Data myData = new JavaScriptSerializer().Deserialize<Data>(wb.DownloadString("https://pastebin.com/raw/Jrgi5bm6#"));

                if (!myData.isClose)
                {
                    MessageBox.Show(myData.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.GetCurrentProcess().Kill();
                }
                if (myData.version > currentVersion)
                {
                    if (MessageBox.Show(string.Format("New Update Available..!\nOld Version : {0}\nNew Version : {1}\n\nChangelog : {2}", currentVersion, myData.version, myData.changelog), "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        SaveFileDialog opn = new SaveFileDialog { Filter = "exe|*.exe" };
                        if (opn.ShowDialog() == DialogResult.OK)
                        {
                            wb.DownloadFile(myData.downloadlink, opn.FileName);
                        }
                        else
                        {
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can not use this version you have to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Update Error, Please Check You Connection","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();

            }
            
            return currentVersion;
        }

      
    }




}
