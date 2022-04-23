using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainLibrary.Models.Entity;


namespace BrainLibrary.Controllers
{
    public class AdminOduncController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
       
        public ActionResult Odunc()
        {
            var query = db.Hareketler.Where(x => x.IslemDurum == false).ToList();
            return View(query);
        }
        [HttpGet]
        public ActionResult Oduncver()
        {
            List<SelectListItem> uyead = (from i in db.Uyeler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Ad + " " + i.Soyad,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.ua = uyead;

            List<SelectListItem> ktp = (from i in db.Kitaplar.Where(y => y.Durum == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Ad,
                                            Value = i.ID.ToString()
                                        }).ToList();

            ViewBag.ktpad = ktp;

            List<SelectListItem> pers = (from i in db.Personeller.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.Personel,
                                             Value = i.ID.ToString()
                                         }).ToList();

            ViewBag.persad = pers;
            return View();
        }
        [HttpPost]
        public ActionResult Oduncver(Hareketler hareket)
        {
            var uyead1 = db.Uyeler.Where(x => x.ID == hareket.Uyeler.ID).FirstOrDefault();
            var ktp1 = db.Kitaplar.Where(x => x.ID == hareket.Kitaplar.ID).FirstOrDefault();
            var persad1 = db.Personeller.Where(x => x.ID == hareket.Personeller.ID).FirstOrDefault();
            hareket.Uyeler = uyead1;
            hareket.Kitaplar = ktp1;
            hareket.Personeller = persad1;
            db.Hareketler.Add(hareket);
            db.SaveChanges();
            return RedirectToAction("Odunc");
        }
        public ActionResult Odunciade(Hareketler y)
        {
            var query = db.Hareketler.Find(y.ID);
            DateTime d1 = DateTime.Parse(query.IadeTarih.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.deger = d3.TotalDays;

            return View("Odunciade", query);
        }
        public ActionResult OduncGuncelle(Hareketler hrk)
        {
            var query = db.Hareketler.Find(hrk.ID);
            query.UyeGetirTarih = hrk.UyeGetirTarih;
            query.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Odunc");
        }

    }

}