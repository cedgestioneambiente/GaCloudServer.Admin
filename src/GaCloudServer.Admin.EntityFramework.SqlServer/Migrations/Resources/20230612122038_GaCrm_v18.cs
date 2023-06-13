using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_v18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categ",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "CategDesc",
                table: "GaCrmEvents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categ",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategDesc",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
