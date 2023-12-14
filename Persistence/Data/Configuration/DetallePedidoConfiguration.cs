using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            // Configuración de la entidad
            builder.ToTable("detallePedido");

            builder.Property(e => e.Cantidad)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(e => e.Pedido)
                .WithMany(e => e.DetallePedidos)
                .HasForeignKey(e => e.IdPedidoFk);
            
            builder.HasOne(e => e.Producto)
                .WithMany(e => e.DetallePedidos)
                .HasForeignKey(e => e.IdProductoFk);
        }
    }
}