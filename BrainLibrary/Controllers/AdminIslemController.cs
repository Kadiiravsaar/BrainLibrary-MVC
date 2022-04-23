using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainLibrary.Models.Entity;
namespace BrainLibrary.Controllers
{
   
    public class AdminIslemController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Islem()
        {
            var query = db.Hareketler.Where(x => x.IslemDurum == true).ToList();
            return View(query);
        }
    }
}