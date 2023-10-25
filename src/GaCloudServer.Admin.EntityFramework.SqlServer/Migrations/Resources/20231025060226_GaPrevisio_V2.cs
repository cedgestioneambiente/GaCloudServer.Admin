using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPrevisio_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "GaPrevisioOdsLetture",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "GaPrevisioOdsLetture",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcDescription",
                table: "GaPrevisioOdsLetture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Retry",
                table: "GaPrevisioOdsLetture",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "GaPrevisioOdsLetture");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "GaPrevisioOdsLetture");

            migrationBuilder.DropColumn(
                name: "ProcDescription",
                table: "GaPrevisioOdsLetture");

            migrationBuilder.DropColumn(
                name: "Retry",
                table: "GaPrevisioOdsLetture");
        }
    }
}
