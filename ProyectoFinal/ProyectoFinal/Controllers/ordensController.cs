using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal
{
    public class ordensController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: ordens
        public ActionResult Index()
        {
            var orden = db.orden.Include(o => o.status).Include(o => o.usuario);
            return View(orden.ToList());
        }

        // GET: ordens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orden orden = db.orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // GET: ordens/Create
        public ActionResult Create()
        {
            ViewBag.statusId = new SelectList(db.status, "statusId", "statusNombre");
            ViewBag.usuarioId = new SelectList(db.usuario, "usuarioId", "usuarioCorreo");
            return View();
        }

        // POST: ordens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ordenId,usuarioId,ordenTotal,fecha,statusId")] orden orden)
        {
            if (ModelState.IsValid)
            {
                db.orden.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.statusId = new SelectList(db.status, "statusId", "statusNombre", orden.statusId);
            ViewBag.usuarioId = new SelectList(db.usuario, "usuarioId", "usuarioCorreo", orden.usuarioId);
            return View(orden);
        }

        // GET: ordens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orden orden = db.orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.statusId = new SelectList(db.status, "statusId", "statusNombre", orden.statusId);
            ViewBag.usuarioId = new SelectList(db.usuario, "usuarioId", "usuarioCorreo", orden.usuarioId);
            return View(orden);
        }

        // POST: ordens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ordenId,usuarioId,ordenTotal,fecha,statusId")] orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.statusId = new SelectList(db.status, "statusId", "statusNombre", orden.statusId);
            ViewBag.usuarioId = new SelectList(db.usuario, "usuarioId", "usuarioCorreo", orden.usuarioId);
            return View(orden);
        }

        // GET: ordens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orden orden = db.orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orden orden = db.orden.Find(id);
            db.orden.Remove(orden);
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
