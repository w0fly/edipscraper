using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
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
            string latestReleaseUrl = "https://api.github.com/repos/yourusername/yourrepo/releases/latest"; // Replace with your GitHub repo's latest release API URL
            string downloadUrl = "https://octopus360.co/x-project-x/edipscraper/final.exe";
            string tempFilePath = Path.Combine(Path.GetTempPath(), "app_update.exe");

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
                        // Bulunan sürümün indirilebilir URL'sini alın
                        downloadUrl = json["assets"][0]["browser_download_url"].ToString();

                        // Kullanıcıya güncelleme olduğunu bildir
                        DialogResult dialogResult = XtraMessageBox.Show($"Uygulamanın güncel bir sürümü mevcut! Şu anki sürüm: {currentVersion}, Yeni sürüm: {latestVersion}. Güncellemek ister misiniz?", "Güncelleme Bildirimi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dialogResult == DialogResult.Yes)
                        {
                            await DownloadUpdate(downloadUrl, tempFilePath);
                            StartUpdate(tempFilePath);
                        }
                    }
                    else
                    {
                        labelControl1.Text = "Uygulama güncel.";
                    }
                }
                else
                {
                    labelControl1.Text = "Yeni güncelleme bulunamadı.";
                }
            }
        }

        private async Task DownloadUpdate(string downloadUrl, string tempFilePath)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(downloadUrl);

                if (response.IsSuccessStatusCode)
                {
                    using (var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                }
            }
        }

        private void StartUpdate(string tempFilePath)
        {
            // Yeni güncellemeyi başlatmadan önce uygulamayı kapat
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = tempFilePath,
                UseShellExecute = true,
            };

            Process.Start(info);
            Application.Exit();
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
