using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaAutorizzazioni_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaAutorizzazioniTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaAutorizzazioniTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaAutorizzazioniTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaAutorizzazioniTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaAutorizzazioniDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaAutorizzazioniDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaAutorizzazioniDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaAutorizzazioniDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaAutorizzazioniAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaAutorizzazioniAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaAutorizzazioniAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaAutorizzazioniAllegati",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaAutorizzazioniTipi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaAutorizzazioniTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaAutorizzazioniTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaAutorizzazioniTipi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaAutorizzazioniDocumenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaAutorizzazioniDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaAutorizzazioniDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaAutorizzazioniDocumenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaAutorizzazioniAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaAutorizzazioniAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaAutorizzazioniAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaAutorizzazioniAllegati");
        }
    }
}
