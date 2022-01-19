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
{
    [Authorize]
    public class İlanBilgileriController : Controller
    {
        private Model1 db = new Model1();

        // GET: İlanBilgileri
        public ActionResult Index()
        {
            var İlanBilgileri = db.İlanBilgileri.Include(İ => İ.Emlakci);
            return View(İlanBilgileri.ToList());
        }

        // GET: İlanBilgileri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            İlanBilgileri İlanBilgileri = db.İlanBilgileri.Find(id);
            if (İlanBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(İlanBilgileri);
        }

        // GET: İlanBilgileri/Create
        public ActionResult Create()
        {
            ViewBag.EmlakciID = new SelectList(db.Emlakci, "EmlakciID", "EmlakciAdi");
            return View();
        }

        // POST: İlanBilgileri/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "İlanID,İlanTarihi,EmlakciID,Aciklama,OdaSayisi,BinaYasi,Balkon,Adres,Fiyat")] İlanBilgileri İlanBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.İlanBilgileri.Add(İlanBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmlakciID = new SelectList(db.Emlakci, "EmlakciID", "EmlakciAdi", İlanBilgileri.EmlakciID);
            return View(İlanBilgileri); 
            
        }

        // GET: İlanBilgileri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            İlanBilgileri İlanBilgileri = db.İlanBilgileri.Find(id);
            if (İlanBilgileri == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmlakciID = new SelectList(db.Emlakci, "EmlakciID", "EmlakciAdi", İlanBilgileri.EmlakciID);
            return View(İlanBilgileri);
        }

        // POST: İlanBilgileri/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "İlanID,İlanTarihi,EmlakciID,Aciklama,OdaSayisi,BinaYasi,Balkon,Adres,Fiyat")] İlanBilgileri İlanBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(İlanBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmlakciID = new SelectList(db.Emlakci, "EmlakciID", "EmlakciAdi", İlanBilgileri.EmlakciID);
            return View(İlanBilgileri);
        }

        // GET: İlanBilgileri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            İlanBilgileri İlanBilgileri = db.İlanBilgileri.Find(id);
            if (İlanBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(İlanBilgileri);
        }

        // POST: İlanBilgileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            İlanBilgileri İlanBilgileri = db.İlanBilgileri.Find(id);
            db.İlanBilgileri.Remove(İlanBilgileri);
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
