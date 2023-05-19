using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_STOK4.Models.ENTITY;
using PagedList;
using PagedList.Mvc;

namespace MVC_STOK4.Content
{
    public class URUNController : Controller
    {
        Mvc_DbstokEntities2 db = new Mvc_DbstokEntities2();
        // GET: URUN
        public ActionResult Index(int sayfa=1)
        {
            var deger = db.TBLURUNLERs.ToList().ToPagedList(sayfa, 8);
            //var deger = db.TBLURUNLERs.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEQORILERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEQORIAD,
                                                 Value = i.KATEQORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p2)
        {


            var degerler = db.TBLKATEQORILERs.Where(a => a.KATEQORIID == p2.TBLKATEQORILER.KATEQORIID).FirstOrDefault();
            p2.TBLKATEQORILER = degerler;
            db.TBLURUNLERs.Add(p2);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult UreunGuncelle(int id)
        {
            List<SelectListItem> deger1 = (from w in db.TBLKATEQORILERs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = w.KATEQORIAD,
                                               Value = w.KATEQORIID.ToString()

                                           }).ToList();
            ViewBag.urn = deger1;


            var deger = db.TBLURUNLERs.Find(id);
            return View("UreunGuncelle", deger);
        }


        public ActionResult GUNCELLE(TBLURUNLER P1)

        {
            var derer = db.TBLKATEQORILERs.Where(m => m.KATEQORIID == P1.TBLKATEQORILER.KATEQORIID).FirstOrDefault();

          
            var W = db.TBLURUNLERs.Find(P1.URUNID);
            W.URUNAD = P1.URUNAD;
            W.MARKA = P1.MARKA;
            //W.URUNKATEQORI = P1.URUNKATEQORI;
            W.TBLKATEQORILER = derer;
            W.FIATI = P1.FIATI;
            W.STOK = P1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var deger = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}