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
    public class PictogramasAdminController : Controller
    {
        private TWSSEntities db = new TWSSEntities();

        // GET: PictogramasAdmin
        public ActionResult Index()
        {
            return View(db.Pictogramas.ToList());
        }

        // GET: PictogramasAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictograma pictograma = db.Pictogramas.Find(id);
            if (pictograma == null)
            {
                return HttpNotFound();
            }
            return View(pictograma);
        }

        // GET: PictogramasAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PictogramasAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Foto")] Pictograma pictograma, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file !=null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Content/img/Pictogramas/" + ImageName);
                    file.SaveAs(physicalPath);
                    pictograma.Foto = ImageName;
                }
                db.Pictogramas.Add(pictograma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pictograma);
        }

        // GET: PictogramasAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictograma pictograma = db.Pictogramas.Find(id);
            if (pictograma == null)
            {
                return HttpNotFound();
            }
            return View(pictograma);
        }

        // POST: PictogramasAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Foto")] Pictograma pictograma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pictograma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pictograma);
        }

        // GET: PictogramasAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictograma pictograma = db.Pictogramas.Find(id);
            if (pictograma == null)
            {
                return HttpNotFound();
            }
            return View(pictograma);
        }

        // POST: PictogramasAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pictograma pictograma = db.Pictogramas.Find(id);
            db.Pictogramas.Remove(pictograma);
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
