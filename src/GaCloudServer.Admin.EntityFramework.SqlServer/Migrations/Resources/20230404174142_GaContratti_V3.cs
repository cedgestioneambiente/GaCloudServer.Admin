using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContratti_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaContrattiModalitas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiModalitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiPermessi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiPermessi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiServizi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiServizi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiSoggetti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartitaIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SedeLegale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecapitoFatture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fornitore = table.Column<bool>(type: "bit", nullable: false),
                    Cliente = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiSoggetti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiTipologie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiTipologie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiUtentiOnPermessi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContrattiPermessoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiUtentiOnPermessi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContrattiUtentiOnPermessi_GaContrattiPermessi_ContrattiPermessoId",
                        column: x => x.ContrattiPermessoId,
                        principalTable: "GaContrattiPermessi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiDocumenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContrattiSoggettoId = table.Column<long>(type: "bigint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceCig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faldone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContrattiModalitaId = table.Column<long>(type: "bigint", nullable: false),
                    Direzione = table.Column<bool>(type: "bit", nullable: false),
                    Contabilita = table.Column<bool>(type: "bit", nullable: false),
                    Personale = table.Column<bool>(type: "bit", nullable: false),
                    Informatica = table.Column<bool>(type: "bit", nullable: false),
                    Tecnico = table.Column<bool>(type: "bit", nullable: false),
                    QualitaSicurezza = table.Column<bool>(type: "bit", nullable: false),
                    Commerciale = table.Column<bool>(type: "bit", nullable: false),
                    AffariGenerali = table.Column<bool>(type: "bit", nullable: false),
                    Archiviato = table.Column<bool>(type: "bit", nullable: false),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContrattiPreventivoId = table.Column<long>(type: "bigint", nullable: true),
                    PreventivoNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContrattiTipologia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SogliaAvviso = table.Column<int>(type: "int", nullable: false),
                    Comunicazione = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiDocumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiModalitas_ContrattiModalitaId",
                        column: x => x.ContrattiModalitaId,
                        principalTable: "GaContrattiModalitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiSoggetti_ContrattiSoggettoId",
                        column: x => x.ContrattiSoggettoId,
                        principalTable: "GaContrattiSoggetti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiDocumentiAllegati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContrattiDocumentoId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_GaContrattiDocumentiAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumentiAllegati_GaContrattiDocumenti_ContrattiDocumentoId",
                        column: x => x.ContrattiDocumentoId,
                        principalTable: "GaContrattiDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiModalitaId",
                table: "GaContrattiDocumenti",
                column: "ContrattiModalitaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiSoggettoId",
                table: "GaContrattiDocumenti",
                column: "ContrattiSoggettoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumentiAllegati_ContrattiDocumentoId",
                table: "GaContrattiDocumentiAllegati",
                column: "ContrattiDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiUtentiOnPermessi_ContrattiPermessoId",
                table: "GaContrattiUtentiOnPermessi",
                column: "ContrattiPermessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaContrattiDocumentiAllegati");

            migrationBuilder.DropTable(
                name: "GaContrattiServizi");

            migrationBuilder.DropTable(
                name: "GaContrattiTipologie");

            migrationBuilder.DropTable(
                name: "GaContrattiUtentiOnPermessi");

            migrationBuilder.DropTable(
                name: "GaContrattiDocumenti");

            migrationBuilder.DropTable(
                name: "GaContrattiPermessi");

            migrationBuilder.DropTable(
                name: "GaContrattiModalitas");

            migrationBuilder.DropTable(
                name: "GaContrattiSoggetti");
        }
    }
}
