using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Via",
                table: "GaPreventiviObjects",
                newName: "IntestatarioIndirizzo");

            migrationBuilder.RenameColumn(
                name: "NumCiv",
                table: "GaPreventiviObjects",
                newName: "IntestatarioComune");

            migrationBuilder.RenameColumn(
                name: "Comune",
                table: "GaPreventiviObjects",
                newName: "IntestatarioCfPiva");

            migrationBuilder.RenameColumn(
                name: "CodSdi",
                table: "GaPreventiviObjects",
                newName: "Intestatario");

            migrationBuilder.RenameColumn(
                name: "CfPiva",
                table: "GaPreventiviObjects",
                newName: "ClienteIndirizzo");

            migrationBuilder.AddColumn<string>(
                name: "ClienteCfPiva",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClienteCodSdi",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClienteComune",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteCfPiva",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "ClienteCodSdi",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "ClienteComune",
                table: "GaPreventiviObjects");

            migrationBuilder.RenameColumn(
                name: "IntestatarioIndirizzo",
                table: "GaPreventiviObjects",
                newName: "Via");

            migrationBuilder.RenameColumn(
                name: "IntestatarioComune",
                table: "GaPreventiviObjects",
                newName: "NumCiv");

            migrationBuilder.RenameColumn(
                name: "IntestatarioCfPiva",
                table: "GaPreventiviObjects",
                newName: "Comune");

            migrationBuilder.RenameColumn(
                name: "Intestatario",
                table: "GaPreventiviObjects",
                newName: "CodSdi");

            migrationBuilder.RenameColumn(
                name: "ClienteIndirizzo",
                table: "GaPreventiviObjects",
                newName: "CfPiva");
        }
    }
}
