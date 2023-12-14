using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            // Configuración de la entidad
            builder.ToTable("pedido");

            builder.HasOne(e => e.User)
                .WithMany(e => e.Pedidos)
                .HasForeignKey(e => e.IdUsuarioFk);
        }
    }
}