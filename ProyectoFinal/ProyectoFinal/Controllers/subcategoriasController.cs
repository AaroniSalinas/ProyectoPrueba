using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal;

namespace ProyectoFinal.Controllers
{
    public class subcategoriasController : Controller
    {
        private BaseDatosWebEntities db = new BaseDatosWebEntities();

        // GET: subcategorias
        public ActionResult Index()
        {
            var subcategorias = db.subcategorias.Include(s => s.categoria);
            return View(subcategorias.ToList());
        }

        // GET: subcategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategorias.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        // GET: subcategorias/Create
        public ActionResult Create()
        {
            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre");
            return View();
        }

        // POST: subcategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subcategoriaId,categoriaId,subcategoriaNombre")] subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.subcategorias.Add(subcategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", subcategoria.categoriaId);
            return View(subcategoria);
        }

        // GET: subcategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategorias.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", subcategoria.categoriaId);
            return View(subcategoria);
        }

        // POST: subcategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subcategoriaId,categoriaId,subcategoriaNombre")] subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", subcategoria.categoriaId);
            return View(subcategoria);
        }

        // GET: subcategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategorias.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        // POST: subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subcategoria subcategoria = db.subcategorias.Find(id);
            db.subcategorias.Remove(subcategoria);
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
