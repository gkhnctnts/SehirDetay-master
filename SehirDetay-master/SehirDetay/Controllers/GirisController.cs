using SehirDetay.Helpers;
using SehirDetay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SehirDetay.Controllers
{
    public class GirisController : Controller
    {
        SehirDetayEntities db = new SehirDetayEntities();


        // GET: Giris
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Kullanici k)
        {
            

            k.Sifre = FormsAuthentication.HashPasswordForStoringInConfigFile(k.Sifre, "sha1");

            var dbKullanici = db.Kullanici.SingleOrDefault(x => x.Eposta == k.Eposta && x.Sifre == k.Sifre);
            if (dbKullanici != null && dbKullanici.Id > 0)
            {

                if (dbKullanici.Aktif)
                {
                    //Session["e-posta"] = dbKullanici.Eposta;
                    //Session["ad-soyad"] = dbKullanici.Ad + " " + dbKullanici.Soyad;

                    SessionClass sc = new SessionClass();
                    sc.Ad = dbKullanici.Ad;
                    sc.Soyad = dbKullanici.Soyad;
                    sc.Eposta = dbKullanici.Eposta;
                    sc.KullaniciId = dbKullanici.Id;
                    sc.Roller = new List<int>();

                   var roller= db.KullaniciRol.Where(x => x.KullaniciId == sc.KullaniciId).ToList();

                    foreach (var r in roller)
                    {
                        sc.Roller.Add(r.RolId);
                    }

                    Session["sc"] = sc;


                    return RedirectToAction("Index", "Anasayfa");

                }
                else
                    return RedirectToAction("Aktivasyon", "Giris");

            }
            return View();
        }


        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kayit(Kullanici k)
        {
            if (ModelState.IsValid)
            {


                k.Aktif = false;
                k.AktivasyonKodu = Guid.NewGuid().ToString();

                k.Sifre = FormsAuthentication.HashPasswordForStoringInConfigFile(k.Sifre, "sha1");


                db.Kullanici.Add(k);
                db.SaveChanges();

                MailMessage message = new MailMessage("kayit@sehirdetay.com",
        k.Eposta,
       "Sehir Detay Aktivasyon", "Aktivasyon kodu:" + k.AktivasyonKodu + "<br><a href='http://" + Request.Url.Host + ":" + Request.Url.Port + "/Kullanici/Aktivasyon?kod=" + k.AktivasyonKodu + "'>Aktivasyon yapmak için tıklayınız.</a>");

                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("localhost");
                client.Send(message);

                return RedirectToAction("Index");
            }
            return View(k);
        }


        public ActionResult Aktivasyon()
        {
            ViewBag.HataMesaji = "";

            ViewBag.Kod = "";

            if (Request["kod"] != null)
                ViewBag.Kod = Request["kod"].ToString();


            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aktivasyon(string aktivasyonkodu)
        {

            Guid gecerli;

            if (Guid.TryParse(aktivasyonkodu, out gecerli))
            {
                var dbKullanici = db.Kullanici.SingleOrDefault(x => x.AktivasyonKodu == aktivasyonkodu && x.Aktif == false);

                if (dbKullanici != null && dbKullanici.Id > 0)
                {

                    dbKullanici.Aktif = true;
                    dbKullanici.AktivasyonKodu = "0";
                    db.Entry(dbKullanici).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index", "Anasayfa");

                }
                else
                    ViewBag.HataMesaji = "Aktivasyon kodu geçersiz";

            }
            else
                ViewBag.HataMesaji = "Aktivasyon kodu geçersiz";



            return View();
        }



    }
}