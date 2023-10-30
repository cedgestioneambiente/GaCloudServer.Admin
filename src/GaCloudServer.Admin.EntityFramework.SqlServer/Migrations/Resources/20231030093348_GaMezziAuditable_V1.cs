using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaMezziAuditable_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziVeicoli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziVeicoli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziVeicoli",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziVeicoli",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziScadenzeTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziScadenzeTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziScadenzeTipi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziScadenzeTipi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziScadenze",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziScadenze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziScadenze",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziScadenze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziProprietari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziProprietari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziProprietari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziProprietari",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziPeriodiScadenze",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziPeriodiScadenze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziPeriodiScadenze",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziPeriodiScadenze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziPatenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziPatenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziPatenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziPatenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziDocumenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziClassi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziClassi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziClassi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziClassi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaMezziAlimentazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaMezziAlimentazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaMezziAlimentazioni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaMezziAlimentazioni",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziVeicoli");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziVeicoli");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziVeicoli");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziVeicoli");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziTipi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziTipi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziScadenzeTipi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziScadenzeTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziScadenzeTipi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziScadenzeTipi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziScadenze");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziScadenze");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziScadenze");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziScadenze");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziProprietari");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziProprietari");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziProprietari");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziProprietari");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziPeriodiScadenze");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziPeriodiScadenze");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziPeriodiScadenze");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziPeriodiScadenze");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziPatenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziPatenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziPatenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziPatenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziDocumenti");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziDocumenti");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziDocumenti");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziClassi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziClassi");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziClassi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziClassi");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaMezziAlimentazioni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaMezziAlimentazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaMezziAlimentazioni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaMezziAlimentazioni");
        }
    }
}
