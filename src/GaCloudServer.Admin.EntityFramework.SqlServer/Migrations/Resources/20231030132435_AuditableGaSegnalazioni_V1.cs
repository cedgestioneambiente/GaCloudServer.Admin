using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaSegnalazioni_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaSegnalazioniTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaSegnalazioniTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaSegnalazioniTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaSegnalazioniTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaSegnalazioniStati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaSegnalazioniStati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaSegnalazioniStati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaSegnalazioniStati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaSegnalazioniDocumentiImmagini",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaSegnalazioniDocumentiImmagini",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaSegnalazioniDocumentiImmagini",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaSegnalazioniDocumentiImmagini",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaSegnalazioniDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaSegnalazioniDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaSegnalazioniDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaSegnalazioniDocumenti",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaSegnalazioniTipi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaSegnalazioniTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaSegnalazioniTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaSegnalazioniTipi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaSegnalazioniStati");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaSegnalazioniStati");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaSegnalazioniStati");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaSegnalazioniStati");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaSegnalazioniDocumentiImmagini");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaSegnalazioniDocumentiImmagini");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaSegnalazioniDocumentiImmagini");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaSegnalazioniDocumentiImmagini");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaSegnalazioniDocumenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaSegnalazioniDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaSegnalazioniDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaSegnalazioniDocumenti");
        }
    }
}
