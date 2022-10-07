using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCdr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaCdrCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Centro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCentri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pericoloso = table.Column<bool>(type: "bit", nullable: true),
                    Peso = table.Column<bool>(type: "bit", nullable: true),
                    Qta = table.Column<bool>(type: "bit", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrComuni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrComuni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCersDettagli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCerId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesoDefault = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCersDettagli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrCersDettagli_GaCdrCers_CdrCerId",
                        column: x => x.CdrCerId,
                        principalTable: "GaCdrCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCersOnCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCentroId = table.Column<long>(type: "bigint", nullable: false),
                    CdrCerId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCersOnCentri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrCersOnCentri_GaCdrCentri_CdrCentroId",
                        column: x => x.CdrCentroId,
                        principalTable: "GaCdrCentri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCdrCersOnCentri_GaCdrCers_CdrCerId",
                        column: x => x.CdrCerId,
                        principalTable: "GaCdrCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrComuniOnCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCentroId = table.Column<long>(type: "bigint", nullable: false),
                    CdrComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrComuniOnCentri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrComuniOnCentri_GaCdrCentri_CdrCentroId",
                        column: x => x.CdrCentroId,
                        principalTable: "GaCdrCentri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCdrComuniOnCentri_GaCdrComuni_CdrComuneId",
                        column: x => x.CdrComuneId,
                        principalTable: "GaCdrComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
    name: "GaCdrConferimenti",
    columns: table => new
    {
        Id = table.Column<long>(type: "bigint", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        Data = table.Column<DateTime>(type: "datetime2", nullable: false),
        CfPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
        Anagrafica = table.Column<bool>(type: "bit", nullable: false),
        Ditta = table.Column<bool>(type: "bit", nullable: false),
        CdrCentroId = table.Column<long>(type: "bigint", nullable: false),
        CdrComuneId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        CdrCerId = table.Column<long>(type: "bigint", nullable: false),
        CdrCerDettaglioId = table.Column<long>(type: "bigint", nullable: false),
        Peso = table.Column<double>(type: "float", nullable: false),
        Quantita = table.Column<int>(type: "int", nullable: false),
        Targa = table.Column<string>(type: "nvarchar(max)", nullable: true),
        Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
        CdrUtenteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        NumCon = table.Column<string>(type: "nvarchar(max)", nullable: true),
        Partita = table.Column<string>(type: "nvarchar(max)", nullable: true),
        Noleggio = table.Column<bool>(type: "bit", nullable: false),
        Disabled = table.Column<bool>(type: "bit", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_GaCdrConferimenti", x => x.Id);
        table.ForeignKey(
            name: "FK_GaCdrConferimenti_GaCdrCentri_CdrCentroId",
            column: x => x.CdrCentroId,
            principalTable: "GaCdrCentri",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
        table.ForeignKey(
            name: "FK_GaCdrConferimenti_GaCdrCers_CdrCerId",
            column: x => x.CdrCerId,
            principalTable: "GaCdrCers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
        table.ForeignKey(
            name: "FK_GaCdrConferimenti_GaCdrCersDettagli_CdrCerDettaglioId",
            column: x => x.CdrCerDettaglioId,
            principalTable: "GaCdrCersDettagli",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    });

            migrationBuilder.CreateTable(
                name: "GaCdrStatiRichieste",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrStatiRichieste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrUtenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CfPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CdrComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ditta = table.Column<bool>(type: "bit", nullable: false),
                    InserimentoUtente = table.Column<bool>(type: "bit", nullable: false),
                    Approvato = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrUtenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrUtenti_GaCdrComuni_CdrComuneId",
                        column: x => x.CdrComuneId,
                        principalTable: "GaCdrComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrRichiesteViaggi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CdrCentroId = table.Column<long>(type: "bigint", nullable: false),
                    CdrCerId = table.Column<long>(type: "bigint", nullable: false),
                    CdrStatoRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    DataChiusura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PesoPresunto = table.Column<double>(type: "float", nullable: false),
                    PesoDestino = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inviata = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrRichiesteViaggi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrRichiesteViaggi_GaCdrCers_CdrCerId",
                        column: x => x.CdrCerId,
                        principalTable: "GaCdrCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCdrRichiesteViaggi_GaCdrStatiRichieste_CdrStatoRichiestaId",
                        column: x => x.CdrStatoRichiestaId,
                        principalTable: "GaCdrStatiRichieste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersDettagli_CdrCerId",
                table: "GaCdrCersDettagli",
                column: "CdrCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersOnCentri_CdrCentroId",
                table: "GaCdrCersOnCentri",
                column: "CdrCentroId");


            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersOnCentri_CdrCerId",
                table: "GaCdrCersOnCentri",
                column: "CdrCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrComuniOnCentri_CdrCentroId",
                table: "GaCdrComuniOnCentri",
                column: "CdrCentroId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrComuniOnCentri_CdrComuneId",
                table: "GaCdrComuniOnCentri",
                column: "CdrComuneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrConferimenti_CdrCentroId",
                table: "GaCdrConferimenti",
                column: "CdrCentroId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrConferimenti_CdrCerDettaglioId",
                table: "GaCdrConferimenti",
                column: "CdrCerDettaglioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrConferimenti_CdrCerId",
                table: "GaCdrConferimenti",
                column: "CdrCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrRichiesteViaggi_CdrCerId",
                table: "GaCdrRichiesteViaggi",
                column: "CdrCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrRichiesteViaggi_CdrStatoRichiestaId",
                table: "GaCdrRichiesteViaggi",
                column: "CdrStatoRichiestaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrUtenti_CdrComuneId",
                table: "GaCdrUtenti",
                column: "CdrComuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaCdrCersDettagli");

            migrationBuilder.DropTable(
                name: "GaCdrCersOnCentri");

            migrationBuilder.DropTable(
                name: "GaCdrComuniOnCentri");

            migrationBuilder.DropTable(
                name: "GaCdrCers");

            migrationBuilder.DropTable(
                name: "GaCdrCentri");

            migrationBuilder.DropTable(
                name: "GaCdrComuni");

            migrationBuilder.DropTable(
                name: "GaCdrConferimenti");

            migrationBuilder.DropTable(
                name: "GaCdrRichiesteViaggi");

            migrationBuilder.DropTable(
                name: "GaCdrUtenti");

            migrationBuilder.DropTable(
                name: "GaCdrStatiRichieste");
        }
    }
}

