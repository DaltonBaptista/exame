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
    public class TipoEventoesController : Controller
    {
        private dkeventosEntities db = new dkeventosEntities();

        // GET: TipoEventoes
        public ActionResult Index()
        {
            return View(db.TipoEventoes.ToList());
        }

        // GET: TipoEventoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvento tipoEvento = db.TipoEventoes.Find(id);
            if (tipoEvento == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvento);
        }

        // GET: TipoEventoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEventoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoEvento,nome")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                db.TipoEventoes.Add(tipoEvento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEvento);
        }

        // GET: TipoEventoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvento tipoEvento = db.TipoEventoes.Find(id);
            if (tipoEvento == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvento);
        }

        // POST: TipoEventoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoEvento,nome")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEvento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEvento);
        }

        // GET: TipoEventoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvento tipoEvento = db.TipoEventoes.Find(id);
            if (tipoEvento == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvento);
        }

        // POST: TipoEventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEvento tipoEvento = db.TipoEventoes.Find(id);
            db.TipoEventoes.Remove(tipoEvento);
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
