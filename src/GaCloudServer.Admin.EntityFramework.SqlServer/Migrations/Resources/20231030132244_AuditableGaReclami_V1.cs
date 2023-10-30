using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaReclami_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaReclamiTipiOrigini",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaReclamiTipiOrigini",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaReclamiTipiOrigini",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaReclamiTipiOrigini",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaReclamiTipiAzioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaReclamiTipiAzioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaReclamiTipiAzioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaReclamiTipiAzioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaReclamiTempiRisposte",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaReclamiTempiRisposte",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaReclamiTempiRisposte",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaReclamiTempiRisposte",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaReclamiStati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaReclamiStati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaReclamiStati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaReclamiStati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaReclamiMittenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaReclamiMittenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaReclamiMittenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaReclamiMittenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaReclamiDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaReclamiDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaReclamiDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaReclamiDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaReclamiAzioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaReclamiAzioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaReclamiAzioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaReclamiAzioni",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaReclamiTipiOrigini");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaReclamiTipiOrigini");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaReclamiTipiOrigini");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaReclamiTipiOrigini");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaReclamiTipiAzioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaReclamiTipiAzioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaReclamiTipiAzioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaReclamiTipiAzioni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaReclamiTempiRisposte");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaReclamiTempiRisposte");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaReclamiTempiRisposte");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaReclamiTempiRisposte");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaReclamiStati");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaReclamiStati");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaReclamiStati");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaReclamiStati");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaReclamiMittenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaReclamiMittenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaReclamiMittenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaReclamiMittenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaReclamiDocumenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaReclamiDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaReclamiDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaReclamiDocumenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaReclamiAzioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaReclamiAzioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaReclamiAzioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaReclamiAzioni");
        }
    }
}
