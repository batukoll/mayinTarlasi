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
    public partial class kolayHarita : Form
    {
        int enabledButtonSayisi = 0;
        public kolayHarita()
        {
            enabledButtonSayisi = 0;
            InitializeComponent();
        }
        mayinTarlasi mayinTarlasi;
        Image mayinResmi = Image.FromFile(@"30x30.png");
        List<mayin> mayinlarimiz;

        private void kolayHarita_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
            mayinTarlasi = new mayinTarlasi(new Size(900, 900), 10); // Büyüklük ve mayın sayısı belirledik
            panel1.Size = mayinTarlasi.buyuklugu;
            mayinEkle();
        }
        public void mayinEkle()
        {
            for (int satir = 0; satir < panel1.Width; satir += 30)
            {
                for (int sutun = 0; sutun < panel1.Height; sutun += 30)
                {
                    buttonEkle(new Point(satir, sutun));
                }
            }
        }
        public void buttonEkle(Point konum)
        {
            Button btn = new Button();
            btn.Name = +konum.X + "" + konum.Y;
            btn.Size = new Size(30, 30);
            btn.Location = konum;
            btn.BackColor = Color.White;
            btn.Click += btn_Click;
            panel1.Controls.Add(btn);
        }

        public void btn_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            mayin myn = mayinTarlasi.mayinAl(btn.Location);
            mayinlarimiz = new List<mayin>();
            if (myn.mayinKontrol)
            {
                mayinlariGoster();
                OyunBitti("Kaybettin kolay");
            }
            else if (enabledButtonSayisi < 890)
            {
                int s = etraftakiMayinlar(myn);
                if (s == 0)
                {
                    mayinlarimiz.Add(myn);
                    for (int i = 0; i < mayinlarimiz.Count; i++)
                    {
                        mayin item = mayinlarimiz[i];
                        if (item != null)
                        {
                            if (item.bakildi == false && item.mayinKontrol == false)
                            {
                                Button btnx = (Button)panel1.Controls.Find(item.konumAl.X + "" + item.konumAl.Y, false)[0];
                                if (etraftakiMayinlar(mayinlarimiz[i]) == 0)
                                {
                                    btnx.Enabled = false;
                                    btnx.BackColor = Color.LightGray;
                                    enabledButtonSayisi++;
                                    cevreEkle(item);
                                }
                                else
                                {
                                    btnx.Text = etraftakiMayinlar(item).ToString();
                                    btnx.Font = new Font("Tahoma", 12, FontStyle.Bold);
                                    btnx.Enabled = false;
                                    btnx.BackColor = Color.LightGray;
                                    enabledButtonSayisi++;
                                }
                                item.bakildi = true;
                                if (enabledButtonSayisi >= 890)
                                {

                                    mayinlariGoster();
                                    OyunBitti("Kazandın kolay");
                                }
                            }
                        }
                    }
                }
                else
                {
                    btn.Text = s.ToString();
                    btn.Font = new Font("Tahoma", 12, FontStyle.Bold);
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGray;
                    enabledButtonSayisi++;
                    if (enabledButtonSayisi >= 890)
                    {

                        mayinlariGoster();
                        OyunBitti("Kazandın kolay");
                    }
                }
            } 
        }
        public void OyunBitti(string value)
        {
            if(value == "Kazandın kolay")
            {
                gameOver gameOver = new gameOver();
                gameOver.value = "Kazandın kolay";
                gameOver.ShowDialog();
            }
            else if(value == "Kaybettin kolay"){
                gameOver gameOver = new gameOver();
                gameOver.value = "Kaybettin kolay";
                gameOver.ShowDialog();
            }
            
        }
        public int etraftakiMayinlar(mayin m)
        {
            int sayi = 0;
            if (m.konumAl.X > 0 && m.konumAl.Y > 0)
            {
                if (mayinTarlasi.mayinAl(new Point(m.konumAl.X - 30, m.konumAl.Y - 30)).mayinKontrol)
                {
                    sayi++;
                }
            }
            if (m.konumAl.X > 0)
            {
                if (mayinTarlasi.mayinAl(new Point(m.konumAl.X - 30, m.konumAl.Y)).mayinKontrol)
                {
                    sayi++;
                }
            }
            if (m.konumAl.X > 0 && m.konumAl.Y < panel1.Height - 30)
            {
                if (mayinTarlasi.mayinAl(new Point(m.konumAl.X - 30, m.konumAl.Y + 30)).mayinKontrol)
                {
                    sayi++;
                }
            }
            if (m.konumAl.Y > 0)
            {
                if (mayinTarlasi.mayinAl(new Point(m.konumAl.X, m.konumAl.Y - 30)).mayinKontrol)
                {
                    sayi++;
                }
            }
            if (m.konumAl.Y < panel1.Height - 30)
            {
                if (mayinTarlasi.mayinAl(new Point(m.konumAl.X, m.konumAl.Y + 30)).mayinKontrol)
                {
                    sayi++;
                }
            }
            if (m.konumAl.X < panel1.Width - 30 && m.konumAl.Y > 0)
            {
                if (mayinTarlasi.mayinAl(new Point(m.konumAl.X + 30, m.konumAl.Y - 30)).mayinKontrol)
                {
                    sayi++;
                }
            }
            if (m.konumAl.X < panel1.Width - 30)
            {
                if (mayinTarlasi.mayinAl(new Point(m.konumAl.X + 30, m.konumAl.Y)).mayinKontrol)
                {
                    sayi++;
                }
            }
            if (m.konumAl.Y < panel1.Height - 30 && m.konumAl.X < panel1.Width - 30)
            {
                if (mayinTarlasi.mayinAl(new Point(m.konumAl.X + 30, m.konumAl.Y + 30)).mayinKontrol)
                {
                    sayi++;
                }
            }
            return sayi;
        }
        public void cevreEkle(mayin m)
        {
            bool b1 = false;// bool değişkeni oluşturmamızın sebebi çapraz karelere bakmak için
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            if (m.konumAl.X > 0)
            {
                mayinlarimiz.Add(mayinTarlasi.mayinAl(new Point(m.konumAl.X - 30, m.konumAl.Y)));
                b1 = true;
            }
            if (m.konumAl.X > 0)
            {
                mayinlarimiz.Add(mayinTarlasi.mayinAl(new Point(m.konumAl.X, m.konumAl.Y - 30)));
                b2 = true;
            }
            if (m.konumAl.X > panel1.Width)
            {
                mayinlarimiz.Add(mayinTarlasi.mayinAl(new Point(m.konumAl.X + 30, m.konumAl.Y)));
                b3 = true;
            }
            if (m.konumAl.X < panel1.Height)
            {
                mayinlarimiz.Add(mayinTarlasi.mayinAl(new Point(m.konumAl.X, m.konumAl.Y + 30)));
                b4 = true;
            }
            if (b1 && b2)
            {
                mayinlarimiz.Add(mayinTarlasi.mayinAl(new Point(m.konumAl.X - 30, m.konumAl.Y - 30)));
            }
            if (b1 && b4)
            {
                mayinlarimiz.Add(mayinTarlasi.mayinAl(new Point(m.konumAl.X - 30, m.konumAl.Y + 30)));
            }
            if (b2 && b3)
            {
                mayinlarimiz.Add(mayinTarlasi.mayinAl(new Point(m.konumAl.X + 30, m.konumAl.Y - 30)));
            }
            if (b2 && b4)
            {
                mayinlarimiz.Add(mayinTarlasi.mayinAl(new Point(m.konumAl.X + 30, m.konumAl.Y + 30)));
            }
        }
        public void mayinlariGoster()
        {
            foreach (mayin item in mayinTarlasi.mayinlariYolla)
            {
                if (item.mayinKontrol)
                {
                    Button btn = (Button)panel1.Controls.Find(item.konumAl.X + "" + item.konumAl.Y, false)[0];
                    btn.BackgroundImage = mayinResmi;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void kolayHarita_FormClosing(object sender, FormClosingEventArgs e)
        {
            anaMenu anaMenu = new anaMenu();
            anaMenu.Show();
        }
    }
}
