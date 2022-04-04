using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        // GET: Satis

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniSatis(Tbl_Satislar p1)
        {
            db.Tbl_Satislar.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
        
    }
    
    
}