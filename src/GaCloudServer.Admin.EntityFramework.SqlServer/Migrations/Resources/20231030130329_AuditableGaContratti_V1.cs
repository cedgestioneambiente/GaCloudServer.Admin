using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaContratti_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContrattiUtentiOnPermessi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContrattiUtentiOnPermessi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContrattiUtentiOnPermessi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContrattiUtentiOnPermessi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContrattiTipologie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContrattiTipologie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContrattiTipologie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContrattiTipologie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContrattiSoggetti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContrattiSoggetti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContrattiSoggetti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContrattiSoggetti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContrattiServizi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContrattiServizi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContrattiServizi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContrattiServizi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContrattiPermessi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContrattiPermessi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContrattiPermessi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContrattiPermessi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContrattiModalitas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContrattiModalitas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContrattiModalitas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContrattiModalitas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContrattiDocumentiAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContrattiDocumentiAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContrattiDocumentiAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContrattiDocumentiAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContrattiDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContrattiDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContrattiDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContrattiDocumenti",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContrattiUtentiOnPermessi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContrattiUtentiOnPermessi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContrattiUtentiOnPermessi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContrattiUtentiOnPermessi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContrattiTipologie");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContrattiTipologie");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContrattiTipologie");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContrattiTipologie");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContrattiSoggetti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContrattiSoggetti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContrattiSoggetti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContrattiSoggetti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContrattiServizi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContrattiServizi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContrattiServizi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContrattiServizi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContrattiPermessi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContrattiPermessi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContrattiPermessi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContrattiPermessi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContrattiModalitas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContrattiModalitas");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContrattiModalitas");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContrattiModalitas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContrattiDocumentiAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContrattiDocumentiAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContrattiDocumentiAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContrattiDocumentiAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContrattiDocumenti");
        }
    }
}
