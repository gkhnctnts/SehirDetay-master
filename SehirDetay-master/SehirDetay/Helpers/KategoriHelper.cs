using SehirDetay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SehirDetay.Helpers
{
    public class KategoriHelper
    {
        SehirDetayEntities db = new SehirDetayEntities();

        public void KategoriHesapla(int parentId, int lastIndex)
        {
            AltKategoriBul(parentId, lastIndex);
            db.SaveChanges();
        }


        private int AltKategoriBul(int parentId, int lastIndex)
        {
            var kategoriler = db.Kategori.Where(x => x.UstKategoriId == parentId);
            foreach (var kategori in kategoriler)
            {
                lastIndex++;
                kategori.Lft = lastIndex;
                if (db.Kategori.Count(x => x.UstKategoriId == kategori.Id) > 0)
                {
                    lastIndex = AltKategoriBul(kategori.Id, lastIndex);
                }

                lastIndex++;
                kategori.Rgt = lastIndex;
                db.Entry(kategori).State = EntityState.Modified;
            }
            return lastIndex;
        }
    }
}