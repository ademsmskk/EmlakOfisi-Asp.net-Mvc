using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmlakOfisi.Models.Entity;

namespace EmlakOfisi.Controllers
{    [Authorize]
    [Authorize(Roles = "admin")]
    public class EmlakciController : Controller
    {
    
        private Model1 db = new Model1();

        // GET: Emlakci
        public ActionResult Index()
        {
            return View(db.Emlakci.ToList());
        }

        // GET: Emlakci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emlakci emlakci = db.Emlakci.Find(id);
            if (emlakci == null)
            {
                return HttpNotFound();
            }
            return View(emlakci);
        }

        // GET: Emlakci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emlakci/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmlakciID,EmlakciAdi,Sifre,Telefon,Adres,FirmaAdi,KullaniciAdi")] Emlakci emlakci)
        {
            if (ModelState.IsValid)
            {
                db.Emlakci.Add(emlakci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emlakci);
        }

        // GET: Emlakci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emlakci emlakci = db.Emlakci.Find(id);
            if (emlakci == null)
            {
                return HttpNotFound();
            }
            return View(emlakci);
        }

        // POST: Emlakci/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmlakciID,EmlakciAdi,Sifre,Telefon,Adres,FirmaAdi,KullaniciAdi")] Emlakci emlakci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emlakci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emlakci);
        }

        // GET: Emlakci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emlakci emlakci = db.Emlakci.Find(id);
            if (emlakci == null)
            {
                return HttpNotFound();
            }
            return View(emlakci);
        }

        // POST: Emlakci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emlakci emlakci = db.Emlakci.Find(id);
            db.Emlakci.Remove(emlakci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);


        }
    }
}
