using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPrroject.Models.Entity;

namespace MvcCvPrroject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        dbCvEntities db = new dbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.tblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler =db.tblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.tblEgitimlerim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.tblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.tblHobilerim.ToList();
            return PartialView(hobiler);
        }
    }
}