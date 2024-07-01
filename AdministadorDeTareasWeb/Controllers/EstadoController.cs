using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace AdministadorDeTareasWeb.Controllers
{
    public class EstadoController : Controller
    {
        private readonly AppDbContextContainer _context;
        private readonly EstadoService _estadoService;

        public EstadoController()
        {
            _context = new AppDbContextContainer();
            _estadoService = new EstadoService(_context);
        }

        // GET: Estado
        public ActionResult Index()
        {
            var listaEstados = _estadoService.GetAll();
            return View(listaEstados);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (Estado estado)
        {
            var errorMessage = _estadoService.ValidateBeforeCreate(estado);
            try
            {
                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (_estadoService.Create(estado))
                        return RedirectToAction("Index");
                    else
                    {
                        ViewBag.errMessage = errorMessage;
                        return View(estado);
                    }
                }
                else
                {
                    ViewBag.errMessage = errorMessage;
                    return View(estado);
                }
            }catch (Exception ex)
            {
                ViewBag.errMessage = errorMessage;
                return View(estado);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Estado estado = _estadoService.FindId(id);
            if(estado != null)
                return View(estado);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Estado estado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(estado);
                }

                var message = _estadoService.ValidateBeforeUpdate(estado);
                if (string.IsNullOrEmpty(message))
                {
                    _estadoService.Update(estado);
                    return RedirectToAction("Index");
                }

                ViewBag.errMessage = message;
                return View(estado);

            }catch (Exception ex)
            {
                ViewBag.errMessage = "Error de servidor";
                return View(estado);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var estado = _estadoService.FindId(id);
            if(estado == null)
                return RedirectToAction("Index");

            return View(estado);
        }

        public ActionResult Delete(Estado estado)
        {
            try
            {
                var errorMessage = _estadoService.ValidateBeforeDelete(estado.Id);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (_estadoService.Delete(estado.Id))
                        return RedirectToAction("Index");

                    ViewBag.errMessage = errorMessage;
                    return View(estado);
                }

                ViewBag.errMessage = errorMessage;
                return View(estado);
            }catch (Exception ex) {
                ViewBag.errMessage = "No se pudo eliminar";
                return View(estado);
            }
        }
    }
}