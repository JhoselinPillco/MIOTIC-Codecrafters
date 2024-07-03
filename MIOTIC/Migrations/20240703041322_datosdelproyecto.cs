using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIOTIC.Migrations
{
    /// <inheritdoc />
    public partial class datosdelproyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Contratos",
                type: "date",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Contratos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "date");
        }
    }
}
