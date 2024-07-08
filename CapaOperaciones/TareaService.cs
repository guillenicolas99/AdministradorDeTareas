using CapaDato.Models;
using CapaDto.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<TareaDto> GetTareasFilter(FiltrarTareasVM filter)
        {
            var paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@Titulo", string.IsNullOrEmpty(filter.Titulo) ? DBNull.Value : (object)filter.Titulo));
            paramList.Add(new SqlParameter("@EstadoID", string.IsNullOrEmpty(filter.EstadoID) ? DBNull.Value : (object)filter.EstadoID));
            paramList.Add(new SqlParameter("@PrioridadID", string.IsNullOrEmpty(filter.PrioridadID) ? DBNull.Value : (object)filter.PrioridadID));
            paramList.Add(new SqlParameter("@CategoriaID", string.IsNullOrEmpty(filter.CategoriaID) ? DBNull.Value : (object)filter.CategoriaID));
            paramList.Add(new SqlParameter("@ResponsableID", string.IsNullOrEmpty(filter.ResponsableID) ? DBNull.Value : (object)filter.ResponsableID));

            var paramsName = string.Join(",", paramList.Select(p => p.ParameterName));

            //var tareas = _context.Database.SqlQuery<TareaDto>("[dbo].[FiltrarTareas]" + paramList.ToArray()).ToList();

            var tareas = _context.Database.SqlQuery<TareaDto>(
                "[dbo].[FiltrarTareas] @Titulo, @EstadoID, @PrioridadID, @CategoriaID, @ResponsableID",
                paramList.ToArray()
            ).ToList();


            return tareas;
        }


    }
}
