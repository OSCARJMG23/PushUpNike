using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetallePedido : BaseEntity
    {
        public int IdPedidoFk { get; set; }
        public Pedido Pedido { get; set; }
        public int IdProductoFk { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}