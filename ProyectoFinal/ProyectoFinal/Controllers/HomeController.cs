 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Security;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {

        private masterEntities db = new masterEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InicioSesion(string mensaje = "")
        {
            ViewBag.Message = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesion(string correo, string contrasena)
        {
            if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(contrasena))
            {
                masterEntities db = new masterEntities();
                usuario user = db.usuario.FirstOrDefault(e => e.usuarioCorreo == correo &&
               e.usuarioContrasenia == contrasena);

                if (user != null)
                {
                    @HttpCookie cookie1 = new @HttpCookie("usuarioNombre", user.usuarioNombre);
                    @Response.Cookies.Add(cookie1);
                    FormsAuthentication.SetAuthCookie(user.usuarioId + "|" + user.usuarioNombre, true);
                    return RedirectToAction("perfilCliente", "Home");
                }
                else
                {
                    return RedirectToAction("InicioSesion", new { message = "Usario/Contraseña inválidos" });
                }
            }
            else
            {
                return RedirectToAction("InicioSesion", new { message = "Escribe tu usuario y contraseña" });
            }
        }

        [Authorize]
        public ActionResult PerfilCliente()
        {
           
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Inicio");
        }

        public ActionResult Registro()
        {

            return View();
        }

        [HttpPost]
       
        public ActionResult Registro([Bind(Include = "usuarioId,usuarioCorreo,usuarioNombre,usuarioApellido,usuarioTelefono,usuarioContrasenia")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("PerfilCliente");
            }

            return View(usuario);
        }
        public ActionResult Carrito()
        {
            var orden = db.orden.Include(o => o.status).Include(o => o.usuario);
            return View(orden.ToList());
        }

        public ActionResult VerCarrito()
        {
            return View();
        }

        public ActionResult Direccion()
        {
            return View();
        }

        public ActionResult HistorialUsuario()
        {
            var orden = db.orden.Include(o => o.status).Include(o => o.usuario);
            return View(orden.ToList());

        }


        public ActionResult Recomendaciones()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        public ActionResult vistaProducto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        public ActionResult Labios()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        public ActionResult Rostro()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        public ActionResult Ojos()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        public ActionResult Hidratantes()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        public ActionResult Limpiadores()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        public ActionResult Mascarillas()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        public ActionResult Serums()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }

        public ActionResult Tonificantes()
        {
            var producto = db.producto.Include(p => p.categoria).Include(p => p.subcategoria);
            return View(producto.ToList());
        }
    }
}