using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPrroject.Models.Entity;
using MvcCvPrroject.Repositories;

namespace MvcCvPrroject.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<tblIletisim> repo=new GenericRepository<tblIletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}