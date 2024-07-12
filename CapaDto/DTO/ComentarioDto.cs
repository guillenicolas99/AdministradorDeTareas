using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDto.DTO
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public int TareaID { get; set; }
        public int UsuarioID { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class TareaDetailsVM
    {
        public TareaDto Tarea { get; set; }
        public List<ComentarioDto> Comentarios { get; set; }
        public ComentarioDto NuevoComentario { get; set; }
    }

}
