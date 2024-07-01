using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class EstadoService : CRUDService<Estado>
    {
        private readonly AppDbContextContainer _context;

        public EstadoService( AppDbContextContainer context) : base(context)
        {
            if(context == null)
                _context = new AppDbContextContainer();
            else
                _context = context;
        }

        public string ValidateBeforeCreate(Estado estado)
        {

            if(_context.Estados.Any(x => x.Nombre == estado.Nombre))
                return "El nombre de estado ya existe";

            return string.Empty;
        }

        public string ValidateBeforeUpdate(Estado estado)
        {
            var estadoDb = _context.Estados.Find(estado.Id);
            _context.Entry(estadoDb).State = System.Data.Entity.EntityState.Detached;

            if (estadoDb == null)
                return "El esatado, ya no existe en base de datos";
            
            if(estado.Nombre == estadoDb.Nombre)
                return string.Empty;
            
            return ValidateBeforeCreate(estado);
        }

        public string ValidateBeforeDelete(int id)
        {
            var estadoDb = _context.Estados.Find(id);
            _context.Entry(estadoDb).State = System.Data.Entity.EntityState.Detached;

            if (estadoDb == null)
                return "No se puede eliminar, el estado ya no existe";

            if(estadoDb.Tareas.Count > 0)
                return "No se puede eliminar debido que tiene tareas relacionadas";

            return string.Empty;
        }
    }
}
