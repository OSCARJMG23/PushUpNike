using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRolRepository Roles { get; }
        IUserRepository Users { get; }
        ICategoriaRepository Categorias { get; }
        IDetallePedidoRepository DetallePedidos { get; }
        IPedidoRepository Pedidos { get; }
        IProductoRepository Productos { get; }

        Task<int> SaveAsync();
    }
}