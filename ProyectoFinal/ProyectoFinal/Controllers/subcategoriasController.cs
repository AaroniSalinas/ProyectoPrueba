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
    public class subcategoriasController : Controller
    {
        private BaseDatosWebEntities4 db = new BaseDatosWebEntities4();

        // GET: subcategorias
        public async Task<ActionResult> Index()
        {
            var subcategorias = db.subcategorias.Include(s => s.categoria);
            return View(await subcategorias.ToListAsync());
        }

        // GET: subcategorias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = await db.subcategorias.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "subcategoriaId,categoriaId,subcategoriaNombre")] subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.subcategorias.Add(subcategoria);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", subcategoria.categoriaId);
            return View(subcategoria);
        }

        // GET: subcategorias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = await db.subcategorias.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "subcategoriaId,categoriaId,subcategoriaNombre")] subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategoria).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaId = new SelectList(db.categorias, "categoriaId", "categoriaNombre", subcategoria.categoriaId);
            return View(subcategoria);
        }

        // GET: subcategorias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = await db.subcategorias.FindAsync(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        // POST: subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            subcategoria subcategoria = await db.subcategorias.FindAsync(id);
            db.subcategorias.Remove(subcategoria);
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
