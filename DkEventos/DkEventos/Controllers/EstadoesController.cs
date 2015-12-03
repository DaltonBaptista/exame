using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DkEventos;

namespace DkEventos.Controllers
{
    public class EstadoesController : Controller
    {
        private dkeventosEntities db = new dkeventosEntities();

        // GET: Estadoes
        public ActionResult Index()
        {
            var estadoes = db.Estadoes.Include(e => e.Evento);
            return View(estadoes.ToList());
        }

        // GET: Estadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estadoes.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // GET: Estadoes/Create
        public ActionResult Create()
        {
            ViewBag.idEvento = new SelectList(db.Eventoes, "idEvento", "titulo");
            return View();
        }

        // POST: Estadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstado,activo,cancelado,idEvento")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Estadoes.Add(estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEvento = new SelectList(db.Eventoes, "idEvento", "titulo", estado.idEvento);
            return View(estado);
        }

        // GET: Estadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estadoes.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEvento = new SelectList(db.Eventoes, "idEvento", "titulo", estado.idEvento);
            return View(estado);
        }

        // POST: Estadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstado,activo,cancelado,idEvento")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEvento = new SelectList(db.Eventoes, "idEvento", "titulo", estado.idEvento);
            return View(estado);
        }

        // GET: Estadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estadoes.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado estado = db.Estadoes.Find(id);
            db.Estadoes.Remove(estado);
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
