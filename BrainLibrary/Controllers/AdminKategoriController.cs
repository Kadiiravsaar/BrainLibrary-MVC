using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
   
    public class AdminKategoriController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Kategori()
        {
            var query = db.Kategoriler.Where(x=>x.Durum==true || x.Durum==null).ToList();
            return View(query);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler k)
        {
            db.Kategoriler.Add(k);
            db.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var query = db.Kategoriler.Find(id);
            //db.Kategoriler.Remove(query);
            query.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }
        
        public ActionResult KategoriGetir(int id)
        {
            var query = db.Kategoriler.Find(id);
            return View("KategoriGetir", query);
        }
        public ActionResult KategoriGuncelle(Kategoriler x)
        {
            var query = db.Kategoriler.Find(x.ID);
            query.Ad = x.Ad;
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }

    }
}