using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class CategoriaService : CRUDService<Categoria>
    {
        private readonly AppDbContextContainer _context;

        public CategoriaService(AppDbContextContainer context) : base(context)
        {
            if (context == null) 
                _context = new AppDbContextContainer();
            else
                _context = context;
        }

        public string ValidateBeforeCreate (Categoria categoria)
        {
            if (_context.Categorias.Any(x => x.Nombre == categoria.Nombre))
            {
                return "El nombre de la categoría ya existe";
            }

            return string.Empty;
        }

        public string ValidateBeforeUpdate(Categoria categoria)
        {
            var categoriaDb = _context.Categorias.Find(categoria.Id);
            _context.Entry(categoriaDb).State = System.Data.Entity.EntityState.Detached;

            if (categoriaDb == null)
                return "La categoría a modificar ya no existe en el sistema";

            if (categoria.Nombre == categoriaDb.Nombre)
                return string.Empty;

            return ValidateBeforeCreate(categoria);
        }

        public string ValidateBeforeDelete (int id)
        {
            var categoriaDb = _context.Categorias.Find(id);
            _context.Entry(categoriaDb).State = System.Data.Entity.EntityState.Detached;
            if (categoriaDb == null)
                return "No se puede eliminar, la categoría no existe.";
            if (categoriaDb.Tareas.Count > 0)
                return "No se puede eliminar debido que tiene tareas relacionadas";

            return string.Empty;
        }
    }
}
