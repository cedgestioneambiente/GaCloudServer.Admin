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
                name: "GaPresenzeProfili",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GgLavorativi = table.Column<int>(type: "int", nullable: false),
                    GgFerie = table.Column<int>(type: "int", nullable: false),
                    GgPermessiCcnl = table.Column<int>(type: "int", nullable: false),
                    HhPermessiCcnl = table.Column<int>(type: "int", nullable: false),
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
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    PresenzeStatoRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    PresenzeTipoOraId = table.Column<long>(type: "bigint", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeRichieste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeRichieste_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
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
                name: "IX_GaPresenzeRichieste_PersonaleDipendenteId",
                table: "GaPresenzeRichieste",
                column: "PersonaleDipendenteId");

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
                name: "GaPresenzeProfili");

            migrationBuilder.DropTable(
                name: "GaPresenzeResponsabiliOnSettori");

            migrationBuilder.DropTable(
                name: "GaPresenzeRichieste");

            migrationBuilder.DropTable(
                name: "GaPresenzeResponsabili");

            migrationBuilder.DropTable(
                name: "GaPresenzeStatiRichieste");

            migrationBuilder.DropTable(
                name: "GaPresenzeTipiOre");
        }
    }
}
