using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaCdr_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrUtenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrUtenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrUtenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrUtenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrStatiRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrStatiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrStatiRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrStatiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrRichiesteViaggi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrRichiesteViaggi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrRichiesteViaggi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrRichiesteViaggi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrConferimenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrConferimenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrConferimenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrConferimenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrComuniOnCentri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrComuniOnCentri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrComuniOnCentri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrComuniOnCentri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrCersOnCentri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrCersOnCentri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrCersOnCentri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrCersOnCentri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrCersDettagli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrCersDettagli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrCersDettagli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrCersDettagli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrCers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrCers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrCers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrCers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCdrCentri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCdrCentri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCdrCentri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCdrCentri",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrUtenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrUtenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrUtenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrUtenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrStatiRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrStatiRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrStatiRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrStatiRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrRichiesteViaggi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrRichiesteViaggi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrRichiesteViaggi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrRichiesteViaggi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrConferimenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrConferimenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrConferimenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrConferimenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrComuniOnCentri");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrComuniOnCentri");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrComuniOnCentri");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrComuniOnCentri");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrComuni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrComuni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrCersOnCentri");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrCersOnCentri");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrCersOnCentri");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrCersOnCentri");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrCersDettagli");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrCersDettagli");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrCersDettagli");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrCersDettagli");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrCers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrCers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrCers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrCers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCdrCentri");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCdrCentri");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCdrCentri");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCdrCentri");
        }
    }
}
