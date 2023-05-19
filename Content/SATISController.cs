using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_STOK4.Models.ENTITY;

namespace MVC_STOK4.Content
{
    public class SATISController : Controller
    {
        // GET: SATIS
        Mvc_DbstokEntities2 db = new Mvc_DbstokEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        { return View(); }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        { db.TBLSATISLARs.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}