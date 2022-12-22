using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContratti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaContrattiFornitori",
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
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiFornitori", x => x.Id);
                });

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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiDocumenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContrattiFornitoreId = table.Column<long>(type: "bigint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceCig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faldone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    ContrattiServizioId = table.Column<long>(type: "bigint", nullable: false),
                    Preventivo = table.Column<bool>(type: "bit", nullable: false),
                    PreventivoNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContrattiTipologiaId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_GaContrattiDocumenti_GaContrattiFornitori_ContrattiFornitoreId",
                        column: x => x.ContrattiFornitoreId,
                        principalTable: "GaContrattiFornitori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiModalitas_ContrattiModalitaId",
                        column: x => x.ContrattiModalitaId,
                        principalTable: "GaContrattiModalitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiServizi_ContrattiServizioId",
                        column: x => x.ContrattiServizioId,
                        principalTable: "GaContrattiServizi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiTipologie_ContrattiTipologiaId",
                        column: x => x.ContrattiTipologiaId,
                        principalTable: "GaContrattiTipologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiFornitoreId",
                table: "GaContrattiDocumenti",
                column: "ContrattiFornitoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiModalitaId",
                table: "GaContrattiDocumenti",
                column: "ContrattiModalitaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiServizioId",
                table: "GaContrattiDocumenti",
                column: "ContrattiServizioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiTipologiaId",
                table: "GaContrattiDocumenti",
                column: "ContrattiTipologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiUtentiOnPermessi_ContrattiPermessoId",
                table: "GaContrattiUtentiOnPermessi",
                column: "ContrattiPermessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaContrattiDocumenti");

            migrationBuilder.DropTable(
                name: "GaContrattiUtentiOnPermessi");

            migrationBuilder.DropTable(
                name: "GaContrattiFornitori");

            migrationBuilder.DropTable(
                name: "GaContrattiModalitas");

            migrationBuilder.DropTable(
                name: "GaContrattiServizi");

            migrationBuilder.DropTable(
                name: "GaContrattiTipologie");

            migrationBuilder.DropTable(
                name: "GaContrattiPermessi");
        }
    }
}
