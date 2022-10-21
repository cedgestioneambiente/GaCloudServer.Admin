using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Identity
{
    public partial class _191020221444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfficePhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficePhoneNumber",
                table: "Users");
        }
    }
}
