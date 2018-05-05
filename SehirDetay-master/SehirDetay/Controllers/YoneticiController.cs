using SehirDetay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirDetay.Controllers
{

    public class YoneticiController : Controller
    {
        // GET: Yonetici

        [Yetki(Roller = "1")]
        public ActionResult Index()
        {
            if (Session["sc"] != null)
            {
                var sc = (SessionClass)Session["sc"];
                if (!sc.Roller.Contains(1))
                {
                    Mesaj m = new Mesaj();
                    m.Baslik = "Yetkisiz Erişim";
                    m.Aciklama = "Bu modülü kullanma yetkiniz yok.";
                    m.Link = "http://microsoft.com";
                    m.HataSeviyesi = HataSeviyesi.Kritik;

                    Session["mesaj"] = m;

                    return RedirectToAction("Index", "Mesaj");
                }

            }

            return View();
        }
    }
}