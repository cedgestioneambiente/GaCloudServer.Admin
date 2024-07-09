using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Intestatario",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntestatarioCfPiva",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntestatarioComune",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntestatarioIndirizzo",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intestatario",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "IntestatarioCfPiva",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "IntestatarioComune",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "IntestatarioIndirizzo",
                table: "GaCrmTickets");
        }
    }
}
