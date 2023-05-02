using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContratti_V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileFolder",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "GaContrattiDocumenti");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileFolder",
                table: "GaContrattiDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "GaContrattiDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "GaContrattiDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileSize",
                table: "GaContrattiDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "GaContrattiDocumenti",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
