//202013171044 Batuhan KOL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

 namespace mayinTarlasi
{
    public class mayin
    {
        Point konum; //Mayının konumu
        bool dolu;  //Kutu doluluğu için
        bool tiklandi;
        public mayin(Point konum) // Constructor
        {
            dolu = false;
            this.konum = konum;
        }
        public Point konumAl //Mayının konumunu almak için
        { 
            get { return konum; }
        }
        public bool mayinKontrol //Mayın kontrolü yapmak için
        {
            get { return dolu; }
            set { dolu = value; }
        }
        public bool bakildi //Kutuya tıklanıldı mı
        {
            get { return tiklandi; }
            set { tiklandi = value; }
        }
    }
}
