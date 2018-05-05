using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SehirDetay.Helpers
{
    public class SessionClass
    {

        public int KullaniciId { get; set; }
        public string Eposta { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public List<int> Roller { get; set; }
    }
}