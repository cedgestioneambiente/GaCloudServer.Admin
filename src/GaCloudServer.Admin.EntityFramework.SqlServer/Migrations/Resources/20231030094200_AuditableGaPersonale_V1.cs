using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaPersonale_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleSchedeConsegneDettagli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleSchedeConsegneDettagli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleSchedeConsegneDettagli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleSchedeConsegneDettagli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleSchedeConsegne",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleSchedeConsegne",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleSchedeConsegne",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleSchedeConsegne",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleScadenzeTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleScadenzeTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleScadenzeTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleScadenzeTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleScadenzeDettagli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleScadenzeDettagli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleScadenzeDettagli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleScadenzeDettagli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleScadenze",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleScadenze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleScadenze",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleScadenze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleSanzioniMotivi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleSanzioniMotivi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleSanzioniMotivi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleSanzioniMotivi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleSanzioniDescrizioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleSanzioniDescrizioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleSanzioniDescrizioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleSanzioniDescrizioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleSanzioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleSanzioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleSanzioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleSanzioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleRetributiviTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleRetributiviTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleRetributiviTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleRetributiviTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleRetributivi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleRetributivi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleRetributivi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleRetributivi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleQualifiche",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleQualifiche",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleQualifiche",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleQualifiche",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleDipendenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleDipendenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleDipendenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleDipendenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleAssunzioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleAssunzioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleAssunzioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleAssunzioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleArticoliTipologie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleArticoliTipologie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleArticoliTipologie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleArticoliTipologie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleArticoliModelli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleArticoliModelli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleArticoliModelli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleArticoliModelli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleArticoliDpis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleArticoliDpis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleArticoliDpis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleArticoliDpis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleArticoli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleArticoli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleArticoli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleArticoli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleAbilitazioniTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleAbilitazioniTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleAbilitazioniTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleAbilitazioniTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaPersonaleAbilitazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaPersonaleAbilitazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaPersonaleAbilitazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaPersonaleAbilitazioni",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleSchedeConsegneDettagli");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleSchedeConsegneDettagli");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleSchedeConsegneDettagli");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleSchedeConsegneDettagli");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleSchedeConsegne");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleSchedeConsegne");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleSchedeConsegne");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleSchedeConsegne");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleScadenzeTipi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleScadenzeTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleScadenzeTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleScadenzeTipi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleScadenzeDettagli");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleScadenzeDettagli");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleScadenzeDettagli");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleScadenzeDettagli");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleScadenze");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleScadenze");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleScadenze");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleScadenze");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleSanzioniMotivi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleSanzioniMotivi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleSanzioniMotivi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleSanzioniMotivi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleSanzioniDescrizioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleSanzioniDescrizioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleSanzioniDescrizioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleSanzioniDescrizioni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleSanzioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleSanzioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleSanzioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleSanzioni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleRetributiviTipi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleRetributiviTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleRetributiviTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleRetributiviTipi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleRetributivi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleRetributivi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleRetributivi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleRetributivi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleQualifiche");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleQualifiche");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleQualifiche");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleQualifiche");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleDipendenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleDipendenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleDipendenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleDipendenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleAssunzioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleAssunzioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleAssunzioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleAssunzioni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleArticoliTipologie");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleArticoliTipologie");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleArticoliTipologie");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleArticoliTipologie");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleArticoliModelli");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleArticoliModelli");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleArticoliModelli");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleArticoliModelli");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleArticoliDpis");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleArticoliDpis");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleArticoliDpis");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleArticoliDpis");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleArticoli");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleArticoli");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleArticoli");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleArticoli");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleAbilitazioniTipi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleAbilitazioniTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleAbilitazioniTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleAbilitazioniTipi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaPersonaleAbilitazioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaPersonaleAbilitazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaPersonaleAbilitazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaPersonaleAbilitazioni");
        }
    }
}
