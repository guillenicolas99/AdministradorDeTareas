using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class UsuarioService : CRUDService<Usuario>
    {
        private readonly AppDbContextContainer _context;

        public UsuarioService(AppDbContextContainer context) :base(context)
        {
            if (context == null)
                _context = new AppDbContextContainer();
            else
                _context = context;
        }

        public string ValidateBeforeCreate(Usuario usuario)
        {
            if (_context.Usuarios.Any(x => x.Correo == usuario.Correo))
            {
                return "Este correo ya está en uso";
            }

            return string.Empty;
        }

        public string ValidateBeforeUpdate(Usuario usuario)
        {
            var usuarioDb = _context.Usuarios.Find(usuario.Id);
            _context.Entry(usuarioDb).State = System.Data.Entity.EntityState.Detached;

            if (usuarioDb == null)
                return "Usuario no existe.";

            if (usuario.Correo== usuarioDb.Correo)
                return string.Empty;

            return ValidateBeforeCreate(usuario);
        }

        public string ValidateBeforeDelete(int id)
        {
            var usuarioDb = _context.Usuarios.Find(id);
            _context.Entry(usuarioDb).State = System.Data.Entity.EntityState.Detached;
            if (usuarioDb == null)
                return "No se puede eliminar, la categoría no existe.";
            if (usuarioDb.TareaAsignado.Count > 0 || usuarioDb.TareaPropietario.Count > 0)
                return "No se puede eliminar debido que tiene tareas relacionadas";

            return string.Empty;
        }
    }
}
