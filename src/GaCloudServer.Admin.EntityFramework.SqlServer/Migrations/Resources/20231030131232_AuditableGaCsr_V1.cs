using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaCsr_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCsrTrasportatori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCsrTrasportatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCsrTrasportatori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCsrTrasportatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCsrRipartizioniPercentuali",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCsrRipartizioniPercentuali",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCsrRipartizioniPercentuali",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCsrRipartizioniPercentuali",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCsrRegistrazioniPesi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCsrRegistrazioniPesi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCsrRegistrazioniPesi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCsrRegistrazioniPesi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCsrRegistrazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCsrRegistrazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCsrRegistrazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCsrRegistrazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCsrProduttori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCsrProduttori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCsrProduttori",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCsrProduttori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCsrDestinatari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCsrDestinatari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCsrDestinatari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCsrDestinatari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCsrComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCsrComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCsrComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCsrComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCsrCodiciCers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCsrCodiciCers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCsrCodiciCers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCsrCodiciCers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCsrTrasportatori");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCsrTrasportatori");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCsrTrasportatori");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCsrTrasportatori");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCsrRipartizioniPercentuali");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCsrRipartizioniPercentuali");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCsrRipartizioniPercentuali");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCsrRipartizioniPercentuali");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCsrRegistrazioniPesi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCsrRegistrazioniPesi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCsrRegistrazioniPesi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCsrRegistrazioniPesi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCsrRegistrazioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCsrRegistrazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCsrRegistrazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCsrRegistrazioni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCsrProduttori");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCsrProduttori");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCsrProduttori");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCsrProduttori");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCsrDestinatari");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCsrDestinatari");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCsrDestinatari");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCsrDestinatari");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCsrComuni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCsrComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCsrComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCsrComuni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCsrCodiciCers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCsrCodiciCers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCsrCodiciCers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCsrCodiciCers");
        }
    }
}
