using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public int IdUsuarioFk { get; set; }
        public User User { get; set; }
        public DateTime FechaPedido { get; set; }
        public ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}