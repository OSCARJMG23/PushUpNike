using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PedidoDto
    {
        public int IdUsuarioFk { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}