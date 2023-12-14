using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
    }
}