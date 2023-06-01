using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CfPiva",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumCiv",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Via",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CfPiva",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "NumCiv",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "Via",
                table: "GaCrmTickets");
        }
    }
}
