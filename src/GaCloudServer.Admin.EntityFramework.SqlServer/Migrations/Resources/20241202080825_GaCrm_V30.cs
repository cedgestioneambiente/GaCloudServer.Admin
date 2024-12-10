using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IntestatarioIndirizzoOperativo",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntestatarioIndirizzoOperativo",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntestatarioIndirizzoOperativo",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "IntestatarioIndirizzoOperativo",
                table: "GaCrmTickets");
        }
    }
}
