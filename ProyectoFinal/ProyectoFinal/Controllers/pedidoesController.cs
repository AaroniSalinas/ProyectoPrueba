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
    public class pedidoesController : Controller
    {
        private BaseDatosWebEntities4 db = new BaseDatosWebEntities4();

        // GET: pedidoes
        public async Task<ActionResult> Index()
        {
            var pedidos = db.pedidos.Include(p => p.orden).Include(p => p.producto);
            return View(await pedidos.ToListAsync());
        }

        // GET: pedidoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = await db.pedidos.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.ordenId = new SelectList(db.ordens, "ordenId", "ordenId");
            ViewBag.productoId = new SelectList(db.productoes, "productoId", "productoNombre");
            return View();
        }

        // POST: pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pedidoId,ordenId,productoId,pedidoCantidad,pedidoSubtotal")] pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.pedidos.Add(pedido);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ordenId = new SelectList(db.ordens, "ordenId", "ordenId", pedido.ordenId);
            ViewBag.productoId = new SelectList(db.productoes, "productoId", "productoNombre", pedido.productoId);
            return View(pedido);
        }

        // GET: pedidoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = await db.pedidos.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ordenId = new SelectList(db.ordens, "ordenId", "ordenId", pedido.ordenId);
            ViewBag.productoId = new SelectList(db.productoes, "productoId", "productoNombre", pedido.productoId);
            return View(pedido);
        }

        // POST: pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pedidoId,ordenId,productoId,pedidoCantidad,pedidoSubtotal")] pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ordenId = new SelectList(db.ordens, "ordenId", "ordenId", pedido.ordenId);
            ViewBag.productoId = new SelectList(db.productoes, "productoId", "productoNombre", pedido.productoId);
            return View(pedido);
        }

        // GET: pedidoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = await db.pedidos.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            pedido pedido = await db.pedidos.FindAsync(id);
            db.pedidos.Remove(pedido);
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
