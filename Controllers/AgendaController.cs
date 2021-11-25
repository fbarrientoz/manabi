using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using manabi.Models;

namespace manabi.Controllers
{
    public class AgendaController : Controller
    {
        private TWSSEntities db = new TWSSEntities();

        // GET: Agenda
        public ActionResult Index()
        {
            var agenda = db.Agenda.Include(a => a.Dia1).Include(a => a.Hora1).Include(a => a.Pictograma);
            return View(agenda.ToList());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.Agenda.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            return View(agendum);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            ViewBag.dia = new SelectList(db.Dias, "Id", "Dia1");
            ViewBag.hora = new SelectList(db.Horas, "Id", "Hora1");
            ViewBag.fk_pictograma = new SelectList(db.Pictogramas, "Id", "Nombre");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fk_pictograma,Hora,Descripcion,Dia")] Agendum agendum)
        {
            if (ModelState.IsValid)
            {
                db.Agenda.Add(agendum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dia = new SelectList(db.Dias, "Id", "Dia1", agendum.dia);
            ViewBag.hora = new SelectList(db.Horas, "Id", "Hora1", agendum.hora);
            ViewBag.fk_pictograma = new SelectList(db.Pictogramas, "Id", "Nombre", agendum.fk_pictograma);
            return View(agendum);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.Agenda.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            ViewBag.dia = new SelectList(db.Dias, "Id", "Dia1", agendum.dia);
            ViewBag.hora = new SelectList(db.Horas, "Id", "Hora1", agendum.hora);
            ViewBag.fk_pictograma = new SelectList(db.Pictogramas, "Id", "Nombre", agendum.fk_pictograma);
            return View(agendum);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fk_pictograma,Hora,Descripcion,Dia")] Agendum agendum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dia = new SelectList(db.Dias, "Id", "Dia1", agendum.dia);
            ViewBag.hora = new SelectList(db.Horas, "Id", "Hora1", agendum.hora);
            ViewBag.fk_pictograma = new SelectList(db.Pictogramas, "Id", "Nombre", agendum.fk_pictograma);
            return View(agendum);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.Agenda.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            return View(agendum);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendum agendum = db.Agenda.Find(id);
            db.Agenda.Remove(agendum);
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
