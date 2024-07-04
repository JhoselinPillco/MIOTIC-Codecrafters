using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIOTIC.Migrations
{
    /// <inheritdoc />
    public partial class migraciones2 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Contratos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Contratos");

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
