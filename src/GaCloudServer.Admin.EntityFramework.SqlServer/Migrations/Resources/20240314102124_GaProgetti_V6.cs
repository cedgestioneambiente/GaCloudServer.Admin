using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaProgetti_V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CountDays",
                table: "GaProgettiJobs",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Internal",
                table: "GaProgettiJobs",
                type: "bit",
                nullable: true,
                defaultValue:false);

            migrationBuilder.AddColumn<double>(
                name: "TotalDays",
                table: "GaProgettiJobs",
                type: "float",
                nullable: true,
                defaultValue:0);

            migrationBuilder.AddColumn<double>(
                name: "WorkedDays",
                table: "GaProgettiJobs",
                type: "float",
                nullable: true,
                defaultValue:0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountDays",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Internal",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "TotalDays",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "WorkedDays",
                table: "GaProgettiJobs");
        }
    }
}
