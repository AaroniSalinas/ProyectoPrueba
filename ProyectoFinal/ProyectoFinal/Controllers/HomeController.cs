using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult InicioSesion()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        public ActionResult Carrito()
        {
            return View();
        }

        public ActionResult Direccion()
        {
            return View();
        }

        public ActionResult HistorialUsuario()
        {
            return View();
        }


        public ActionResult Recomendaciones()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult vistaProducto()
        {
            return View();
        }
    }
}