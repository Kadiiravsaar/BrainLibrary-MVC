using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainLibrary.Models.Entity;
using PagedList;
using PagedList.Mvc;



namespace BrainLibrary.Controllers
{
    public class AdminYazarController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Yazar(int sayfa = 1)
        {
            var query = db.Yazarlar.ToList().ToPagedList(sayfa, 6);
            return View(query);
        }

        [HttpGet]
        public ActionResult YazarEkle( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(Yazarlar yzr)
        {
            db.Yazarlar.Add(yzr);
            db.SaveChanges();
            return RedirectToAction("Yazar");
        }
        public ActionResult YazarSil(int id)
        {
            var query = db.Yazarlar.Find(id);
            db.Yazarlar.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Yazar");
        }

        public ActionResult YazarGetir(int id)
        {
            var query = db.Yazarlar.Find(id);
            return View("YazarGetir", query);
        }
        public ActionResult YazarGuncelle(Yazarlar y)
        {
            var query = db.Yazarlar.Find(y.ID);
            query.Ad = y.Ad;
            query.Soyad = y.Soyad;
            query.Detay = y.Detay;
            db.SaveChanges();
            return RedirectToAction("Yazar");
        }
        public ActionResult YazarKitap(int id)
        {
            var yzr = db.Kitaplar.Where(x => x.Yazar == id).ToList();

            return View(yzr);
        }

    }
}