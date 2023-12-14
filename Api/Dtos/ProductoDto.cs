using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ProductoDto
    {
        public string IdProducto { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public double Precio { get; set; }
        public int IdCategoriaFk { get; set; }
        public CategoriaDto Categoria { get; set; }
    }
}