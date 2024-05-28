using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataScadenza",
                table: "GaPreventiviObjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "GaPreventiviObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PriorityDesc",
                table: "GaPreventiviObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataScadenza",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "GaPreventiviObjects");

            migrationBuilder.DropColumn(
                name: "PriorityDesc",
                table: "GaPreventiviObjects");
        }
    }
}
