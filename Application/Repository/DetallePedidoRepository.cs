using Domain.Interfaces;
using Application.Repository;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository
{
    public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedidoRepository
    {
        private readonly ApiContext _context;

        public DetallePedidoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}