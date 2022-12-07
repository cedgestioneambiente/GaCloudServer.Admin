using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPresenze_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GgFerie",
                table: "GaPresenzeDipendenti");

            migrationBuilder.DropColumn(
                name: "GgPermessiCcnl",
                table: "GaPresenzeDipendenti");

            migrationBuilder.RenameColumn(
                name: "Abilitato",
                table: "GaPresenzeDipendenti",
                newName: "BancaOre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BancaOre",
                table: "GaPresenzeDipendenti",
                newName: "Abilitato");

            migrationBuilder.AddColumn<double>(
                name: "GgFerie",
                table: "GaPresenzeDipendenti",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GgPermessiCcnl",
                table: "GaPresenzeDipendenti",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
