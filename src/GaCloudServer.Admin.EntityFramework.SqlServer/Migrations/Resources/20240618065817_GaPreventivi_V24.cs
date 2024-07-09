using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Analysis",
                table: "GaPreventiviDestinations");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "GaPreventiviDestinations",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Dangerous",
                table: "GaPreventiviDestinations",
                newName: "Ignore");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "GaPreventiviDestinations",
                newName: "Indirizzo");

            migrationBuilder.AddColumn<bool>(
                name: "Ignore",
                table: "GaPreventiviProducers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CfPiva",
                table: "GaPreventiviDestinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GaPreventiviDestinations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ignore",
                table: "GaPreventiviProducers");

            migrationBuilder.DropColumn(
                name: "CfPiva",
                table: "GaPreventiviDestinations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "GaPreventiviDestinations");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "GaPreventiviDestinations",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "Indirizzo",
                table: "GaPreventiviDestinations",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Ignore",
                table: "GaPreventiviDestinations",
                newName: "Dangerous");

            migrationBuilder.AddColumn<bool>(
                name: "Analysis",
                table: "GaPreventiviDestinations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
