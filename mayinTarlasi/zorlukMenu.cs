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
namespace mayinTarlasi
{
    public partial class zorlukMenu : Form
    {
        Font font;
        bool bilgi = false;
        public zorlukMenu()
        {
            InitializeComponent();
            bilgi = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zorHarita zorHarita = new zorHarita();
            zorHarita.Show();
            bilgi = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ortaHarita ortaHarita = new ortaHarita();
            ortaHarita.Show();
            bilgi = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kolayHarita kolayHarita = new kolayHarita();
            kolayHarita.Show();
            bilgi = true;
            this.Close();
        }

        private void zorlukMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            anaMenu anaMenu = new anaMenu();
            if (!bilgi)
            {
                anaMenu.Show();
            }
        }
        private void zorlukMenu_Load(object sender, EventArgs e)
        {
            font = new Font("04b", 12, FontStyle.Bold);
            button1.Font = font;
            button2.Font = font;
            button3.Font = font;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
