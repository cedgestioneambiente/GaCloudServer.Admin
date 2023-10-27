using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AuditableGaCrm_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCrmTicketTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCrmTicketTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCrmTicketTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCrmTicketTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCrmTickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCrmTickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCrmTickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCrmTicketAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCrmTicketAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCrmTicketAllegati",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCrmTicketAllegati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCrmEventStates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCrmEventStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCrmEventStates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCrmEventStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCrmEvents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCrmEvents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCrmEventDevices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCrmEventDevices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCrmEventDevices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCrmEventDevices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCrmEventComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCrmEventComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCrmEventComuni",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCrmEventComuni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GaCrmEventAreas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GaCrmEventAreas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GaCrmEventAreas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GaCrmEventAreas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCrmTicketTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCrmTicketTags");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCrmTicketTags");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCrmTicketTags");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCrmTicketAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCrmTicketAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCrmTicketAllegati");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCrmTicketAllegati");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCrmEventStates");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCrmEventStates");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCrmEventStates");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCrmEventStates");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCrmEventDevices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCrmEventDevices");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCrmEventDevices");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCrmEventDevices");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCrmEventComuni");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCrmEventComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCrmEventComuni");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCrmEventComuni");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GaCrmEventAreas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GaCrmEventAreas");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GaCrmEventAreas");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GaCrmEventAreas");
        }
    }
}
