using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaBackOffice_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnnoRif",
                table: "GaBackOfficeRecipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "GaBackOfficeRecipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note2",
                table: "GaBackOfficeRecipes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnoRif",
                table: "GaBackOfficeRecipes");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "GaBackOfficeRecipes");

            migrationBuilder.DropColumn(
                name: "Note2",
                table: "GaBackOfficeRecipes");
        }
    }
}
