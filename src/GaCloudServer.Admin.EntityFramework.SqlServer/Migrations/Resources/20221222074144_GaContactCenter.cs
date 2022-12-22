using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContactCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaContactCenterAllegati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactCenterTicketId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContactCenterAllegati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContactCenterComuni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodAzi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContactCenterComuni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContactCenterMails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContactCenterMails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContactCenterProvenienze",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContactCenterProvenienze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContactCenterStatiRichieste",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContactCenterStatiRichieste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContactCenterTipiRichieste",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingombranti = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContactCenterTipiRichieste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContactCenterTickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CfPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Via = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCiv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataTicket = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EseguitoIl = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEsecuzione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactCenterStatoRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    ContactCenterProvenienzaId = table.Column<long>(type: "bigint", nullable: false),
                    ContactCenterComuneId = table.Column<long>(type: "bigint", nullable: false),
                    ComuneAltro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactCenterTipoRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    AziendeListaId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inviato = table.Column<bool>(type: "bit", nullable: false),
                    Materiali = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Promemoria = table.Column<bool>(type: "bit", nullable: false),
                    DaFatturare = table.Column<bool>(type: "bit", nullable: false),
                    Stampato = table.Column<bool>(type: "bit", nullable: false),
                    TelefonoMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reclamo = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContactCenterTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContactCenterTickets_GaAziendeListe_AziendeListaId",
                        column: x => x.AziendeListaId,
                        principalTable: "GaAziendeListe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaContactCenterTickets_GaContactCenterComuni_ContactCenterComuneId",
                        column: x => x.ContactCenterComuneId,
                        principalTable: "GaContactCenterComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaContactCenterTickets_GaContactCenterProvenienze_ContactCenterProvenienzaId",
                        column: x => x.ContactCenterProvenienzaId,
                        principalTable: "GaContactCenterProvenienze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaContactCenterTickets_GaContactCenterStatiRichieste_ContactCenterStatoRichiestaId",
                        column: x => x.ContactCenterStatoRichiestaId,
                        principalTable: "GaContactCenterStatiRichieste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaContactCenterTickets_GaContactCenterTipiRichieste_ContactCenterTipoRichiestaId",
                        column: x => x.ContactCenterTipoRichiestaId,
                        principalTable: "GaContactCenterTipiRichieste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaContactCenterMailsOnTickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactCenterTicketId = table.Column<long>(type: "bigint", nullable: false),
                    ContactCenterMailId = table.Column<long>(type: "bigint", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContactCenterMailsOnTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContactCenterMailsOnTickets_GaContactCenterMails_ContactCenterMailId",
                        column: x => x.ContactCenterMailId,
                        principalTable: "GaContactCenterMails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaContactCenterMailsOnTickets_GaContactCenterTickets_ContactCenterTicketId",
                        column: x => x.ContactCenterTicketId,
                        principalTable: "GaContactCenterTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaContactCenterMailsOnTickets_ContactCenterMailId",
                table: "GaContactCenterMailsOnTickets",
                column: "ContactCenterMailId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContactCenterMailsOnTickets_ContactCenterTicketId",
                table: "GaContactCenterMailsOnTickets",
                column: "ContactCenterTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContactCenterTickets_AziendeListaId",
                table: "GaContactCenterTickets",
                column: "AziendeListaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContactCenterTickets_ContactCenterComuneId",
                table: "GaContactCenterTickets",
                column: "ContactCenterComuneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContactCenterTickets_ContactCenterProvenienzaId",
                table: "GaContactCenterTickets",
                column: "ContactCenterProvenienzaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContactCenterTickets_ContactCenterStatoRichiestaId",
                table: "GaContactCenterTickets",
                column: "ContactCenterStatoRichiestaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContactCenterTickets_ContactCenterTipoRichiestaId",
                table: "GaContactCenterTickets",
                column: "ContactCenterTipoRichiestaId");

            migrationBuilder.InsertData(
                            table: "GaContactCenterProvenienze",
                            columns: new[] { "Id", "Descrizione", "Disabled" },
                            values: new object[,]
                            {
                                            { 1,"TELEFONATA" ,false},
                                            { 2,"MAIL" ,false},
                                            { 3,"ALTRO" ,false},
                            });

            migrationBuilder.InsertData(
                table: "GaContactCenterStatiRichieste",
                columns: new[] { "Id", "Descrizione", "Disabled" },
                values: new object[,]
                {
                                            { 1,"IN GESTIONE" ,false},
                                            { 2,"GESTITO" ,false},
                                            { 3,"ANNULLATO" ,false},
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaContactCenterAllegati");

            migrationBuilder.DropTable(
                name: "GaContactCenterMailsOnTickets");

            migrationBuilder.DropTable(
                name: "GaContactCenterMails");

            migrationBuilder.DropTable(
                name: "GaContactCenterTickets");

            migrationBuilder.DropTable(
                name: "GaContactCenterComuni");

            migrationBuilder.DropTable(
                name: "GaContactCenterProvenienze");

            migrationBuilder.DropTable(
                name: "GaContactCenterStatiRichieste");

            migrationBuilder.DropTable(
                name: "GaContactCenterTipiRichieste");
        }
    }
}
