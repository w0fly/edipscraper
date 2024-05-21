using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdipScraper
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public Home()
        {
            InitializeComponent();
        }
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] Program Başlatıldı !");
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] Tissot Tetiği Verildi. Bekleniyor... !");

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
            XtraMessageBox.Show("Bu Özellik Şu An Kodlanmadı. Bir Sonraki Güncellemede Kullanılabilir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}