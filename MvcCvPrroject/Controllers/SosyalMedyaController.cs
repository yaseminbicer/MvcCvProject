using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPrroject.Models.Entity;
using MvcCvPrroject.Repositories; 

namespace MvcCvPrroject.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<tblSosyalMedya> repo = new GenericRepository<tblSosyalMedya> ();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult YeniEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniEkle(tblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap =repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(tblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Adi=  p.Adi;
            hesap.Durum = true;
            hesap.Link = p.Link;
            hesap.Ikon = p.Ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            repo.TDelete(hesap);
            return RedirectToAction("Index");
        }
    }
}