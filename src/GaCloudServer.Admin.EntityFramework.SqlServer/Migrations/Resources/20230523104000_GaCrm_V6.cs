using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Duration",
                table: "GaCrmEvents",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "GaCrmEventAreas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "GaCrmEventAreas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "GaCrmEventAreas");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "GaCrmEventAreas");
        }
    }
}
