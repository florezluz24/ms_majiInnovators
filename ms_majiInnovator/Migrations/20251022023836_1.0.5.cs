using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms_majiInnovator.Migrations
{
    /// <inheritdoc />
    public partial class _105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoTelefono");

            migrationBuilder.CreateTable(
                name: "MarcasCelular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Activa = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcasCelular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelosCelular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelosCelular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelosCelular_MarcasCelular_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "MarcasCelular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicasCelular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModeloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicasCelular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaracteristicasCelular_ModelosCelular_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "ModelosCelular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicasCelular_ModeloId",
                table: "CaracteristicasCelular",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicasCelular_Nombre_ModeloId",
                table: "CaracteristicasCelular",
                columns: new[] { "Nombre", "ModeloId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarcasCelular_Nombre",
                table: "MarcasCelular",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelosCelular_MarcaId",
                table: "ModelosCelular",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelosCelular_Nombre_MarcaId",
                table: "ModelosCelular",
                columns: new[] { "Nombre", "MarcaId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaracteristicasCelular");

            migrationBuilder.DropTable(
                name: "ModelosCelular");

            migrationBuilder.DropTable(
                name: "MarcasCelular");

            migrationBuilder.CreateTable(
                name: "CatalogoTelefono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Camara = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ram = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoTelefono", x => x.Id);
                });
        }
    }
}
