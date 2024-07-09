using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CausalePag770s",
                table: "GaPreventiviObjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IndirizzoFattura",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndirizzoSede",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CausalePag770s",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "IndirizzoFattura",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "IndirizzoSede",
                table: "GaPreventiviObjects");
        }
    }
}
