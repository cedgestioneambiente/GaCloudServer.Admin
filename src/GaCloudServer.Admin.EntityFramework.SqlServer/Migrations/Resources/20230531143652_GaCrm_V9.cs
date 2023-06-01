using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContactCenterCalendar",
                table: "GaContactCenterTipiRichieste",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MagazzinoCalendar",
                table: "GaContactCenterTipiRichieste",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactCenterCalendar",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "MagazzinoCalendar",
                table: "GaContactCenterTipiRichieste");
        }
    }
}
