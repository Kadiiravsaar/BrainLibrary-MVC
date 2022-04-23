using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
    public class AyarlarController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Ayarlar()
        {
            var query = db.Adminler.ToList();
            return View(query);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(Adminler a)
        {
            var query = db.Adminler.Add(a);
            db.SaveChanges();
            return RedirectToAction("Ayarlar");
        }
        public ActionResult AdminSil(int id)
        {
            var query = db.Adminler.Find(id);
            db.Adminler.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Ayarlar");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var query = db.Adminler.Find(id);
            return View("AdminGuncelle", query);

            
        }
        [HttpPost]
        public ActionResult AdminGuncelle(Adminler a)
        {
            var query = db.Adminler.Find(a.ID);
            query.Kullanici = a.Kullanici;
            query.Sifre = a.Sifre;
            query.Yetki = a.Yetki;
            db.SaveChanges();
            return RedirectToAction("Ayarlar");

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("AdmLgn", "AdminLogin");
        }
    }
}