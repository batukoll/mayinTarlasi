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

namespace mayinTarlasi
{
    public partial class gameOver : Form
    {
        Font font;
        public gameOver()
        {
            InitializeComponent();
        }
        public string value = "";
        private void gameOver_Load(object sender, EventArgs e)
        {
            font = new Font("04b", 12, FontStyle.Bold);
            button1.Font = font;
            button2.Font = font;
            label1.Font = new Font("04b", 22, FontStyle.Bold);
            ControlBox = false;

            if (value == "Kazandın kolay")
            {
                label1.Text = "Kazandin.";
            }
            else if (value == "Kazandın orta")
            {
                label1.Text = "Kazandin.";
            }
            else if (value == "Kazandın zor")
            {
                label1.Text = "Kazandin.";
            }
            else if (value == "Kaybettin kolay")
            {
                label1.Text = "Kaybettin.";
            }
            else if (value == "Kaybettin orta")
            {
                label1.Text = "Kaybettin.";
            }
            else if (value == "Kaybettin zor")
            {
                label1.Text = "Kaybettin.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(value == "Kazandın kolay"|| value == "Kaybettin kolay")
            {
                kolayHaritaVarMi();
                kolayHarita newKolayHarita = new kolayHarita();
                newKolayHarita.Show();
                anaMenuVarMi();
                this.Close();
            }
            else if (value == "Kazandın orta" || value == "Kaybettin orta")
            {
                ortaHaritaVarMi();
                ortaHarita newOrtaHarita = new ortaHarita();
                newOrtaHarita.Show();
                anaMenuVarMi();
                this.Close();
            }
            else if (value == "Kazandın zor" || value == "Kaybettin zor")
            {
                zorHaritaVarMi();
                zorHarita newZorHarita = new zorHarita();
                newZorHarita.Show();
                anaMenuVarMi();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (value == "Kazandın kolay" || value == "Kaybettin kolay")
            {
                kolayHaritaVarMi();
                anaMenu newAnaMenu = new anaMenu();
                newAnaMenu.Show();
                anaMenuVarMi();
                this.Close();
            }
            else if (value == "Kazandın orta" || value == "Kaybettin orta")
            {
                ortaHaritaVarMi();
                anaMenu newAnaMenu = new anaMenu();
                newAnaMenu.Show();
                anaMenuVarMi();
                this.Close();
            }
            else if (value == "Kazandın zor" || value == "Kaybettin zor")
            {
                zorHaritaVarMi();
                anaMenu newAnaMenu = new anaMenu();
                newAnaMenu.Show();
                anaMenuVarMi();
                this.Close();
            }
        }
        private void kolayHaritaVarMi()
        {
            kolayHarita f = new kolayHarita();
            foreach (Form _f in Application.OpenForms)
            {
                if (_f.Name == "kolayHarita")
                    f = (kolayHarita)_f;
            }
            f.Close();
        }
        private void ortaHaritaVarMi()
        {
            ortaHarita f = new ortaHarita();
            foreach (Form _f in Application.OpenForms)
            {
                if (_f.Name == "ortaHarita")
                    f = (ortaHarita)_f;
            }
            f.Close();   
        }
        private void zorHaritaVarMi()
        {
                zorHarita f = new zorHarita();
                foreach (Form _f in Application.OpenForms)
                {
                    if (_f.Name == "zorHarita")
                        f = (zorHarita)_f;
                }

                f.Close();
        }
        private void anaMenuVarMi()
        {
            anaMenu f = new anaMenu();
            foreach (Form _f in Application.OpenForms)
            {
                if (_f.Name == "anaMenu")
                    f = (anaMenu)_f;
            }

            f.Hide();
        }

        private void gameOver_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
