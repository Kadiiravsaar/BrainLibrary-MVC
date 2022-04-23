using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
    public class MesajlarController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        
        // GET: Mesajlar
        public ActionResult Index()
        {
            var uye = (string)Session["Mail"].ToString();
            var query = db.Mesajlar.Where(x => x.Alıcı == uye.ToString()).ToList();
            return View(query);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var uye = (string)Session["Mail"].ToString();
            m.Gonderen = uye.ToString();
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Mesajlar.Add(m);
            db.SaveChanges();
            return RedirectToAction("Giden", "Mesajlar");

        }
        public ActionResult Giden()
        {
            var uye = (string)Session["Mail"].ToString();
            var query = db.Mesajlar.Where(x => x.Gonderen == uye.ToString()).ToList();
            return View(query);

        }
        public PartialViewResult Partial1()
        {
            var uye = (string)Session["Mail"].ToString();
            var gelensay = db.Mesajlar.Where(x => x.Alıcı == uye).Count();
            ViewBag.d1 = gelensay;
            var gidensay = db.Mesajlar.Where(x => x.Gonderen == uye).Count();
            ViewBag.d2 = gidensay;
            return PartialView();
        }
        [HttpGet]
        public ActionResult MesajGoruntu()
        {
            var uye = (string)Session["Mail"].ToString();
            var mesajlist = db.Mesajlar.Where(x => x.Alıcı == uye).ToList();
            return View(mesajlist);

        }
        [HttpGet]
        public ActionResult MesajGoruntu2()
        {
            var uye = (string)Session["Mail"].ToString();
            var mesajlist = db.Mesajlar.Where(x => x.Gonderen == uye).ToList();
            return View(mesajlist);

        }

    }
}