using DevExpress.XtraSplashScreen;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdipScraper
{
    public partial class SplashScreen1 : SplashScreen
    {
        private Timer timer;
        private const string latestReleaseUrl = "https://api.github.com/repos/w0fly/edipscraper/releases/latest"; // Replace {OWNER} and {REPO} with your GitHub repository's owner and name

        public SplashScreen1()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 2024 - Octopus360";
            CheckForUpdates();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= Timer_Tick;

            this.Hide();
            Home homeForm = new Home();
            homeForm.Show();
        }

        private async void CheckForUpdates()
        {
            string currentVersion = "1.0.0"; // Replace this with your current application version

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("request"); // GitHub API requires a User-Agent header
                HttpResponseMessage response = await client.GetAsync(latestReleaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseBody);
                    string latestVersion = json["tag_name"].ToString();

                    if (currentVersion != latestVersion)
                    {
                        MessageBox.Show($"A new version ({latestVersion}) is available. Please update your application.", "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to check for updates. Please try again later.", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}
