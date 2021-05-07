using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal
{
    public class ordensController : Controller
    {
        private BaseDatosWebEntities4 db = new BaseDatosWebEntities4();

        // GET: ordens
        public ActionResult Index()
        {
            var ordens = db.ordens.Include(o => o.status).Include(o => o.usuario);
            return View(ordens.ToList());
        }

        // GET: ordens/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string query = "Select * from orden where ordenId = @p0";
            orden orden = await db.ordens.SqlQuery(query, id).SingleOrDefaultAsync();
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
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "usuarioCorreo");
            return View();
        }

        // POST: ordens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ordenId,usuarioId,ordenTotal,fecha,statusId")] orden orden)
        {
            if (ModelState.IsValid)
            {
                db.ordens.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.statusId = new SelectList(db.status, "statusId", "statusNombre", orden.statusId);
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "usuarioCorreo", orden.usuarioId);
            return View(orden);
        }

        // GET: ordens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orden orden = db.ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.statusId = new SelectList(db.status, "statusId", "statusNombre", orden.statusId);
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "usuarioCorreo", orden.usuarioId);
            return View(orden);
        }

        // POST: ordens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "usuarioCorreo", orden.usuarioId);
            return View(orden);
        }

        // GET: ordens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orden orden = db.ordens.Find(id);
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
            orden orden = db.ordens.Find(id);
            db.ordens.Remove(orden);
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
