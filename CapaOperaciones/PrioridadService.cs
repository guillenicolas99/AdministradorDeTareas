using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class PrioridadService:CRUDService<Prioridad>
    {
        private readonly AppDbContextContainer _context;

        public PrioridadService(AppDbContextContainer context) : base(context)
        {
            if (context == null)
                _context = new AppDbContextContainer();
            else
                _context = context;
        }

        public string ValidateBeforeCreate(Prioridad prioridad)
        {
            if (_context.Prioridades.Any(x => x.Nombre == prioridad.Nombre))
            {
                return "El nombre de la prioridad ya existe";
            }

            return string.Empty;
        }

        public string ValidateBeforeUpdate(Prioridad prioridad)
        {
            var prioridadDb = _context.Prioridades.Find(prioridad.Id);
            _context.Entry(prioridadDb).State = System.Data.Entity.EntityState.Detached;

            if (prioridadDb == null)
                return "La prioridad a modificar ya no existe en el sistema";

            if (prioridad.Nombre == prioridadDb.Nombre)
                return string.Empty;

            return ValidateBeforeCreate(prioridad);
        }

        public string ValidateBeforeDelete(int id)
        {
            var prioridadDb = _context.Prioridades.Find(id);
            _context.Entry(prioridadDb).State = System.Data.Entity.EntityState.Detached;
            if (prioridadDb == null)
                return "No se puede eliminar, la prioridad no existe.";
            if (prioridadDb.Tareas.Count > 0)
                return "No se puede eliminar debido que tiene tareas relacionadas";

            return string.Empty;
        }
    }
}
