using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableConsorzio_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioTrasportatori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioTrasportatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioTrasportatori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioTrasportatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioSmaltimenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioSmaltimenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioSmaltimenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioSmaltimenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioRegistrazioniAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioRegistrazioniAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioRegistrazioniAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioRegistrazioniAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioRegistrazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioRegistrazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioRegistrazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioRegistrazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioProduttori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioProduttori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioProduttori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioProduttori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioPeriodi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioPeriodi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioPeriodi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioPeriodi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioOperazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioOperazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioOperazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioOperazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioImportsTasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioImportsTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioImportsTasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioImportsTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioDestinatari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioDestinatari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioDestinatari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioDestinatari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ConsorzioCers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ConsorzioCers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ConsorzioCers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ConsorzioCers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioTrasportatori");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioTrasportatori");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioTrasportatori");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioTrasportatori");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioSmaltimenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioSmaltimenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioSmaltimenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioSmaltimenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioRegistrazioniAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioRegistrazioniAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioRegistrazioniAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioRegistrazioniAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioProduttori");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioProduttori");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioProduttori");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioProduttori");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioPeriodi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioPeriodi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioPeriodi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioPeriodi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioOperazioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioOperazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioOperazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioOperazioni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioImportsTasks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioImportsTasks");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioImportsTasks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioImportsTasks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioDestinatari");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioDestinatari");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioDestinatari");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioDestinatari");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioComuni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioComuni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ConsorzioCers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ConsorzioCers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ConsorzioCers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ConsorzioCers");
        }
    }
}
