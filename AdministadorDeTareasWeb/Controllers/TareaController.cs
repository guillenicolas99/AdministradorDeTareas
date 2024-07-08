using AutoMapper;
using CapaDato.Models;
using CapaDto.DTO;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AdministadorDeTareasWeb.Controllers
{
    public class TareaController : Controller
    {
        private readonly AppDbContextContainer _context;
        private readonly TareaService _tareaService;

        public TareaController()
        {
            _context = new AppDbContextContainer();
            _tareaService = new TareaService(_context);
        }

        [HttpGet]
        public ActionResult Index(FiltrarTareasVM filtro)
        {
            if (filtro != null && (filtro.Titulo != null || filtro.EstadoID != null || filtro.PrioridadID != null || filtro.CategoriaID != null || filtro.ResponsableID != null))
            {
                var tareasFilter = _tareaService.GetTareasFilter(filtro);
                var indexTarea = new IndexTareaVM
                {
                    Tareas = tareasFilter
                };
                return View(indexTarea);
            }
            
            var tareas = Mapper.Map<ICollection<TareaDto>>(_tareaService.GetAll()).ToList();
            var indexTareas = new IndexTareaVM();
            indexTareas.Tareas = tareas;
            return View(indexTareas);

        }

        [HttpGet]
        public ActionResult FiltrarTareas(FiltrarTareasVM filter)
        {
            var tareas = _tareaService.GetTareasFilter(filter);
            var model = new IndexTareaVM { Tareas = tareas };
            ViewBag.filter = filter;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Prioridades = new SelectList(_context.Prioridades, "Id", "Nombre");
            ViewBag.Estados = new SelectList(_context.Estados, "Id", "Nombre");
            ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nombre");
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tarea tarea)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    tarea.FechaCreacion = DateTime.Now.ToString();
                    tarea.UsuarioPropietarioId = 1;
                    _context.Tareas.Add(tarea);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Prioridades = new SelectList(_context.Prioridades, "Id", "Nombre", tarea.PrioridadId);
                ViewBag.Estados = new SelectList(_context.Estados, "Id", "Nombre", tarea.EstadoId);
                ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nombre", tarea.CategoriaId);
                ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", tarea.UsuarioAsignadoId);
                ViewBag.errMessage = "No  se pudo crear la tarea";
                return View(tarea);
            }
            catch (Exception ex)
            {

                ViewBag.Prioridades = new SelectList(_context.Prioridades, "Id", "Nombre", tarea.PrioridadId);
                ViewBag.Estados = new SelectList(_context.Estados, "Id", "Nombre", tarea.EstadoId);
                ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nombre", tarea.CategoriaId);
                ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", tarea.UsuarioAsignadoId);
                ViewBag.errMessage = "No  se pudo crear la tarea";
                return View(tarea);
            } 
        }

        public ActionResult Edit (int id)
        {
            var tarea = _tareaService.FindId(id);
            if(tarea != null)
            {
                ViewBag.Prioridades = new SelectList(_context.Prioridades, "Id", "Nombre", tarea.PrioridadId);
                ViewBag.Estados = new SelectList(_context.Estados, "Id", "Nombre", tarea.EstadoId);
                ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nombre", tarea.CategoriaId);
                ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", tarea.UsuarioAsignadoId);
                return View(tarea);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details (int id)
        {
            var tarea = _tareaService.FindId (id);
            if(tarea != null)
            {
                return View(tarea);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var tarea = _tareaService.FindId(id);
            if (tarea != null)
            {
                return View(tarea);
            }

            return RedirectToAction("Index");
        }
    }
}