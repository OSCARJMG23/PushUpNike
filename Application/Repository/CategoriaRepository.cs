using Domain.Interfaces;
using Application.Repository;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        private readonly ApiContext _context;

        public CategoriaRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}