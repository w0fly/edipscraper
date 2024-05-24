using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;


namespace EdipScraper
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        private IniFile iniFile;

        public Home()
        {
            InitializeComponent();
            iniFile = new IniFile("config.ini");
            LoadIniFile();
            CheckOrCreateConfig();
        }
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] Program Başlatıldı !");
            txtServer.Enabled = false;
            txtDatabase.Enabled = false;
            txtUid.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] Tissot Tetiği Verildi. Bekleniyor... !");
            listBoxControl1.Items.Add("[+] 7500MS'lik Sleep Uygulanıyor...");
            System.Threading.Thread.Sleep(7500);

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] Saat & Saat Tetiği Verildi. Bekleniyor... !");
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] Konyalı Saat Tetiği Verildi. Bekleniyor... !");
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] ErSaat Tetiği Verildi. Bekleniyor... !");
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text;
            string database = txtDatabase.Text;
            string uid = txtUid.Text;
            string password = txtPassword.Text;
            if (txtServer.Enabled == false)
            {
                txtServer.Enabled = true;
                txtDatabase.Enabled = true;
                txtUid.Enabled = true;
                txtPassword.Enabled = true;
                simpleButton6.Text = "Kaydet";
                SaveIniFile();
            }
            else
            {
                txtServer.Enabled = false;
                txtDatabase.Enabled = false;
                txtUid.Enabled = false;
                txtPassword.Enabled = false;
                simpleButton6.Text = "MySQL Config";

            }
        }
        private void LoadIniFile()
        {
            txtServer.Text = iniFile.Read("MySQL", "Server");
            txtDatabase.Text = iniFile.Read("MySQL", "Database");
            txtUid.Text = iniFile.Read("MySQL", "UID");
            txtPassword.Text = iniFile.Read("MySQL", "Password");
        }

        private void SaveIniFile()
        {
            iniFile.Write("MySQL", "Server", txtServer.Text);
            iniFile.Write("MySQL", "Database", txtDatabase.Text);
            iniFile.Write("MySQL", "UID", txtUid.Text);
            iniFile.Write("MySQL", "Password", txtPassword.Text);
        }
        private void CheckOrCreateConfig()
        {
            if (!File.Exists("config.ini"))
            {
                // config.ini dosyası yoksa MySqlConfig formunu aç
                using (MySqlConfig configForm = new MySqlConfig())
                {
                    if (configForm.ShowDialog() == DialogResult.OK)
                    {
                        // Kullanıcı yeni bilgileri kaydettiğinde yeniden yükle
                        LoadIniFile();
                    }
                    else
                    {
                        MessageBox.Show("Ayarlar yapılmadığı için uygulama kapatılıyor.");
                        Application.Exit();
                    }
                }
            }
        }
    }
}