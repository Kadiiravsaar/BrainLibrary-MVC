using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
    
    public class AdminIstatistikController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Istatistik()
        {
            var queryuye = db.Uyeler.Count();
            var querykitap = db.Kitaplar.Count();
            var queryiceri = db.Kitaplar.Where(x=>x.Durum == false).Count();
            var queryceza = db.Cezalar.Sum(x=>x.Para);

            ViewBag.uyeget = queryuye;
            ViewBag.kitapget = querykitap;
            ViewBag.icerikitapget = queryiceri;
            ViewBag.cezaget = queryceza;
            return View();
        }
    }
}