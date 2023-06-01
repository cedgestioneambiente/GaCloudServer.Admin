using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodArera",
                table: "GaContactCenterTipiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ContactCenter",
                table: "GaContactCenterTipiRichieste",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Fatturazione",
                table: "GaContactCenterTipiRichieste",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "GaContactCenterTipiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Magazzino",
                table: "GaContactCenterTipiRichieste",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PrintTemplate",
                table: "GaContactCenterTipiRichieste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GaCrmTickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTicket = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRichiesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CrmEventComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Utente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodCli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactCenterProvenienzaId = table.Column<long>(type: "bigint", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cellulare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactCenterTioRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    DataChiusura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactCenterStatoRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assignee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteCrm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteOperatore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactCenterTipoRichiestaId = table.Column<long>(type: "bigint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCrmTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCrmTickets_GaContactCenterProvenienze_ContactCenterProvenienzaId",
                        column: x => x.ContactCenterProvenienzaId,
                        principalTable: "GaContactCenterProvenienze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaCrmTickets_GaContactCenterStatiRichieste_ContactCenterStatoRichiestaId",
                        column: x => x.ContactCenterStatoRichiestaId,
                        principalTable: "GaContactCenterStatiRichieste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaCrmTickets_GaContactCenterTipiRichieste_ContactCenterTipoRichiestaId",
                        column: x => x.ContactCenterTipoRichiestaId,
                        principalTable: "GaContactCenterTipiRichieste",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GaCrmTickets_GaCrmEventComuni_CrmEventComuneId",
                        column: x => x.CrmEventComuneId,
                        principalTable: "GaCrmEventComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmTickets_ContactCenterProvenienzaId",
                table: "GaCrmTickets",
                column: "ContactCenterProvenienzaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmTickets_ContactCenterStatoRichiestaId",
                table: "GaCrmTickets",
                column: "ContactCenterStatoRichiestaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmTickets_ContactCenterTipoRichiestaId",
                table: "GaCrmTickets",
                column: "ContactCenterTipoRichiestaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmTickets_CrmEventComuneId",
                table: "GaCrmTickets",
                column: "CrmEventComuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "CodArera",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "ContactCenter",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "Fatturazione",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "Magazzino",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.DropColumn(
                name: "PrintTemplate",
                table: "GaContactCenterTipiRichieste");
        }
    }
}
