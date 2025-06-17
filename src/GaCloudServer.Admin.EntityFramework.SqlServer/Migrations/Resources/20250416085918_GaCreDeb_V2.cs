using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCreDeb_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileFolder",
                table: "GaCreDebObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "GaCreDebObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "GaCreDebObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileSize",
                table: "GaCreDebObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "GaCreDebObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileFolder",
                table: "GaCreDebObjects");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "GaCreDebObjects");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "GaCreDebObjects");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "GaCreDebObjects");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "GaCreDebObjects");
        }
    }
}
