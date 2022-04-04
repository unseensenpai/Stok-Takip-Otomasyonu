using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        [Authorize]
        public ActionResult Index(string p)
        {

            //var degerler = db.Tbl_Musteriler.ToList();

            var degerler = from d in db.Tbl_Musteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                //işlem yaptır
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
                return View(degerler.ToList());
            }
            return View(degerler.ToList());


        }

        [HttpGet]
        [Authorize]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult YeniMusteri(Tbl_Musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.Tbl_Musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult Sil(int id)
        {
            var musteri = db.Tbl_Musteriler.Find(id);
            db.Tbl_Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Tbl_Musteriler.Find(id);
            return View("MusteriGetir", mus);

        }
        [Authorize]
        public ActionResult Guncelle(Tbl_Musteriler p1)
        {
            var mus = db.Tbl_Musteriler.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}