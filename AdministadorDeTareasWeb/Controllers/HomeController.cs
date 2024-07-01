using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministadorDeTareasWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContextContainer _context;
        private readonly CategoriaService _categoriaService;

        public HomeController()
        {
            _context = new AppDbContextContainer();
            _categoriaService = new CategoriaService(_context);
        }

        [HttpGet]
        public ActionResult Index()
        {
            //var categorias = _categoriaService.GetAll();
            ViewBag.categorias = _context.Categorias.Count();
            ViewBag.tareas = _context.Tareas.Count();
            ViewBag.prioridades = _context.Prioridades.Count();
            ViewBag.estados = _context.Estados.Count();
            ViewBag.usuarios = _context.Usuarios.Count();
            ViewBag.NoData = "No existen registros";
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
    }
}