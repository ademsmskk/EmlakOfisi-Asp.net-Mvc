using EmlakOfisi.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakOfisi.Controllers
{
    [Authorize]
    public class ResimController : Controller
    {
        Model1 ctx = new Model1();
        // GET: Resim
        public ActionResult Index()
        {
            var deger = ctx.Resimler.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Resimler r)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti=Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Image/" + dosyaadi + uzanti;
                 Request.Files[0].SaveAs(Server.MapPath(yol));

                 r.OrtaYol = "/Image/" + dosyaadi + uzanti;

            }
            ctx.Resimler.Add(r);
            ctx.SaveChanges();
            return RedirectToAction("Index");




        }




    }
}