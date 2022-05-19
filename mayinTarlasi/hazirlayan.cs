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
    public partial class hazirlayan : Form
    {
        Font font;
        public hazirlayan()
        {
            InitializeComponent();
        }

        private void hazirlayan_Load(object sender, EventArgs e)
        {
            font = new Font("04b", 25, FontStyle.Bold);
            label1.Text = "  Hazirlayan \n Batuhan KOL \n 202013171044";
            label1.Font = font;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
