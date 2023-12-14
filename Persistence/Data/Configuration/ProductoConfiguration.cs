using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            // Configuración de la entidad
            builder.ToTable("producto");

            builder.HasIndex(e=>e.IdProducto).IsUnique();
            builder.Property(e => e.IdProducto)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Imagen)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Precio)
                .IsRequired()
                .HasColumnType("Double");
            
            builder.HasOne(e => e.Categoria)
                .WithMany(e => e.Productos)
                .HasForeignKey(e => e.IdCategoriaFk);

            builder.HasData(
            
            new Producto
            {
                Id = 1,
                IdProducto = "abrigo-01",
                Titulo = "Abrigo 01",
                Imagen = "./img/abrigos/01.jpg",
                Precio = 1000,
                IdCategoriaFk = 1 
            },
            new Producto
            {
                Id = 2,
                IdProducto = "abrigo-02",
                Titulo = "Abrigo 02",
                Imagen = "./img/abrigos/02.jpg",
                Precio = 1000,
                IdCategoriaFk = 1
            },
            new Producto
            {
                Id = 3,
                IdProducto = "abrigo-03",
                Titulo = "Abrigo 03",
                Imagen = "./img/abrigos/03.jpg",
                Precio = 1000,
                IdCategoriaFk = 1
            },
            new Producto
            {
                Id = 4,
                IdProducto = "abrigo-04",
                Titulo = "Abrigo 04",
                Imagen = "./img/abrigos/04.jpg",
                Precio = 1000,
                IdCategoriaFk = 1
            },
            new Producto
            {
                Id = 5,
                IdProducto = "abrigo-05",
                Titulo = "Abrigo 05",
                Imagen = "./img/abrigos/05.jpg",
                Precio = 1000,
                IdCategoriaFk = 1
            },

            new Producto
            {
                Id = 6,
                IdProducto = "camiseta-01",
                Titulo = "Camiseta 01",
                Imagen = "./img/camisetas/01.jpg",
                Precio = 1000,
                IdCategoriaFk = 2 
            },
            new Producto
            {
                Id = 7,
                IdProducto = "camiseta-02",
                Titulo = "Camiseta 02",
                Imagen = "./img/camisetas/02.jpg",
                Precio = 1000,
                IdCategoriaFk = 2
            },
            new Producto
            {
                Id = 8,
                IdProducto = "camiseta-03",
                Titulo = "Camiseta 03",
                Imagen = "./img/camisetas/03.jpg",
                Precio = 1000,
                IdCategoriaFk = 2
            },
            new Producto
            {
                Id = 9,
                IdProducto = "camiseta-04",
                Titulo = "Camiseta 04",
                Imagen = "./img/camisetas/04.jpg",
                Precio = 1000,
                IdCategoriaFk = 2
            },
            new Producto
            {
                Id = 10,
                IdProducto = "camiseta-05",
                Titulo = "Camiseta 05",
                Imagen = "./img/camisetas/05.jpg",
                Precio = 1000,
                IdCategoriaFk = 2
            },
            new Producto
            {
                Id = 11,
                IdProducto = "camiseta-06",
                Titulo = "Camiseta 06",
                Imagen = "./img/camisetas/06.jpg",
                Precio = 1000,
                IdCategoriaFk = 2
            },
            new Producto
            {
                Id = 12,
                IdProducto = "camiseta-07",
                Titulo = "Camiseta 07",
                Imagen = "./img/camisetas/07.jpg",
                Precio = 1000,
                IdCategoriaFk = 2
            },
            new Producto
            {
                Id = 13,
                IdProducto = "camiseta-08",
                Titulo = "Camiseta 08",
                Imagen = "./img/camisetas/08.jpg",
                Precio = 1000,
                IdCategoriaFk = 2
            },

            new Producto
            {
                Id = 14,
                IdProducto = "pantalon-01",
                Titulo = "Pantalón 01",
                Imagen = "./img/pantalones/01.jpg",
                Precio = 1000,
                IdCategoriaFk = 3 
            },
            new Producto
            {
                Id = 15,
                IdProducto = "pantalon-02",
                Titulo = "Pantalón 02",
                Imagen = "./img/pantalones/02.jpg",
                Precio = 1000,
                IdCategoriaFk = 3
            },
            new Producto
            {
                Id = 16,
                IdProducto = "pantalon-03",
                Titulo = "Pantalón 03",
                Imagen = "./img/pantalones/03.jpg",
                Precio = 1000,
                IdCategoriaFk = 3
            },
            new Producto
            {
                Id = 17,
                IdProducto = "pantalon-04",
                Titulo = "Pantalón 04",
                Imagen = "./img/pantalones/04.jpg",
                Precio = 1000,
                IdCategoriaFk = 3
            },
            new Producto
            {
                Id = 18,
                IdProducto = "pantalon-05",
                Titulo = "Pantalón 05",
                Imagen = "./img/pantalones/05.jpg",
                Precio = 1000,
                IdCategoriaFk = 3
            }
        );
        }
    }
}