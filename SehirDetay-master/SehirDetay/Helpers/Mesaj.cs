using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SehirDetay.Helpers
{
    public class Mesaj
    {
        public int HataKodu { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Link { get; set; }
        public HataSeviyesi HataSeviyesi { get; set; }

    }

    public enum HataSeviyesi
    {
        BuyukHata,
        Kritik,
        Bilgi,
    }
}