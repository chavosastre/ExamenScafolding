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
    public class GruposController : Controller
    {
        private SistemaPruebaEntities db = new SistemaPruebaEntities();

        // GET: Grupos
        public ActionResult Index()
        {
            var grupos = db.Grupos.Include(g => g.Escuela).Include(g => g.Materias).Include(g => g.Profesor);
            return View(grupos.ToList());
        }

        // GET: Grupos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            return View(grupos);
        }

        // GET: Grupos/Create
        public ActionResult Create()
        {
            ViewBag.ClaveEscuela = new SelectList(db.Escuela, "Clave", "Nombre");
            ViewBag.ClaveMateria = new SelectList(db.Materias, "Clave", "Nombre");
            ViewBag.ClaveProfesor = new SelectList(db.Profesor, "Clave", "Nombre");
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClaveEscuela,ClaveMateria,ClaveProfesor,Nombre,HoraInicio,HoraFinal")] Grupos grupos)
        {
            if (ModelState.IsValid)
            {
                db.Grupos.Add(grupos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClaveEscuela = new SelectList(db.Escuela, "Clave", "Nombre", grupos.ClaveEscuela);
            ViewBag.ClaveMateria = new SelectList(db.Materias, "Clave", "Nombre", grupos.ClaveMateria);
            ViewBag.ClaveProfesor = new SelectList(db.Profesor, "Clave", "Nombre", grupos.ClaveProfesor);
            return View(grupos);
        }

        // GET: Grupos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClaveEscuela = new SelectList(db.Escuela, "Clave", "Nombre", grupos.ClaveEscuela);
            ViewBag.ClaveMateria = new SelectList(db.Materias, "Clave", "Nombre", grupos.ClaveMateria);
            ViewBag.ClaveProfesor = new SelectList(db.Profesor, "Clave", "Nombre", grupos.ClaveProfesor);
            return View(grupos);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClaveEscuela,ClaveMateria,ClaveProfesor,Nombre,HoraInicio,HoraFinal")] Grupos grupos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClaveEscuela = new SelectList(db.Escuela, "Clave", "Nombre", grupos.ClaveEscuela);
            ViewBag.ClaveMateria = new SelectList(db.Materias, "Clave", "Nombre", grupos.ClaveMateria);
            ViewBag.ClaveProfesor = new SelectList(db.Profesor, "Clave", "Nombre", grupos.ClaveProfesor);
            return View(grupos);
        }

        // GET: Grupos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            return View(grupos);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Grupos grupos = db.Grupos.Find(id);
            db.Grupos.Remove(grupos);
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
