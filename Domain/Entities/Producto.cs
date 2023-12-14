using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto : BaseEntity
    {
        public string IdProducto { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public double Precio { get; set; }
        public int IdCategoriaFk { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}