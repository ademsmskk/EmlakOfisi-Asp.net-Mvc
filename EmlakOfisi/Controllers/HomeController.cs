using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmlakOfisi.Models.Entity;
namespace EmlakOfisi.Controllers
{
    //Bu controller içindeki controller açılması için giriş yapılması gerekmektedir.
    [Authorize]
    public class HomeController : Controller
    {
        Model1 ctx = new Model1();
       
        public ActionResult Index()
        {
            var degerler = ctx.İlanBilgileri.ToList();
            return View(degerler);
        }


        public ActionResult İlanEkle()
        {
            ViewBag.İlanBilgileri = ctx.İlanBilgileri.ToList();
            ViewBag.Emlakci = ctx.Emlakci.ToList();
            return View();

        }

        [HttpPost]
        public ActionResult İlanEkle(İlanBilgileri u)
        {
            ctx.İlanBilgileri.Add(u);
            ctx.SaveChanges();
            return View();


        }
    }
}