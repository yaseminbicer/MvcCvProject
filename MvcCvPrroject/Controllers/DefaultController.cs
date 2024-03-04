using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPrroject.Models.Entity;

namespace MvcCvPrroject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        dbEntities db = new dbEntities();
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
        public PartialViewResult Projelerim()
        {
            var projeler = db.tblProjelerim.ToList();
            return PartialView(projeler);
        }
        public PartialViewResult Referanslarim()
        {
            var referanslar = db.tblReferanslarim.ToList();
            return PartialView(referanslar);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.tblSosyalMedya.Where(x => x.Durum ==true).ToList();
            return PartialView(sosyalMedya);
        }
        public PartialViewResult Sertifikalarim()
        {
            var sertifikalar = db.tblSertifikalarim.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult İletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletisim(tblIletisim t)
        {
            t.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblIletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}