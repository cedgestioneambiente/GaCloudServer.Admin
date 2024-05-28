using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinancialUnlockDate",
                table: "GaPreventiviObjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialUnlockUserId",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialUnlockUserName",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialUnlockDate",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "FinancialUnlockUserId",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "FinancialUnlockUserName",
                table: "GaPreventiviObjects");
        }
    }
}
