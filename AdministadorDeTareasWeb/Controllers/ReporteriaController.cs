using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministadorDeTareasWeb.Controllers
{
    public class ReporteriaController : Controller
    {
        private readonly AppDbContextContainer _context;

        public ReporteriaController()
        {
            _context = new AppDbContextContainer();
        }
        // GET: Reporteria
        public ActionResult RptTareaEstado()
        {
            return View();
        }
    }
}