using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContratti_Clean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaContrattiFornitori",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartitaIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecapitoFatture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SedeLegale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
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
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
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
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
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
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
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
                    ContrattiPermessoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    UtenteId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ContrattiFornitoreId = table.Column<long>(type: "bigint", nullable: false),
                    ContrattiModalitaId = table.Column<long>(type: "bigint", nullable: false),
                    ContrattiServizioId = table.Column<long>(type: "bigint", nullable: false),
                    ContrattiTipologiaId = table.Column<long>(type: "bigint", nullable: false),
                    AffariGenerali = table.Column<bool>(type: "bit", nullable: false),
                    Archiviato = table.Column<bool>(type: "bit", nullable: false),
                    CodiceCig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commerciale = table.Column<bool>(type: "bit", nullable: false),
                    Comunicazione = table.Column<bool>(type: "bit", nullable: false),
                    Contabilita = table.Column<bool>(type: "bit", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direzione = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Faldone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informatica = table.Column<bool>(type: "bit", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Personale = table.Column<bool>(type: "bit", nullable: false),
                    Preventivo = table.Column<bool>(type: "bit", nullable: false),
                    PreventivoNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualitaSicurezza = table.Column<bool>(type: "bit", nullable: false),
                    SogliaAvviso = table.Column<int>(type: "int", nullable: false),
                    Tecnico = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiDocumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiFornitori_ContrattiFornitoreId",
                        column: x => x.ContrattiFornitoreId,
                        principalTable: "GaContrattiFornitori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiModalitas_ContrattiModalitaId",
                        column: x => x.ContrattiModalitaId,
                        principalTable: "GaContrattiModalitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiServizi_ContrattiServizioId",
                        column: x => x.ContrattiServizioId,
                        principalTable: "GaContrattiServizi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumenti_GaContrattiTipologie_ContrattiTipologiaId",
                        column: x => x.ContrattiTipologiaId,
                        principalTable: "GaContrattiTipologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
    }
}
