using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class TareaService : CRUDService<Tarea>
    {
        private readonly AppDbContextContainer _context;
        public TareaService(AppDbContextContainer context) : base(context) 
        {
            if (context == null)
                _context = new AppDbContextContainer();
            else
                _context = context;
        }


    }
}
