using MvcCvPrroject.Models.Entity;
using MvcCvPrroject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvPrroject.Controllers
{
    public class ReferanslarimController : Controller
    {
       
        // GET: Referanslarim
        GenericRepository<tblReferanslarim> repo = new GenericRepository<tblReferanslarim>();
        public ActionResult Index()
        {
            var referanslar = repo.List();
            return View(referanslar);
        }
        [HttpGet]
        public ActionResult YeniReferans()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniReferans(tblReferanslarim r)
        {
            repo.TAdd(r);
            return RedirectToAction("Index");
        }
        public ActionResult ReferansSil(int id)
        {
            var referans = repo.Find(x => x.ID == id);
            repo.TDelete(referans);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ReferansDuzenle(int id)
        {
            var referans = repo.Find(x => x.ID == id);
            return View(referans);
        }
        [HttpPost]
        public ActionResult ReferansDuzenle(tblReferanslarim r)
        {
            if(!ModelState.IsValid)
            {
                return View("ReferansDuzenle");
            }
            var referans = repo.Find(x => x.ID == r.ID);
            referans.AdSoyad = r.AdSoyad;
            referans.Mail = r.Mail;
            referans.Aciklama = r.Aciklama;
            repo.TUpdate(referans);
            return RedirectToAction("Index");
        }

    }
}