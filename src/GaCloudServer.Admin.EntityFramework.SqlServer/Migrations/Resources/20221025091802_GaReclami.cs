using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaReclami : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaReclamiMittenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaReclamiMittenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaReclamiStati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaReclamiStati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaReclamiTempiRisposte",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Giorni = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaReclamiTempiRisposte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaReclamiTipiAzioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrizioneBreve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaReclamiTipiAzioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaReclamiTipiOrigini",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrizioneBreve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaReclamiTipiOrigini", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaReclamiDocumenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReclamiDocumentoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlobalSedeId = table.Column<long>(type: "bigint", nullable: false),
                    ReclamiTipoOrigineId = table.Column<long>(type: "bigint", nullable: false),
                    OrigineDescrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrigineData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReclamiMittenteId = table.Column<long>(type: "bigint", nullable: false),
                    Oggetto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReclamiTempoRispostaId = table.Column<long>(type: "bigint", nullable: false),
                    RispostaEntroData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fondato = table.Column<bool>(type: "bit", nullable: false),
                    Infondato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReclamiStatoId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzioniCorrettive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RispostaInviata = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RispostaDefinitiva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaReclamiDocumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaReclamiDocumenti_GaReclamiMittenti_ReclamiMittenteId",
                        column: x => x.ReclamiMittenteId,
                        principalTable: "GaReclamiMittenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaReclamiDocumenti_GaReclamiStati_ReclamiStatoId",
                        column: x => x.ReclamiStatoId,
                        principalTable: "GaReclamiStati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaReclamiDocumenti_GaReclamiTempiRisposte_ReclamiTempoRispostaId",
                        column: x => x.ReclamiTempoRispostaId,
                        principalTable: "GaReclamiTempiRisposte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaReclamiDocumenti_GaReclamiTipiOrigini_ReclamiTipoOrigineId",
                        column: x => x.ReclamiTipoOrigineId,
                        principalTable: "GaReclamiTipiOrigini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaReclamiDocumenti_GlobalSedi_GlobalSedeId",
                        column: x => x.GlobalSedeId,
                        principalTable: "GlobalSedi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaReclamiAzioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReclamiDocumentoId = table.Column<long>(type: "bigint", nullable: false),
                    ReclamiTipoAzioneId = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Risposta = table.Column<bool>(type: "bit", nullable: false),
                    RispostaDefinitiva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaReclamiAzioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaReclamiAzioni_GaReclamiDocumenti_ReclamiDocumentoId",
                        column: x => x.ReclamiDocumentoId,
                        principalTable: "GaReclamiDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaReclamiAzioni_GaReclamiTipiAzioni_ReclamiTipoAzioneId",
                        column: x => x.ReclamiTipoAzioneId,
                        principalTable: "GaReclamiTipiAzioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaReclamiAzioni_ReclamiDocumentoId",
                table: "GaReclamiAzioni",
                column: "ReclamiDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaReclamiAzioni_ReclamiTipoAzioneId",
                table: "GaReclamiAzioni",
                column: "ReclamiTipoAzioneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaReclamiDocumenti_GlobalSedeId",
                table: "GaReclamiDocumenti",
                column: "GlobalSedeId");

            migrationBuilder.CreateIndex(
                name: "IX_GaReclamiDocumenti_ReclamiMittenteId",
                table: "GaReclamiDocumenti",
                column: "ReclamiMittenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaReclamiDocumenti_ReclamiStatoId",
                table: "GaReclamiDocumenti",
                column: "ReclamiStatoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaReclamiDocumenti_ReclamiTempoRispostaId",
                table: "GaReclamiDocumenti",
                column: "ReclamiTempoRispostaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaReclamiDocumenti_ReclamiTipoOrigineId",
                table: "GaReclamiDocumenti",
                column: "ReclamiTipoOrigineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaReclamiAzioni");

            migrationBuilder.DropTable(
                name: "GaReclamiDocumenti");

            migrationBuilder.DropTable(
                name: "GaReclamiTipiAzioni");

            migrationBuilder.DropTable(
                name: "GaReclamiMittenti");

            migrationBuilder.DropTable(
                name: "GaReclamiStati");

            migrationBuilder.DropTable(
                name: "GaReclamiTempiRisposte");

            migrationBuilder.DropTable(
                name: "GaReclamiTipiOrigini");
        }
    }
}
