﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPrroject.Models.Entity;
using MvcCvPrroject.Repositories;

namespace MvcCvPrroject.Controllers
{
    public class DeneyimlerimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(tblDeneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            tblDeneyimlerim t=repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimDuzenle(int id)
        {
            tblDeneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimDuzenle(tblDeneyimlerim p)
        {
            tblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik=p.Baslik;
            t.AltBaslik=p.AltBaslik;
            t.Tarih=p.Tarih;
            t.Aciklama=p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}