using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
    
    public class VitrinLoginRegisterController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        [HttpGet]
        public ActionResult V_login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult V_login(Uyeler u)
        {
            var query = db.Uyeler.FirstOrDefault(x => x.Mail == u.Mail && x.Sifre == u.Sifre);
            if (query != null)
            {
                FormsAuthentication.SetAuthCookie(query.Mail, false);
                Session["Mail"] = query.Mail.ToString();
                //TempData["Ad"] = query.Ad.ToString();
                //TempData["Soyad"] = query.Soyad.ToString();
                //TempData["KullanıcıAdı"] = query.KullaniciAdi.ToString();
                //TempData["Sifre"] = query.Sifre.ToString();
                //TempData["Bolüm"] = query.Bolum.ToString();
                return RedirectToAction("OgrenciPanel", "OgrenciPanel");
            }
            return View();
        }

        [HttpGet]
        public ActionResult V_register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult V_register(Uyeler kyt)
        {
            if (!ModelState.IsValid)
            {
                return View("V_register");

            }
            db.Uyeler.Add(kyt);
            db.SaveChanges();
            return RedirectToAction("V_login");
        }
    }
}