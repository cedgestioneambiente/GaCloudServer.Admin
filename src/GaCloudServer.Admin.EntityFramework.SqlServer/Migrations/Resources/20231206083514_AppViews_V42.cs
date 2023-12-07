using System;
using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AppViews_V42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPrevisioAnomalieLetture",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPrevisioAnomalieLetture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPrevisioAnomalieLetture",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPrevisioAnomalieLetture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaBackOfficeMigration, ScriptConsts.CREATE_ViewGaBackOffice_V7));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPrevisioAnomalieLetture");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPrevisioAnomalieLetture");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPrevisioAnomalieLetture");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPrevisioAnomalieLetture");
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaBackOfficeMigration, ScriptConsts.DROP_ViewGaBackOffice_V7));
        }
    }
}
