using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.Tbl_Kategoriler.ToList();
            var degerler = db.Tbl_Kategoriler.ToList().ToPagedList(sayfa, 10); // sayfa başına kaç kategoriyi çekmek istiyorsun
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult YeniKategori()
        {
            return View();
        }        
        [HttpPost]
        [Authorize]
        public ActionResult YeniKategori(Tbl_Kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Tbl_Kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult Sil(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            db.Tbl_Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Tbl_Kategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }
        [Authorize]
        public ActionResult Guncelle(Tbl_Kategoriler p1)
        {
            var ktgr = db.Tbl_Kategoriler.Find(p1.KATEGORIID);
            ktgr.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}