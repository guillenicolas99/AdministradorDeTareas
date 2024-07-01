using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministadorDeTareasWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContextContainer _context;
        private readonly UsuarioService _usuarioService;

        public UsuarioController()
        {
            _context = new AppDbContextContainer();
            _usuarioService = new UsuarioService(_context);
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var listaUsuarios = _usuarioService.GetAll();
            return View(listaUsuarios);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                var errMessage = _usuarioService.ValidateBeforeCreate(usuario);
                if (string.IsNullOrEmpty(errMessage))
                {
                    if (_usuarioService.Create(usuario))
                        return RedirectToAction("Index");
                    else
                    {
                        ViewBag.errorMessage = errMessage;
                        return View(usuario);
                    }
                }
                else
                {
                    ViewBag.errorMessage = errMessage;
                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = "Error al crear usuario, verifique los campos o contacte con el administrador";
                return View(usuario);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Usuario usuario = _usuarioService.FindId(id);
            if (usuario != null)
            {
                return View(usuario);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }

                var message = _usuarioService.ValidateBeforeUpdate(usuario);
                if (string.IsNullOrEmpty(message))
                {
                    _usuarioService.Update(usuario);
                    return RedirectToAction("Index");
                }

                ViewBag.errMessage = message;
                return View(usuario);
            }
            catch (Exception ex)
            {
                ViewBag.errMessage = "Error de servidor";
                return View(usuario);
            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var usuario = _usuarioService.FindId(id);
            if (usuario == null)
            {
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                var errorMessage = _usuarioService.ValidateBeforeDelete(usuario.Id);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (_usuarioService.Delete(usuario.Id))
                        return RedirectToAction("Index");

                    ViewBag.errMessage = "No se pudo eliminar";
                    return View(usuario);
                }

                ViewBag.errMessage = errorMessage;
                return View(usuario);
            }
            catch (Exception ex)
            {
                ViewBag.errMessage = "No se pudo eliminar";
                return View(usuario);
            }
        }
    }
}