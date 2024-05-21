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

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] Konyalı Saat Tetiği Verildi. Bekleniyor... !");

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Add("[+] ErSaat Tetiği Verildi. Bekleniyor... !");

        }
    }
}