using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms_majiInnovator.Migrations
{
    /// <inheritdoc />
    public partial class _106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagenesCelular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaImagen = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesCelular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagenesCelular_ModelosCelular_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "ModelosCelular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagenesCelular_ModeloId",
                table: "ImagenesCelular",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenesCelular");
        }
    }
}
