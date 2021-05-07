using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal
{
    public class productoesController : Controller
    {
        private BaseDatosWebEntities4 db = new BaseDatosWebEntities4();

        // GET: productoes
        public async Task<ActionResult> Index()
        {
            var productoes = db.productoes.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(await productoes.ToListAsync());
        }

        // GET: productoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = await db.productoes.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "productoId,productoNombre,productoPrecio,productoExistencia,categoriaId,subcategoriaId")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.productoes.Add(producto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", producto.categoriaId);
            ViewBag.subcategoriaId = new SelectList(db.subcategorias, "subcategoriaId", "subcategoriaNombre", producto.subcategoriaId);
            return View(producto);
        }

        // GET: productoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = await db.productoes.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "productoId,productoNombre,productoPrecio,productoExistencia,categoriaId,subcategoriaId")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", producto.categoriaId);
            ViewBag.subcategoriaId = new SelectList(db.subcategorias, "subcategoriaId", "subcategoriaNombre", producto.subcategoriaId);
            return View(producto);
        }

        // GET: productoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = await db.productoes.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            producto producto = await db.productoes.FindAsync(id);
            db.productoes.Remove(producto);
            await db.SaveChangesAsync();
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
