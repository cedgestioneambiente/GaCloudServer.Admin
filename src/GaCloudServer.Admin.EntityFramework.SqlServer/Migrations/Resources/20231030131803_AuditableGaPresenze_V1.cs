using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaPresenze_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeTipiOre",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeTipiOre",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeTipiOre",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeTipiOre",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeStatiRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeStatiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeStatiRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeStatiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeResponsabiliOnSettori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeResponsabiliOnSettori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeResponsabiliOnSettori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeResponsabiliOnSettori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeResponsabili",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeResponsabili",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeResponsabili",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeResponsabili",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeProfili",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeProfili",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeProfili",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeProfili",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeOrariGiornate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeOrariGiornate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeOrariGiornate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeOrariGiornate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeOrari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeOrari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeOrari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeOrari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeDipendenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeDipendenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeDipendenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeDipendenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeDateEscluse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeDateEscluse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeDateEscluse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeDateEscluse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPresenzeBancheOreUtilizzi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPresenzeBancheOreUtilizzi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPresenzeBancheOreUtilizzi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPresenzeBancheOreUtilizzi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeTipiOre");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeTipiOre");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeTipiOre");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeTipiOre");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeStatiRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeStatiRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeStatiRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeStatiRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeResponsabiliOnSettori");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeResponsabiliOnSettori");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeResponsabiliOnSettori");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeResponsabiliOnSettori");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeResponsabili");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeResponsabili");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeResponsabili");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeResponsabili");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeProfili");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeProfili");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeProfili");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeProfili");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeOrariGiornate");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeOrariGiornate");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeOrariGiornate");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeOrariGiornate");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeOrari");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeOrari");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeOrari");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeOrari");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeDipendenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeDipendenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeDipendenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeDipendenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeDateEscluse");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeDateEscluse");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeDateEscluse");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeDateEscluse");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPresenzeBancheOreUtilizzi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPresenzeBancheOreUtilizzi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPresenzeBancheOreUtilizzi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPresenzeBancheOreUtilizzi");
        }
    }
}
