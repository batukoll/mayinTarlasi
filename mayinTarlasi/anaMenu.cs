//202013171044 Batuhan KOL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Imaging;

namespace mayinTarlasi
{
    public partial class anaMenu : Form
    {
        bool soundOnOff;
        SoundPlayer sp;
        Font font;

        public anaMenu()
        {
            InitializeComponent();
            soundOnOff = true;
        }
        private void anaMenu_Load(object sender, EventArgs e)
        {
            font = new Font("04b", 12, FontStyle.Bold);
            button1.Font = font;
            button2.Font = font;
            button3.Font = font;
            sp = new SoundPlayer();
            sp.SoundLocation = @".\Pitanime - Menu Song (OST Punch Club).wav";
            sp.PlayLooping();
        }

        private void anaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {   
            DialogResult sonuc;
            sonuc = MessageBox.Show("Oyundan çıkmak istiyor musunuz?", "Çıkış Ekranı", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (sonuc == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (sonuc == DialogResult.Yes)
            {
                MessageBox.Show("Program Kapatılıyor.", "Yine Bekleriz...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Windows.Forms.Application.ExitThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zorlukMenu form = new zorlukMenu();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult sonuc;
            sonuc = MessageBox.Show("Oyundan çıkmak istiyor musunuz?", "Çıkış Ekranı", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (sonuc == DialogResult.Yes)
            {
                MessageBox.Show("Program Kapatılıyor.", "Yine Bekleriz...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Windows.Forms.Application.ExitThread();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hazirlayan hazirlayan = new hazirlayan();
            hazirlayan.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(soundOnOff == false)
            {
                sp.PlayLooping();
                button4.Image = System.Drawing.Image.FromFile(@".\sound.ico");
                soundOnOff = true;
            }
            else
            {
                sp.Stop();
                button4.Image = System.Drawing.Image.FromFile(@".\mute.ico");
                soundOnOff = false;
            }
        }
    }
}
