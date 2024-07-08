using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDto.DTO
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string FechaEstimadaEntrega { get; set; }
        public string Categoria { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public string UsuarioCreador { get; set; }
        public string UsuarioAsignado { get; set; }
    }

    public class IndexTareaVM
    {
        public IndexTareaVM()
        {
            Tareas = new List<TareaDto>();
        }
        public List<TareaDto> Tareas { get; set; }
    }

    public class FiltrarTareasVM
    {
        public string Titulo { get; set; }
        public string EstadoID { get; set; }
        public string PrioridadID { get; set; }
        public string CategoriaID { get; set; }
        public string ResponsableID { get; set; }
    }
}
