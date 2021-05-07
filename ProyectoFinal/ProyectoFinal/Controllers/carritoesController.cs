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
    public class carritoesController : Controller
    {
        private BaseDatosWebEntities6 db = new BaseDatosWebEntities6();

        // GET: carritoes
        public async Task<ActionResult> Index()
        {
            var carritoes = db.carritoes.Include(c => c.producto).Include(c => c.usuario);
            return View(await carritoes.ToListAsync());
        }

        // GET: carritoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrito carrito = await db.carritoes.FindAsync(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            return View(carrito);
        }

        // GET: carritoes/Create
        public ActionResult Create()
        {
            ViewBag.productoId = new SelectList(db.productoes, "productoId", "productoNombre");
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "usuarioCorreo");
            return View();
        }

        // POST: carritoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "carritoId,usuarioId,productoId,pedidoCantidad,pedidoSubtotal")] carrito carrito)
        {
            if (ModelState.IsValid)
            {
                db.carritoes.Add(carrito);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.productoId = new SelectList(db.productoes, "productoId", "productoNombre", carrito.productoId);
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "usuarioCorreo", carrito.usuarioId);
            return View(carrito);
        }

        // GET: carritoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrito carrito = await db.carritoes.FindAsync(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.productoId = new SelectList(db.productoes, "productoId", "productoNombre", carrito.productoId);
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "usuarioCorreo", carrito.usuarioId);
            return View(carrito);
        }

        // POST: carritoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "carritoId,usuarioId,productoId,pedidoCantidad,pedidoSubtotal")] carrito carrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrito).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.productoId = new SelectList(db.productoes, "productoId", "productoNombre", carrito.productoId);
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "usuarioCorreo", carrito.usuarioId);
            return View(carrito);
        }

        // GET: carritoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrito carrito = await db.carritoes.FindAsync(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            return View(carrito);
        }

        // POST: carritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            carrito carrito = await db.carritoes.FindAsync(id);
            db.carritoes.Remove(carrito);
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
