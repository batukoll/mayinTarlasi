//202013171044 Batuhan KOL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mayinTarlasi
{
    class mayinTarlasi
    {
        Size buyukluk; //Tarlamızın büyüklüğü
        List<mayin> mayinlar;//Mayınların dolacağı yer
        int doluMayinSayisi;
        Random rand = new Random();
       public mayinTarlasi(Size buyukluk, int mayinSayisi) //constructor
        {
            mayinlar = new List<mayin>();
            doluMayinSayisi = mayinSayisi;
            this.buyukluk = buyukluk;
            for (int satir = 0; satir < buyukluk.Width; satir+=30)
            {
                for (int sutun = 0; sutun < buyukluk.Height; sutun+=30)
                {
                    mayin m = new mayin(new Point(satir,sutun)); // Mayın oluşturuldu
                    mayinEkle(m);
                }
            }
            mayinlariDoldur();
        }
        public void mayinEkle(mayin m) // Mayın eklemek için kullanılan fonksiyon
        {
            mayinlar.Add(m);
        }
        private void mayinlariDoldur()
        {
            int sayi = 0;
            while (sayi < doluMayinSayisi)
            {
                int i = rand.Next(0, mayinlar.Count);
                mayin item = mayinlar[i];
                if(item.mayinKontrol == false)
                {
                    item.mayinKontrol = true;
                    sayi++;
                }
            }
        }
        public Size buyuklugu // büyüklüğünü almak için kullanılan değişken
        {
            get { return buyukluk; }
        }
        public mayin mayinAl(Point konum) // Konumuna göre mayın almak için kullanılan fonksiyon
        {
            foreach (mayin item in mayinlar)//Her mayına bakılıp mayınların konumlarını almak için foreach kullanıldı.
            {
                if(item.konumAl == konum)
                {
                    return item;
                }
            }
            return null;
        }
        public List<mayin> mayinlariYolla //Mayınların konumlarını liste şeklinde göndermek için kullanılan fonksiyon
        {
            get { return mayinlar; }
        }
    }
}
