using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
    [Authorize]
    public class OgrenciPanelController : Controller
    {

        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult OgrenciPanel()
        {
            var UyeMail = (string)Session["Mail"];

            var query = db.Uyeler.FirstOrDefault(y => y.Mail == UyeMail);

            var d1 = db.Uyeler.Where(x => x.Mail == UyeMail)
                .Select(y => y.Ad + " " + y.Soyad).FirstOrDefault();
            ViewBag.d1 = d1;

            var bolum1 = db.Uyeler.Where(x => x.Mail == UyeMail)
                .Select(b => b.Bolum).FirstOrDefault();
            ViewBag.b1 = bolum1;

            var uyeid = db.Uyeler.Where(u => u.Mail == UyeMail).Select(y => y.ID).FirstOrDefault();
            var d2 = db.Hareketler.Where(x => x.Uye == uyeid).Count();
            ViewBag.d2 = d2;

            var d3 = db.Mesajlar.Where(x => x.Alıcı == UyeMail).Count();
            ViewBag.d3 = d3;

            var d4 = db.Mesajlar.Where(x => x.Gonderen == UyeMail).Count();
            ViewBag.d4 = d4;

            return View(query);
        }
        [HttpPost]
        public ActionResult OgrenciPanel2(Uyeler u)
        {
            var Kullanici = (string)Session["Mail"];
            var query = db.Uyeler.FirstOrDefault(x => x.Mail == Kullanici);
            query.Sifre = u.Sifre;
            query.Ad = u.Ad;
            query.KullaniciAdi = u.KullaniciAdi;
            query.Bolum = u.Bolum;
            query.Telefon = u.Telefon;
         
            db.SaveChanges();
            return RedirectToAction("OgrenciPanel");
        }

        public ActionResult Kitaplarim()
        {
            var Kullanici = (string)Session["Mail"];
            var id = db.Uyeler.Where(x => x.Mail == Kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var query = db.Hareketler.Where(x => x.Uye == id).ToList();
            return View(query);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("V_login", "VitrinLoginRegister");
        }

    }
}