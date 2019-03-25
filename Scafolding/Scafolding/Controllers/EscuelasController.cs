using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scafolding;

namespace Scafolding.Controllers
{
    public class EscuelasController : Controller
    {
        private SistemaPruebaEntities db = new SistemaPruebaEntities();

        // GET: Escuelas
        public ActionResult Index()
        {
            return View(db.Escuela.ToList());
        }

        // GET: Escuelas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // GET: Escuelas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escuelas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clave,Nombre,DIreccion")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                db.Escuela.Add(escuela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escuela);
        }

        // GET: Escuelas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // POST: Escuelas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clave,Nombre,DIreccion")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escuela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escuela);
        }

        // GET: Escuelas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // POST: Escuelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Escuela escuela = db.Escuela.Find(id);
            db.Escuela.Remove(escuela);
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
