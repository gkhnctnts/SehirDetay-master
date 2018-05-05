using SehirDetay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirDetay.Controllers
{
    public class DetayController : Controller
    {
        SehirDetayEntities db = new SehirDetayEntities();


        [Route("Detay/{id}/{baslik}")]
        public ActionResult IcerikDetay(int id)
        {
            return View(db.Icerik.Find(id));
        }
    }
}