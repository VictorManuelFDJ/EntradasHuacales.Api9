using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntradasHuacales.api9.Migrations
{
    /// <inheritdoc />
    public partial class OtraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposHuacales",
                columns: new[] { "TipoId", "Descripcion", "Existencia" },
                values: new object[,]
                {
                    { 1, "Huacal verde pequeño", 0 },
                    { 2, "Huacal rojo pequeño", 0 },
                    { 3, "Huacal verde mediano", 0 },
                    { 4, "Huacal rojo mediano", 0 },
                    { 5, "Huacal verde Grande", 0 },
                    { 6, "Huacal rojo grande", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposHuacales",
                keyColumn: "TipoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposHuacales",
                keyColumn: "TipoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposHuacales",
                keyColumn: "TipoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposHuacales",
                keyColumn: "TipoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposHuacales",
                keyColumn: "TipoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TiposHuacales",
                keyColumn: "TipoId",
                keyValue: 6);
        }
    }
}
