using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaProgetti_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaProgettiWorkSettings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaProgettiWorkSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaProgettiWorkSettings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaProgettiWorkSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaProgettiWorks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaProgettiWorks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaProgettiWorks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaProgettiWorks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaProgettiJobTask",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaProgettiJobTask",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaProgettiJobTask",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaProgettiJobTask",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaProgettiJobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaProgettiJobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaProgettiJobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaProgettiJobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaProgettiJobAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaProgettiJobAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaProgettiJobAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaProgettiJobAllegati",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaProgettiWorkSettings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaProgettiWorkSettings");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaProgettiWorkSettings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaProgettiWorkSettings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaProgettiWorks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaProgettiWorks");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaProgettiWorks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaProgettiWorks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaProgettiJobTask");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaProgettiJobTask");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaProgettiJobTask");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaProgettiJobTask");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaProgettiJobAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaProgettiJobAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaProgettiJobAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaProgettiJobAllegati");
        }
    }
}
