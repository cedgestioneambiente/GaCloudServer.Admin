using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Preventivi_V36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OmitLabelTypeOnPrint",
                table: "GaPreventiviObjectSections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SpotMode",
                table: "GaPreventiviObjects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OmitLabelTypeOnPrint",
                table: "GaPreventiviObjectSections");

            migrationBuilder.DropColumn(
                name: "SpotMode",
                table: "GaPreventiviObjects");
        }
    }
}
