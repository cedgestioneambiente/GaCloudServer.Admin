using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaContactCenter_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContactCenterTipiRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContactCenterTipiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContactCenterTipiRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContactCenterTipiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContactCenterTickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContactCenterTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContactCenterTickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContactCenterTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContactCenterStatiRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContactCenterStatiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContactCenterStatiRichieste",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContactCenterStatiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContactCenterProvenienze",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContactCenterProvenienze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContactCenterProvenienze",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContactCenterProvenienze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContactCenterMailsOnTickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContactCenterMailsOnTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContactCenterMailsOnTickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContactCenterMailsOnTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContactCenterMails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContactCenterMails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContactCenterMails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContactCenterMails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContactCenterComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContactCenterComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContactCenterComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContactCenterComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaContactCenterAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaContactCenterAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaContactCenterAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaContactCenterAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ContactCenterPrintTemplates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ContactCenterPrintTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ContactCenterPrintTemplates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ContactCenterPrintTemplates",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContactCenterTickets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContactCenterTickets");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContactCenterTickets");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContactCenterTickets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContactCenterStatiRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContactCenterStatiRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContactCenterStatiRichieste");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContactCenterStatiRichieste");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContactCenterProvenienze");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContactCenterProvenienze");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContactCenterProvenienze");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContactCenterProvenienze");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContactCenterMailsOnTickets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContactCenterMailsOnTickets");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContactCenterMailsOnTickets");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContactCenterMailsOnTickets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContactCenterMails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContactCenterMails");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContactCenterMails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContactCenterMails");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContactCenterComuni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContactCenterComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContactCenterComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContactCenterComuni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaContactCenterAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaContactCenterAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaContactCenterAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaContactCenterAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ContactCenterPrintTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContactCenterPrintTemplates");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ContactCenterPrintTemplates");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ContactCenterPrintTemplates");
        }
    }
}
