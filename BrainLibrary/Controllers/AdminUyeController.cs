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
    public class AdminUyeController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Uye(int sayfa =1)
        {
            var query = db.Uyeler.ToList().ToPagedList(sayfa,5);
            return View(query);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(Uyeler uye)
        {
            db.Uyeler.Add(uye);
            db.SaveChanges();
            return RedirectToAction("Uye");
        }

        public ActionResult UyeSil(int id)
        {
            var query = db.Uyeler.Find(id);
            db.Uyeler.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Uye");
        }

        public ActionResult UyeGetir(int id)
        {
            var query = db.Uyeler.Find(id);
            return View("UyeGetir", query);
        }
        public ActionResult UyeGuncelle(Uyeler x)
        {
            var query = db.Uyeler.Find(x.ID);
            query.Ad = x.Ad;
            query.Soyad = x.Soyad;
            query.Mail = x.Mail;
            query.KullaniciAdi = x.KullaniciAdi;
            query.Sifre = x.Sifre;
            query.Telefon = x.Telefon;
            query.Bolum = x.Bolum;
            db.SaveChanges();
            return RedirectToAction("Uye");
        }
    }
}