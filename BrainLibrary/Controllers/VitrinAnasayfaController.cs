using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
   
    public class VitrinAnasayfaController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        
        [HttpGet]
        public ActionResult V_anasayfa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult V_anasayfa(V_Iletisim x)
        {
            db.V_Iletisim.Add(x);
            db.SaveChanges();
            return RedirectToAction("V_anasayfa");
        }
        public ActionResult V_kategoriler()
        {
            return View();
        }
        public ActionResult V_kitaplar()
        {
            return View();
        }
        [HttpGet]
        public ActionResult V_iletisim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult V_iletisim(V_Iletisim v_Iletisim)
        {
            db.V_Iletisim.Add(v_Iletisim);
            db.SaveChanges();
            return RedirectToAction("V_iletisim");
        }
      



    }
}