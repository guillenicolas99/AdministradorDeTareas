using CapaDato.Models;
using CapaDto.DTO;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministadorDeTareasWeb.Controllers
{
    public class PrioridadController : Controller
    {
        private readonly AppDbContextContainer _context;
        private readonly PrioridadService _prioridadService;

        public PrioridadController()
        {
            _context = new AppDbContextContainer();
            _prioridadService = new PrioridadService(_context);
        }

        // GET: Prioridad
        public ActionResult Index()
        {
            var prioridades = _prioridadService.GetAll().Select(x => new PrioridadDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Clase = x.Clase,
                
            }).ToList();

            var listaPrioridades = _prioridadService.GetAll();
            return View(listaPrioridades);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Prioridad prioridad)
        {
            try
            {
                var mesasge = _prioridadService.ValidateBeforeCreate(prioridad);
                if (string.IsNullOrEmpty(mesasge))
                {
                    if(_prioridadService.Create(prioridad))
                        return RedirectToAction("Index");
                    else
                        return View(prioridad);
                }
                else
                {
                    ViewBag.errMessage = mesasge;
                    return View(prioridad);
                }
            }
            catch (Exception ex)
            {
                ViewBag.errMessage = "Error al crear Prioridad";
                return View(prioridad);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Prioridad prioridad= _prioridadService.FindId(id);
            if (prioridad != null)
            {
                return View(prioridad);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Edit(Prioridad prioridad)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(prioridad);
                }

                var message = _prioridadService.ValidateBeforeUpdate(prioridad);
                if (string.IsNullOrEmpty(message))
                {
                    _prioridadService.Update(prioridad);
                    return RedirectToAction("Index");
                }

                ViewBag.errMessage = message;
                return View(prioridad);
            }
            catch (Exception ex)
            {
                ViewBag.errMessage = "Error de servidor";
                return View(prioridad);
            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var cateoria = _prioridadService.FindId(id);
            if (cateoria == null)
            {
                return RedirectToAction("Index");
            }

            return View(cateoria);
        }

        [HttpPost]
        public ActionResult Delete(Prioridad prioridad)
        {
            try
            {
                var errorMessage = _prioridadService.ValidateBeforeDelete(prioridad.Id);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (_prioridadService.Delete(prioridad.Id))
                        return RedirectToAction("Index");

                    ViewBag.errMessage = "No se pudo eliminar";
                    return View(prioridad);
                }

                ViewBag.errMessage = errorMessage;
                return View(prioridad);
            }
            catch (Exception ex)
            {
                ViewBag.errMessage = "No se pudo eliminar";
                return View(prioridad);
            }
        }
    }
}