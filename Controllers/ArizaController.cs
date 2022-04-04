using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class ArizaController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        // GET: Ariza
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniAriza()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAriza(Tbl_Ariza p1)
        {
            db.Tbl_Ariza.Add(p1);   
            db.SaveChanges();
            return View("Index");
        }
    }
}