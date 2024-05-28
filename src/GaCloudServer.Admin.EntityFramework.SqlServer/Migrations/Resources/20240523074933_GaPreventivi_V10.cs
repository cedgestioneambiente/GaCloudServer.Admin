using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinancialUnlockRequestDate",
                table: "GaPreventiviObjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialUnlockRequestUserId",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialUnlockRequestUserName",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialUnlockRequestDate",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "FinancialUnlockRequestUserId",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "FinancialUnlockRequestUserName",
                table: "GaPreventiviObjects");
        }
    }
}
