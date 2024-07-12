using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDto.DTO
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class IndexCategoriaVM
    {
        public IndexCategoriaVM()
        {
            Categorias = new List<CategoriaDto>();
        }

        public List<CategoriaDto> Categorias { get; set; }

    }
}
