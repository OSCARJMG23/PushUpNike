using Domain.Interfaces;
using Application.Repository;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        private readonly ApiContext _context;

        public PedidoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}