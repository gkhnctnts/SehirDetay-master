using SehirDetay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirDetay.Controllers
{
    public class SehirController : Controller
    {
        // GET: Sehir

        SehirDetayEntities db = new SehirDetayEntities();

        public ActionResult Index()
        {
            var sehirler = db.Sehir.ToList();

            return View(sehirler);
        }

        [Route("Sehir/{id}/{baslik}")]
        public ActionResult DetayGoster(int id) {

            return View(db.Icerik.Where(x => x.SehirId == id).ToList() );
        }







    }
}