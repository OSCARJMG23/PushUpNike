using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class DetallePedidoDto
    {
        public int IdPedidoFk { get; set; }
        public int IdProductoFk { get; set; }
        public int Cantidad { get; set; }
    }
}