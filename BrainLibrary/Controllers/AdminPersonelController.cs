using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
    public class AdminPersonelController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Personel()
        {
            var query = db.Personeller.ToList();
            return View(query);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personeller prs)
        {
            db.Personeller.Add(prs);
            db.SaveChanges();
            return RedirectToAction("Personel");
        }
        public ActionResult PersonelSil(int id)
        {
            var query = db.Personeller.Find(id);
            db.Personeller.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Personel");
        }

        public ActionResult PersonelGetir(int id)
        {
            var query = db.Personeller.Find(id);
            return View("PersonelGetir", query);
        }
        public ActionResult PersonelGuncelle(Personeller y)
        {
            var query = db.Personeller.Find(y.ID);
            query.Personel = y.Personel;
            db.SaveChanges();
            return RedirectToAction("Personel");
        }
    }
}