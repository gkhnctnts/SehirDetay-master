using SehirDetay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SehirDetay.Controllers
{
    public class KayitOlController : Controller
    {
        private SehirDetayEntities db = new SehirDetayEntities();


        // GET: KayitOl
        public ActionResult Index()
        {
            var sehirler = db.Sehir.ToList();
            sehirler.Insert(0, new Sehir { Id = 0, SehirAd = "Şehir Seçiniz" });

            ViewBag.Sehirler = sehirler;

            ViewBag.Ilceler = new List<SelectListItem> { new SelectListItem { Text = "İlçe Seçiniz", Value = "-1" } };

            List<SelectListItem> cinsiyet = new List<SelectListItem>();
            cinsiyet.Add(new SelectListItem { Text = "Belirtilmemiş", Value = "null" });
            cinsiyet.Add(new SelectListItem { Text = "Erkek", Value = "true" });
            cinsiyet.Add(new SelectListItem { Text = "Kadın", Value = "false" });

            ViewBag.Cinsiyet = cinsiyet;

           


            return View();
        }


         
        public int EpostaKontrol()
        {
            var eposta = Request["eposta"];

            if (Regex.IsMatch(eposta, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                if (db.Kullanici.Where(x => x.Eposta == eposta).Count() == 0)
                    return 2; // uygun
                else
                    return 1; // uygun degil
            }
            else
            {
                return 0; //eposta hatali
            }
 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Eposta,Ad,Soyad,Cinsiyet,DogumTarihi,CepTelefonu,Sifre,SehirId,IlceId")]Kullanici k)
        {
            if (ModelState.IsValid)
            {
                k.Aktif = false;
                k.AktivasyonKodu = Guid.NewGuid().ToString();

                k.Sifre = FormsAuthentication.HashPasswordForStoringInConfigFile(k.Sifre, "sha1");

                db.Kullanici.Add(k);
                db.SaveChanges();   
                MailMessage message = new MailMessage("kayit@sehirdetay.com",        k.Eposta,       "Sehir Detay Aktivasyon", "Aktivasyon kodu:" + k.AktivasyonKodu + "<br><a href='http://" + Request.Url.Host + ":" + Request.Url.Port + "/Kullanici/Aktivasyon?kod=" + k.AktivasyonKodu + "'>Aktivasyon yapmak için tıklayınız.</a>");

                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("localhost");
                client.Send(message);
                
                return RedirectToAction("Index");
            }


            var sehirler = db.Sehir.ToList();
            sehirler.Insert(0, new Sehir { Id = 0, SehirAd = "Şehir Seçiniz" });

            ViewBag.Sehirler = sehirler;

            ViewBag.Ilceler = new List<SelectListItem> { new SelectListItem { Text = "İlçe Seçiniz", Value = "-1" } };

            List<SelectListItem> cinsiyet = new List<SelectListItem>();
            cinsiyet.Add(new SelectListItem { Text = "Belirtilmemiş", Value = "null" });
            cinsiyet.Add(new SelectListItem { Text = "Erkek", Value = "true" });
            cinsiyet.Add(new SelectListItem { Text = "Kadın", Value = "false" });

            ViewBag.Cinsiyet = cinsiyet;


            return View(k);
        }


        public string Ilceler(int id)
        {
            if (id < 1)
                return "<option value =\"-1\">İlçe Seçiniz</option>";

            string sonuc = "";
            foreach (var item in db.Ilce.Where(x => x.SehirId == id))
            {
                sonuc += "<option value=\"" + item.Id.ToString() + "\">" + item.IlceAd + "</option>";
            }
            return sonuc;
        }

    }
}