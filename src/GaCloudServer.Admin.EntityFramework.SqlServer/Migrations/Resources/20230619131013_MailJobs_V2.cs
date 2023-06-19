using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class MailJobs_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Link",
                table: "MailJobs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkDescription",
                table: "MailJobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkHref",
                table: "MailJobs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "MailJobs");

            migrationBuilder.DropColumn(
                name: "LinkDescription",
                table: "MailJobs");

            migrationBuilder.DropColumn(
                name: "LinkHref",
                table: "MailJobs");
        }
    }
}
