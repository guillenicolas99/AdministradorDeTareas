using AdministadorDeTareasWeb.Models;
using CapaDato.Models;
using CapaDto.DTO;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace AdministadorDeTareasWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContextContainer _context;
        private readonly CategoriaService _categoriaService;

        public CategoriaController()
        {
            _context = new AppDbContextContainer();
            _categoriaService = new CategoriaService(_context);
        }

        // GET: Categoria
        public ActionResult Index()
        {
            var categorias = _categoriaService.GetAll().Select(x => new CategoriaDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
            }).ToList();

            var listaCategoria = _categoriaService.GetAll();
            return View(listaCategoria);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            var errMessage = _categoriaService.ValidateBeforeCreate(categoria);
            try
            {
                if (string.IsNullOrEmpty(errMessage))
                {
                    if(_categoriaService.Create(categoria))
                        return RedirectToAction("Index");
                    else
                        return View(categoria);
                }
                else
                {
                    ViewBag.errorMessage = errMessage;
                    return View(categoria);
                }
            }catch(Exception ex)
            {
                ViewBag.errorMessage = errMessage;
                return View(categoria);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Categoria categoria = _categoriaService.FindId(id);
            if(categoria != null)
            {
                return View(categoria);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(categoria);
                }

                var message = _categoriaService.ValidateBeforeUpdate(categoria);
                if (string.IsNullOrEmpty(message))
                {
                    _categoriaService.Update(categoria);
                    return RedirectToAction("Index");
                }

                ViewBag.errMessage = message;
                return View(categoria);
            }
            catch(Exception ex)
            {
                ViewBag.errMessage = "Error de servidor";
                return View(categoria);
            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var cateoria = _categoriaService.FindId(id);
            if (cateoria == null)
            {
                return RedirectToAction("Index");
            }

            return View(cateoria);
        }

        [HttpPost]
        public ActionResult Delete(Categoria categoria)
        {
            try
            {
                var errorMessage = _categoriaService.ValidateBeforeDelete(categoria.Id);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (_categoriaService.Delete(categoria.Id))
                        return RedirectToAction("Index");
                    
                    ViewBag.errMessage = "No se pudo eliminar";
                    return View(categoria);
                }

                ViewBag.errMessage = errorMessage;
                return View(categoria);
            }
            catch(Exception ex)
            {
                ViewBag.errMessage = "No se pudo eliminar";
                return View(categoria);
            }
        }
    }
}