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
                usuario users = db.usuario.FirstOrDefault(e => e.usuarioCorreo == correo &&
                e.usuarioContrasenia == contrasena);
                if (users != null)
                {
                    FormsAuthentication.SetAuthCookie(users.usuarioCorreo, true);
                    return RedirectToAction("Inicio", "Home");
                }
                else
                {
                    return RedirectToAction("Inicio", new { message = "Usario/Contraseña inválidos" });
                }
            }
            else
            {
                return RedirectToAction("Inicio", new { message = "Escribe tu usuario y contraseña" });
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Inicio");
        }
        public ActionResult PerfilCliente()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
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

        public ActionResult vistaProducto()
        {
            return View();
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