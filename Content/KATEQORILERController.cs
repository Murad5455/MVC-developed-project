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
    public class KATEQORILERController : Controller
    {
        // GET: KULUPLER
        Mvc_DbstokEntities2 db = new Mvc_DbstokEntities2();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLKATEQORILERs.ToList().ToPagedList(sayfa, 3);

            //var degerler = db.TBLKATEQORILERs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKateqori()
        {
            return View();
        }



        [HttpPost]
        public ActionResult YeniKateqori(TBLKATEQORILER p1)
        {
            if (!ModelState.IsValid)
            { return View("YeniKateqori"); }

            db.TBLKATEQORILERs.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult SIL(int id)
        {
            var DEGER = db.TBLKATEQORILERs.Find(id);
            db.TBLKATEQORILERs.Remove(DEGER);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult KateqoriGuncelle(int id)

        { var deger = db.TBLKATEQORILERs.Find(id);
            return View("KateqoriGuncelle", deger);
        }

        public ActionResult GUNCELLE(TBLKATEQORILER P1)
        {
            var deger = db.TBLKATEQORILERs.Find(P1.KATEQORIID);
            deger.KATEQORIAD = P1.KATEQORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
                
                }
    }
}