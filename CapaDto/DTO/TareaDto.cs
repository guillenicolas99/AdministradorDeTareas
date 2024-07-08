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
        //public string Descripcion { get; set; }
        //public string FechaCreacion { get; set; }
        public string FechaEstimadaEntrega { get; set; }
        public string Categorias { get; set; }
        public string Prioridades { get; set; }
        public string Estados { get; set; }
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
}
