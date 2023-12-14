using Domain.Interfaces;
using Application.Repository;
using Domain.Entities;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly ApiContext _context;

        public ProductoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Producto>> GetAllAsync()
        {
           var productos = await _context.Productos
           .Include(e=>e.Categoria)
           .ToListAsync();

           return productos;
        }
    }
}