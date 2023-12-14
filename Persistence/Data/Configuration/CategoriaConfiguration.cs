using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Configuración de la entidad
            builder.ToTable("categoria");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasData(
                new Categoria { Id = 1, Nombre = "Abrigos" },
                new Categoria { Id = 2, Nombre = "Camisetas" },
                new Categoria { Id = 3, Nombre = "Pantalones" }
            );
        }
    }
}