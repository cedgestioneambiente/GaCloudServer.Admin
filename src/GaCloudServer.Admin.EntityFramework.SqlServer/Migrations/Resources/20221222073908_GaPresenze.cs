using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPresenze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPresenzeDateEscluse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeDateEscluse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeOrari",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeOrari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeProfili",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HhFerie = table.Column<double>(type: "float", nullable: false),
                    HhPermessiCcnl = table.Column<double>(type: "float", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeProfili", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeResponsabili",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeResponsabili", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeResponsabili_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeStatiRichieste",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeStatiRichieste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeTipiOre",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovazioneAutomatica = table.Column<bool>(type: "bit", nullable: false),
                    DecrementaTipo = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeTipiOre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeOrariGiornate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresenzeOrarioId = table.Column<long>(type: "bigint", nullable: false),
                    Giorno = table.Column<int>(type: "int", nullable: false),
                    OraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OraFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PausaInizio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PausaFine = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeOrariGiornate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeOrariGiornate_GaPresenzeOrari_PresenzeOrarioId",
                        column: x => x.PresenzeOrarioId,
                        principalTable: "GaPresenzeOrari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeDipendenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    Matricola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresenzeOrarioId = table.Column<long>(type: "bigint", nullable: false),
                    PresenzeProfiloId = table.Column<long>(type: "bigint", nullable: false),
                    HhFerie = table.Column<double>(type: "float", nullable: false),
                    HhPermessiCcnl = table.Column<double>(type: "float", nullable: false),
                    HhRecupero = table.Column<double>(type: "float", nullable: false),
                    PrivilegiElevati = table.Column<bool>(type: "bit", nullable: false),
                    AutoApprova = table.Column<bool>(type: "bit", nullable: false),
                    SuperUser = table.Column<bool>(type: "bit", nullable: false),
                    BancaOre = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeDipendenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeDipendenti_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeDipendenti_GaPresenzeOrari_PresenzeOrarioId",
                        column: x => x.PresenzeOrarioId,
                        principalTable: "GaPresenzeOrari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeDipendenti_GaPresenzeProfili_PresenzeProfiloId",
                        column: x => x.PresenzeProfiloId,
                        principalTable: "GaPresenzeProfili",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeResponsabiliOnSettori",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresenzeResponsabileId = table.Column<long>(type: "bigint", nullable: false),
                    GlobalSettoreId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeResponsabiliOnSettori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeResponsabiliOnSettori_GaPresenzeResponsabili_PresenzeResponsabileId",
                        column: x => x.PresenzeResponsabileId,
                        principalTable: "GaPresenzeResponsabili",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeResponsabiliOnSettori_GlobalSettori_GlobalSettoreId",
                        column: x => x.GlobalSettoreId,
                        principalTable: "GlobalSettori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeRichieste",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresenzeDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    PresenzeStatoRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    PresenzeTipoOraId = table.Column<long>(type: "bigint", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotaleOre = table.Column<double>(type: "float", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeRichieste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeRichieste_GaPresenzeDipendenti_PresenzeDipendenteId",
                        column: x => x.PresenzeDipendenteId,
                        principalTable: "GaPresenzeDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeRichieste_GaPresenzeStatiRichieste_PresenzeStatoRichiestaId",
                        column: x => x.PresenzeStatoRichiestaId,
                        principalTable: "GaPresenzeStatiRichieste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeRichieste_GaPresenzeTipiOre_PresenzeTipoOraId",
                        column: x => x.PresenzeTipoOraId,
                        principalTable: "GaPresenzeTipiOre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeBancheOreUtilizzi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresenzeDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    PresenzeRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Qta = table.Column<double>(type: "float", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeBancheOreUtilizzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeBancheOreUtilizzi_GaPresenzeDipendenti_PresenzeDipendenteId",
                        column: x => x.PresenzeDipendenteId,
                        principalTable: "GaPresenzeDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeBancheOreUtilizzi_GaPresenzeRichieste_PresenzeRichiestaId",
                        column: x => x.PresenzeRichiestaId,
                        principalTable: "GaPresenzeRichieste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeBancheOreUtilizzi_PresenzeDipendenteId",
                table: "GaPresenzeBancheOreUtilizzi",
                column: "PresenzeDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeBancheOreUtilizzi_PresenzeRichiestaId",
                table: "GaPresenzeBancheOreUtilizzi",
                column: "PresenzeRichiestaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeDipendenti_PersonaleDipendenteId",
                table: "GaPresenzeDipendenti",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeDipendenti_PresenzeOrarioId",
                table: "GaPresenzeDipendenti",
                column: "PresenzeOrarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeDipendenti_PresenzeProfiloId",
                table: "GaPresenzeDipendenti",
                column: "PresenzeProfiloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeOrariGiornate_PresenzeOrarioId",
                table: "GaPresenzeOrariGiornate",
                column: "PresenzeOrarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeResponsabili_PersonaleDipendenteId",
                table: "GaPresenzeResponsabili",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeResponsabiliOnSettori_GlobalSettoreId",
                table: "GaPresenzeResponsabiliOnSettori",
                column: "GlobalSettoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeResponsabiliOnSettori_PresenzeResponsabileId",
                table: "GaPresenzeResponsabiliOnSettori",
                column: "PresenzeResponsabileId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeRichieste_PresenzeDipendenteId",
                table: "GaPresenzeRichieste",
                column: "PresenzeDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeRichieste_PresenzeStatoRichiestaId",
                table: "GaPresenzeRichieste",
                column: "PresenzeStatoRichiestaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeRichieste_PresenzeTipoOraId",
                table: "GaPresenzeRichieste",
                column: "PresenzeTipoOraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPresenzeBancheOreUtilizzi");

            migrationBuilder.DropTable(
                name: "GaPresenzeDateEscluse");

            migrationBuilder.DropTable(
                name: "GaPresenzeOrariGiornate");

            migrationBuilder.DropTable(
                name: "GaPresenzeResponsabiliOnSettori");

            migrationBuilder.DropTable(
                name: "GaPresenzeRichieste");

            migrationBuilder.DropTable(
                name: "GaPresenzeResponsabili");

            migrationBuilder.DropTable(
                name: "GaPresenzeDipendenti");

            migrationBuilder.DropTable(
                name: "GaPresenzeStatiRichieste");

            migrationBuilder.DropTable(
                name: "GaPresenzeTipiOre");

            migrationBuilder.DropTable(
                name: "GaPresenzeOrari");

            migrationBuilder.DropTable(
                name: "GaPresenzeProfili");
        }
    }
}
