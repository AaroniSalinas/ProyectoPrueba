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
    public class productoesController : Controller
    {
        private BaseDatosWebEntities db = new BaseDatosWebEntities();

        // GET: productoes
        public ActionResult Index()
        {
            var productoes = db.productoes.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(productoes.ToList());
        }

        // GET: productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: productoes/Create
        public ActionResult Create()
        {
            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre");
            ViewBag.subcategoriaId = new SelectList(db.subcategorias, "subcategoriaId", "subcategoriaNombre");
            return View();
        }

        // POST: productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productoId,productoNombre,productoPrecio,productoExistencia,categoriaId,subcategoriaId")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.productoes.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", producto.categoriaId);
            ViewBag.subcategoriaId = new SelectList(db.subcategorias, "subcategoriaId", "subcategoriaNombre", producto.subcategoriaId);
            return View(producto);
        }

        // GET: productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", producto.categoriaId);
            ViewBag.subcategoriaId = new SelectList(db.subcategorias, "subcategoriaId", "subcategoriaNombre", producto.subcategoriaId);
            return View(producto);
        }

        // POST: productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productoId,productoNombre,productoPrecio,productoExistencia,categoriaId,subcategoriaId")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", producto.categoriaId);
            ViewBag.subcategoriaId = new SelectList(db.subcategorias, "subcategoriaId", "subcategoriaNombre", producto.subcategoriaId);
            return View(producto);
        }

        // GET: productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.productoes.Find(id);
            db.productoes.Remove(producto);
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
