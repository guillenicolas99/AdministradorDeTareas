﻿using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: Tarea
        public ActionResult Index()
        {
            var listaTareas = _tareaService.GetAll();
            return View(listaTareas);
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
    }
}