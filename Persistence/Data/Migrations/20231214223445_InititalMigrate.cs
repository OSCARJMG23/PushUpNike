using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InititalMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Titulo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagen = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<double>(type: "Double", nullable: false),
                    IdCategoriaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_categoria_IdCategoriaFk",
                        column: x => x.IdCategoriaFk,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokem_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuarioFk = table.Column<int>(type: "int", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_user_IdUsuarioFk",
                        column: x => x.IdUsuarioFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_userRol_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detallePedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPedidoFk = table.Column<int>(type: "int", nullable: false),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallePedido_pedido_IdPedidoFk",
                        column: x => x.IdPedidoFk,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallePedido_producto_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Abrigos" },
                    { 2, "Camisetas" },
                    { 3, "Pantalones" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "producto",
                columns: new[] { "Id", "IdCategoriaFk", "IdProducto", "Imagen", "Precio", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, "abrigo-01", "./img/abrigos/01.jpg", 1000.0, "Abrigo 01" },
                    { 2, 1, "abrigo-02", "./img/abrigos/02.jpg", 1000.0, "Abrigo 02" },
                    { 3, 1, "abrigo-03", "./img/abrigos/03.jpg", 1000.0, "Abrigo 03" },
                    { 4, 1, "abrigo-04", "./img/abrigos/04.jpg", 1000.0, "Abrigo 04" },
                    { 5, 1, "abrigo-05", "./img/abrigos/05.jpg", 1000.0, "Abrigo 05" },
                    { 6, 2, "camiseta-01", "./img/camisetas/01.jpg", 1000.0, "Camiseta 01" },
                    { 7, 2, "camiseta-02", "./img/camisetas/02.jpg", 1000.0, "Camiseta 02" },
                    { 8, 2, "camiseta-03", "./img/camisetas/03.jpg", 1000.0, "Camiseta 03" },
                    { 9, 2, "camiseta-04", "./img/camisetas/04.jpg", 1000.0, "Camiseta 04" },
                    { 10, 2, "camiseta-05", "./img/camisetas/05.jpg", 1000.0, "Camiseta 05" },
                    { 11, 2, "camiseta-06", "./img/camisetas/06.jpg", 1000.0, "Camiseta 06" },
                    { 12, 2, "camiseta-07", "./img/camisetas/07.jpg", 1000.0, "Camiseta 07" },
                    { 13, 2, "camiseta-08", "./img/camisetas/08.jpg", 1000.0, "Camiseta 08" },
                    { 14, 3, "pantalon-01", "./img/pantalones/01.jpg", 1000.0, "Pantalón 01" },
                    { 15, 3, "pantalon-02", "./img/pantalones/02.jpg", 1000.0, "Pantalón 02" },
                    { 16, 3, "pantalon-03", "./img/pantalones/03.jpg", 1000.0, "Pantalón 03" },
                    { 17, 3, "pantalon-04", "./img/pantalones/04.jpg", 1000.0, "Pantalón 04" },
                    { 18, 3, "pantalon-05", "./img/pantalones/05.jpg", 1000.0, "Pantalón 05" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokem_UserId",
                table: "RefreshTokem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedido_IdPedidoFk",
                table: "detallePedido",
                column: "IdPedidoFk");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedido_IdProductoFk",
                table: "detallePedido",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_IdUsuarioFk",
                table: "pedido",
                column: "IdUsuarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_producto_IdCategoriaFk",
                table: "producto",
                column: "IdCategoriaFk");

            migrationBuilder.CreateIndex(
                name: "IX_producto_IdProducto",
                table: "producto",
                column: "IdProducto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RolId",
                table: "userRol",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokem");

            migrationBuilder.DropTable(
                name: "detallePedido");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
