using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BrainLibrary.Models.Entity;

namespace BrainLibrary.Controllers
{
    
    public class AdminLoginController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult AdmLgn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdmLgn(Adminler a)
        {
            var query = db.Adminler.FirstOrDefault(x => x.Kullanici == a.Kullanici && x.Sifre == a.Sifre);
            if (query!= null)
            {
                FormsAuthentication.SetAuthCookie(query.Kullanici, false);
                Session["Kullanıcı"] = query.Kullanici.ToString();
                return RedirectToAction("Kategori", "AdminKategori");

            }
            else
            {
                return View();
            }
          
        }
    }
}