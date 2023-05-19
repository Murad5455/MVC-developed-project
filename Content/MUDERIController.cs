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
    public class MUDERIController : Controller
    {
        // GET: MUDERI
        Mvc_DbstokEntities2 db = new Mvc_DbstokEntities2();
        public ActionResult Index(int sayfa=1)
        {
            var deger = db.TBLMUSDERILERs.ToList().ToPagedList(sayfa, 3);
           // var deger = db.TBLMUSDERILERs.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMusderi()
        { return View(); }



        [HttpPost]
        public ActionResult YeniMusderi(TBLMUSDERILER p1)
        { if (! ModelState.IsValid)
            { return View("YeniMusderi"); }
            
            db.TBLMUSDERILERs.Add(p1);
            db.SaveChanges();
            return View(); }


        public ActionResult SIL (int id)
        { var deger = db.TBLMUSDERILERs.Find(id);
            db.TBLMUSDERILERs.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult MUSDERIGETIR(int id)
        { var degerler = db.TBLMUSDERILERs.Find(id);
            return View("MUSDERIGETIR",degerler);
        }

        public ActionResult Guncelle(TBLMUSDERILER p1)
        { var mus = db.TBLMUSDERILERs.Find(p1.MUSDERIID);
            mus.MUSDERIAD = p1.MUSDERIAD;
            mus.MUSDERISOYAD = p1.MUSDERISOYAD;
            db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}