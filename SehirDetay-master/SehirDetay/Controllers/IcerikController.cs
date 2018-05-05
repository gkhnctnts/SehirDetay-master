using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SehirDetay.Models;
using System.IO;
using SehirDetay.Helpers;
using System.Data.Entity.Spatial;

namespace SehirDetay.Controllers
{
    [Yetki(Roller ="1,2")]
    public class IcerikController : Controller
    {
        private SehirDetayEntities db = new SehirDetayEntities();

        // GET: Icerik
        public ActionResult Index()
        {
            var icerik = db.Icerik.Include(i => i.Ilce).Include(i => i.Kategori).Include(i => i.Kullanici).Include(i => i.Sehir);
            return View(icerik.ToList());
        }

        // GET: Icerik/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = db.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            return View(icerik);
        }

        // GET: Icerik/Create
        public ActionResult Create()
        {
            ViewBag.IlceId = new SelectList(db.Ilce, "Id", "IlceAd");
            ViewBag.KategoriId = new SelectList(db.Kategori, "Id", "KategoriAd");
            ViewBag.KullaniciId = new SelectList(db.Kullanici, "Id", "Eposta");
            ViewBag.SehirId = new SelectList(db.Sehir, "Id", "SehirAd");
            return View();
        }

        // POST: Icerik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Baslik,Detay,KategoriId,KullaniciId,OlusturulmaTarihi,GuncellenmeTarihi,AnahtarKelimeler,Aktif,SehirId,IlceId")] Icerik icerik, HttpPostedFileBase dosya)
        {

           

            if (ModelState.IsValid)
            {

                //icerik.Konum = DbGeography.FromText("POINT(41,011366 28,9812603)");
                db.Icerik.Add(icerik);
                db.SaveChanges();

                if (dosya.ContentLength > 0)
                {


                    string dosyaismi =  Util.UrlSeo( Path.GetFileNameWithoutExtension(dosya.FileName)) + "-" + Guid.NewGuid().ToString() + Path.GetExtension(dosya.FileName);


                    if (dosyaismi.Length > 255)
                    {
                        dosyaismi = dosyaismi.Substring( dosyaismi.Length - 255,  255);
                    }

                    dosya.SaveAs(Path.Combine(Server.MapPath("~/Content/Resim/") ,  dosyaismi));

                    Medya m = new Medya();
                    m.Baslik = icerik.Baslik;
                    m.EklemeTarihi = DateTime.Now;
                    m.MedyaTipi = 2 ; //1-video 2-resim 3-dosya
                    m.MedyaUrl = dosyaismi;

                    db.Medya.Add(m);
                    db.SaveChanges();


                    IcerikMedya im = new IcerikMedya();
                    im.IcerikId = icerik.Id;
                    im.MedyaId = m.Id;

                    db.IcerikMedya.Add(im);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.IlceId = new SelectList(db.Ilce, "Id", "IlceAd", icerik.IlceId);
            ViewBag.KategoriId = new SelectList(db.Kategori, "Id", "KategoriAd", icerik.KategoriId);
            ViewBag.KullaniciId = new SelectList(db.Kullanici, "Id", "Eposta", icerik.KullaniciId);
            ViewBag.SehirId = new SelectList(db.Sehir, "Id", "SehirAd", icerik.SehirId);
            return View(icerik);
        }

        // GET: Icerik/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = db.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            ViewBag.IlceId = new SelectList(db.Ilce, "Id", "IlceAd", icerik.IlceId);
            ViewBag.KategoriId = new SelectList(db.Kategori, "Id", "KategoriAd", icerik.KategoriId);
            ViewBag.KullaniciId = new SelectList(db.Kullanici, "Id", "Eposta", icerik.KullaniciId);
            ViewBag.SehirId = new SelectList(db.Sehir, "Id", "SehirAd", icerik.SehirId);
            return View(icerik);
        }

        // POST: Icerik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Detay,KategoriId,KullaniciId,OlusturulmaTarihi,GuncellenmeTarihi,AnahtarKelimeler,Aktif,Konum,SehirId,IlceId")] Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icerik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IlceId = new SelectList(db.Ilce, "Id", "IlceAd", icerik.IlceId);
            ViewBag.KategoriId = new SelectList(db.Kategori, "Id", "KategoriAd", icerik.KategoriId);
            ViewBag.KullaniciId = new SelectList(db.Kullanici, "Id", "Eposta", icerik.KullaniciId);
            ViewBag.SehirId = new SelectList(db.Sehir, "Id", "SehirAd", icerik.SehirId);
            return View(icerik);
        }

        // GET: Icerik/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = db.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            return View(icerik);
        }

        // POST: Icerik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Icerik icerik = db.Icerik.Find(id);
            db.Icerik.Remove(icerik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
