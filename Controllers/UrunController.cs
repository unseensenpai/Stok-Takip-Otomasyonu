using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        [Authorize]
        public ActionResult Index()
        {
            var degerler = db.Tbl_Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        [Authorize]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler; // değerleri taşıma işlemi
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult YeniUrun(Tbl_Urunler p1)
        {
            var ktg = db.Tbl_Kategoriler.Where(m => m.KATEGORIID == p1.Tbl_Kategoriler.KATEGORIID).FirstOrDefault();
            p1.Tbl_Kategoriler = ktg;
            db.Tbl_Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Sil(int id)
        {
            var Urun = db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(Urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler; // değerleri taşıma işlemi
            var Urun = db.Tbl_Urunler.Find(id);
            return View("UrunGetir", Urun);

        }
        [Authorize]
        public ActionResult Guncelle(Tbl_Urunler p1)
        {
            var urun = db.Tbl_Urunler.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            urun.STOK = p1.STOK;
            urun.FIYAT = p1.FIYAT;
            // urun.URUNKATEGORI = p1.URUNKATEGORI;
            var ktg = db.Tbl_Kategoriler.Where(m => m.KATEGORIID == p1.Tbl_Kategoriler.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}