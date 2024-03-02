using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPrroject.Models.Entity;
using MvcCvPrroject.Repositories;
namespace MvcCvPrroject.Controllers
{
    public class YeteneklerimController : Controller
    {
        // GET: Yeteneklerim
        GenericRepository<tblYeteneklerim> repo= new GenericRepository<tblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(tblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}