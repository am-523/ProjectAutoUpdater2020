using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Newtonsoft.Json;

namespace ProjectAutoUpdater
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
           // this.Text = string.Format("Project {0}")

          //  var url = "http://rbsoft.org/updates/AutoUpdaterTest.json";
          //  AutoUpdater.CheckUpdate += AutoUpdaterOnParseUpdateInfoEvent;
          //  AutoUpdater.Start(url);
        }


       

        private void AutoUpdaterOnParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            dynamic json = JsonConvert.DeserializeObject(args.RemoteData);
            args.UpdateInfo = new UpdateInfoEventArgs
            {
                CurrentVersion = json.version,
                ChangelogURL = json.changelog,
                DownloadURL = json.url,
                Mandatory = new Mandatory
                {
                    Value = json.mandatory.value,
                    UpdateMode = json.mandatory.mode,
                    MinimumVersion = json.mandatory.minVersion
                },
                CheckSum = new CheckSum
                {
                    Value = json.checksum.value,
                    HashingAlgorithm = json.checksum.hashingAlgorithm
                }
            };
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            //uncomment below line to see russian version

            //AutoUpdater.CurrentCulture = CultureInfo.CreateSpecificCulture("ru");

            //If you want to open download page when user click on download button uncomment below line.

            //AutoUpdater.OpenDownloadPage = true;

            //Don't want user to select remind later time in AutoUpdater notification window then uncomment 3 lines below so default remind later time will be set to 2 days.

            //AutoUpdater.LetUserSelectRemindLater = false;
            //AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Days;
            //AutoUpdater.RemindLaterAt = 2;

            //Want to handle update logic yourself then uncomment below line.

            //AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;

            //AutoUpdater.Start("http://rbsoft.org/updates/right-click-enhancer.xml");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
          //  AutoUpdater.CheckUpdate += AutoUpdaterOnParseUpdateInfoEvent;
           // AutoUpdater.Start("https://pastebin.com/raw/Jrgi5bm6");
        }
    }
}
