using MvcCvPrroject.Models.Entity;
using MvcCvPrroject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvPrroject.Controllers
{
    public class ProjelerimController : Controller
    {
        // GET: Projelerim
        GenericRepository<tblProjelerim> repo = new GenericRepository<tblProjelerim>();
        public ActionResult Index()
        {
            var projeler = repo.List();
            return View(projeler);
        }
        [HttpGet]
        public ActionResult YeniProje()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniProje(tblProjelerim pr)
        {
            repo.TAdd(pr);
            return RedirectToAction("Index");
        }
        public ActionResult ProjeSil(int id)
        {
            var proje = repo.Find(x => x.ID == id);
            repo.TDelete(proje);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProjeDuzenle(int id)
        {
            var proje = repo.Find(x => x.ID == id);
            return View(proje);
        }
        [HttpPost]
        public ActionResult ProjeDuzenle(tblProjelerim p)
        {
            if(!ModelState.IsValid)
            {
                return View("ProjeDuzenle");
            }
            var proje = repo.Find(x => x.ID == p.ID);
            proje.ProjeAdi = p.ProjeAdi;
            proje.Teknolojiler = p.Teknolojiler;
            proje.Link = p.Link;
            repo.TUpdate(proje);
            return RedirectToAction("Index");
        }
      
    }
}