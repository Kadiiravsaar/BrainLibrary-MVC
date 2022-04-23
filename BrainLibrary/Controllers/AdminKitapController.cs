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
    public class AdminKitapController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Kitap(string f , int sayfa = 1)
        {
            var query = from k in db.Kitaplar select k;
            if (!string.IsNullOrEmpty(f))
            {
                query = query.Where(m => m.Ad.Contains(f));
            }

            //var query = db.Kitaplar.ToList();
            return View(query.ToList().ToPagedList(sayfa, 6));
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> category1 = (from i in db.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();

            List<SelectListItem> writer1 = (from i in db.Yazarlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' +i.Soyad,
                                               Value = i.ID.ToString()
                                           }).ToList();

            ViewBag.ctgry1 = category1;
            ViewBag.wrtr1 = writer1;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Kitaplar kitap)
        {
            var ctg = db.Kategoriler.Where(x => x.ID == kitap.Kategoriler.ID).FirstOrDefault();
            var wrt = db.Yazarlar.Where(y => y.ID == kitap.Yazarlar.ID).FirstOrDefault();
            kitap.Kategoriler = ctg;
            kitap.Yazarlar = wrt;
            db.Kitaplar.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("Kitap");
        }

        public ActionResult KitapSil(int id)
        {
            var query = db.Kitaplar.Find(id);
            db.Kitaplar.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Kitap");
        }

        public ActionResult KitapGetir(int id)
        {
            var query = db.Kitaplar.Find(id);

            List<SelectListItem> category1 = (from i in db.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();

            List<SelectListItem> writer1 = (from i in db.Yazarlar.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Ad + ' ' + i.Soyad,
                                                Value = i.ID.ToString()
                                            }).ToList();

            ViewBag.ctgry1 = category1;
            ViewBag.wrtr1 = writer1;

            return View("KitapGetir", query);
        }
        public ActionResult KitapGuncelle(Kitaplar g)
        {
            var query = db.Kitaplar.Find(g.ID);
            query.Ad = g.Ad;
            query.BasimYil = g.BasimYil;
            query.Sayfa = g.Sayfa;
            query.YayinEvi = g.YayinEvi;
            query.Durum =true;
            var ctg = db.Kategoriler.Where(k => k.ID == g.Kategoriler.ID).FirstOrDefault();
            var wrt = db.Yazarlar.Where(y => y.ID == g.Yazarlar.ID).FirstOrDefault();
            query.Kategoriler = ctg;
            query.Yazarlar = wrt;
            db.SaveChanges();
            return RedirectToAction("Kitap");
        }

    }
}