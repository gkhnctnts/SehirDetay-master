using SehirDetay.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace SehirDetay.Controllers
{
    public class ExportController : Controller
    {

        SehirDetayEntities db = new SehirDetayEntities();

        // GET: Export
        public ActionResult Index()
        {
            return View();
        }

        public void IcerikExcel()
        {
            var grid = new System.Web.UI.WebControls.GridView();

            grid.DataSource = db.Icerik.ToList();
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=icerik.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
        }


        public void IcerikCsv()
        {
            Response.AddHeader("content-disposition", "attachment;filename=icerik.csv");
            Response.ContentType = "text/csv";
            Response.ContentEncoding = Encoding.UTF8;

            var icerikler = db.Icerik.ToList();

            StringWriter sw = new StringWriter();

            byte[] bom = Encoding.UTF8.GetPreamble();

            Response.BinaryWrite(bom);
            //sw.Write(Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble()));

            if (icerikler.Count > 0)
            {
                var ilkkayit = icerikler[0];

                //PropertyInfo[] props = ilkkayit.GetType().GetProperties();
                //foreach (var col in props)
                //{
                //    sw.Write(col.Name + ",");
                //}


                sw.WriteLine($"\"{nameof(ilkkayit.Baslik)}\";\"{nameof(ilkkayit.Detay)}\";\"{nameof(ilkkayit.AnahtarKelimeler)}\";\"{nameof(ilkkayit.OlusturulmaTarihi)}\"");

                foreach (var icerik in icerikler)
                {
                    sw.WriteLine($"\"{icerik.Baslik}\";\"{icerik.Detay}\";\"{icerik.AnahtarKelimeler}\";\"{icerik.OlusturulmaTarihi}\"");

                }


            }

            Response.Write(sw.ToString());
            Response.End();
        }


        public ActionResult TestBelge()
        {
            return View();
        }

    }
}