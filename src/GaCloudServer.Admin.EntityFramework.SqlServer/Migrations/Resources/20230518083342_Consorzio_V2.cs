using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Consorzio_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ConsorzioRegistrazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Istat",
                table: "ConsorzioComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "ConsorzioComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Regione",
                table: "ConsorzioComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodiceRaggruppamento",
                table: "ConsorzioCers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropColumn(
                name: "Istat",
                table: "ConsorzioComuni");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "ConsorzioComuni");

            migrationBuilder.DropColumn(
                name: "Regione",
                table: "ConsorzioComuni");

            migrationBuilder.DropColumn(
                name: "CodiceRaggruppamento",
                table: "ConsorzioCers");
        }
    }
}
