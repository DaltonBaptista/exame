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
    public class ParticipantesPrincipaisController : Controller
    {
        private dkeventosEntities db = new dkeventosEntities();

        // GET: ParticipantesPrincipais
        public ActionResult Index()
        {
            var participantesPrincipais = db.ParticipantesPrincipais.Include(p => p.Evento).Include(p => p.Participante);
            return View(participantesPrincipais.ToList());
        }

        // GET: ParticipantesPrincipais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipantesPrincipai participantesPrincipai = db.ParticipantesPrincipais.Find(id);
            if (participantesPrincipai == null)
            {
                return HttpNotFound();
            }
            return View(participantesPrincipai);
        }

        // GET: ParticipantesPrincipais/Create
        public ActionResult Create()
        {
            ViewBag.idEvento = new SelectList(db.Eventoes, "idEvento", "titulo");
            ViewBag.idParticipante = new SelectList(db.Participantes, "idParticipante", "nome");
            return View();
        }

        // POST: ParticipantesPrincipais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idParticipantePrincipal,orador,palestrante,idEvento,idParticipante")] ParticipantesPrincipai participantesPrincipai)
        {
            if (ModelState.IsValid)
            {
                db.ParticipantesPrincipais.Add(participantesPrincipai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEvento = new SelectList(db.Eventoes, "idEvento", "titulo", participantesPrincipai.idEvento);
            ViewBag.idParticipante = new SelectList(db.Participantes, "idParticipante", "nome", participantesPrincipai.idParticipante);
            return View(participantesPrincipai);
        }

        // GET: ParticipantesPrincipais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipantesPrincipai participantesPrincipai = db.ParticipantesPrincipais.Find(id);
            if (participantesPrincipai == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEvento = new SelectList(db.Eventoes, "idEvento", "titulo", participantesPrincipai.idEvento);
            ViewBag.idParticipante = new SelectList(db.Participantes, "idParticipante", "nome", participantesPrincipai.idParticipante);
            return View(participantesPrincipai);
        }

        // POST: ParticipantesPrincipais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idParticipantePrincipal,orador,palestrante,idEvento,idParticipante")] ParticipantesPrincipai participantesPrincipai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participantesPrincipai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEvento = new SelectList(db.Eventoes, "idEvento", "titulo", participantesPrincipai.idEvento);
            ViewBag.idParticipante = new SelectList(db.Participantes, "idParticipante", "nome", participantesPrincipai.idParticipante);
            return View(participantesPrincipai);
        }

        // GET: ParticipantesPrincipais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipantesPrincipai participantesPrincipai = db.ParticipantesPrincipais.Find(id);
            if (participantesPrincipai == null)
            {
                return HttpNotFound();
            }
            return View(participantesPrincipai);
        }

        // POST: ParticipantesPrincipais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParticipantesPrincipai participantesPrincipai = db.ParticipantesPrincipais.Find(id);
            db.ParticipantesPrincipais.Remove(participantesPrincipai);
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
