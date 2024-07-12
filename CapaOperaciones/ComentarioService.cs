using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class ComentarioService : CRUDService<Comentario>
    {
        private readonly AppDbContextContainer _context;

        public ComentarioService(AppDbContextContainer context) : base(context)
        {
            if (context == null)
                _context = new AppDbContextContainer();
            else
                _context = context;
        }
    }
}
