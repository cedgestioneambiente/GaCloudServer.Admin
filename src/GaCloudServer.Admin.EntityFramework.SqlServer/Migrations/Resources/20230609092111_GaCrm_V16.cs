using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCessazione",
                table: "GaCrmEvents");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRichiesta",
                table: "GaCrmEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRichiesta",
                table: "GaCrmEvents");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCessazione",
                table: "GaCrmEvents",
                type: "datetime2",
                nullable: true);
        }
    }
}
