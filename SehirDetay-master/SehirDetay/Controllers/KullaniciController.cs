using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SehirDetay.Models;

namespace SehirDetay.Controllers
{
    public class KullaniciController : Controller
    {
        private SehirDetayEntities db = new SehirDetayEntities();

        // GET: Kullanici
        public ActionResult Index()
        {
            var kullanici = db.Kullanici;
            return View(kullanici.ToList());
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            ViewBag.IlceId = new SelectList(db.Ilce, "Id", "IlceAd");
            ViewBag.SehirId = new SelectList(db.Sehir, "Id", "SehirAd");
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Eposta,Ad,Soyad,Cinsiyet,DogumTarihi,CepTelefonu,Sifre,SehirId,IlceId,Aktif,AktivasyonKodu")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IlceId = new SelectList(db.Ilce, "Id", "IlceAd", kullanici.IlceId);
            ViewBag.SehirId = new SelectList(db.Sehir, "Id", "SehirAd", kullanici.SehirId);
            return View(kullanici);
        }

        // GET: Kullanici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            ViewBag.IlceId = new SelectList(db.Ilce, "Id", "IlceAd", kullanici.IlceId);
            ViewBag.SehirId = new SelectList(db.Sehir, "Id", "SehirAd", kullanici.SehirId);
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Eposta,Ad,Soyad,Cinsiyet,DogumTarihi,CepTelefonu,Sifre,SehirId,IlceId,Aktif,AktivasyonKodu")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IlceId = new SelectList(db.Ilce, "Id", "IlceAd", kullanici.IlceId);
            ViewBag.SehirId = new SelectList(db.Sehir, "Id", "SehirAd", kullanici.SehirId);
            return View(kullanici);
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }

            kullanici.Aktif = false;
            db.Entry(kullanici).State = EntityState.Modified;
            db.SaveChanges();
              

            return View(kullanici);
        }




        // GET: Kullanici/RolAta/5
        public ActionResult RolAta(int id)
        {
            KullaniciRol krol = new KullaniciRol();
            krol.KullaniciId = id;
            ViewBag.Rol = new SelectList(db.Rol, "Id", "RolAd");
            return View(krol);
        }


        // POST: Kullanici/RolAta/5
        [HttpPost]
        public ActionResult RolAta(KullaniciRol model)
        {

            if (ModelState.IsValid)
            {
                db.KullaniciRol.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rol = new SelectList(db.Rol, "Id", "RolAd");

            return View(model);
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
