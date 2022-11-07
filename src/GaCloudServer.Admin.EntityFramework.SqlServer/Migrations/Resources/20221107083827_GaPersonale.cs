using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPersonale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPersonaleAssunzioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleAssunzioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleQualifiche",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleQualifiche", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleDipendenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlobalSedeId = table.Column<long>(type: "bigint", nullable: false),
                    GlobalCentroCostoId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleQualificaId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleAssunzioneId = table.Column<long>(type: "bigint", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Preposto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleDipendenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleDipendenti_GaPersonaleAssunzioni_PersonaleAssunzioneId",
                        column: x => x.PersonaleAssunzioneId,
                        principalTable: "GaPersonaleAssunzioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleDipendenti_GaPersonaleQualifiche_PersonaleQualificaId",
                        column: x => x.PersonaleQualificaId,
                        principalTable: "GaPersonaleQualifiche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleDipendenti_GlobalCentriCosti_GlobalCentroCostoId",
                        column: x => x.GlobalCentroCostoId,
                        principalTable: "GlobalCentriCosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleDipendenti_GlobalSedi_GlobalSedeId",
                        column: x => x.GlobalSedeId,
                        principalTable: "GlobalSedi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleAbilitazioniTipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleAbilitazioniTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleArticoliDpis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caratteristiche = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OmettiStampa = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleArticoliDpis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleArticoliModelli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleArticoliModelli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleArticoliTipologie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleArticoliTipologie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleRetributiviTipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleRetributiviTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleSanzioniDescrizioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleSanzioniDescrizioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleSanzioniMotivi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleSanzioniMotivi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleScadenzeDettagli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleScadenzeDettagli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleScadenzeTipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleScadenzeTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleSchedeConsegne",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleSchedeConsegne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleSchedeConsegne_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleAbilitazioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleAbilitazioneTipoId = table.Column<long>(type: "bigint", nullable: false),
                    DataVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DettaglioAbilitazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleAbilitazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleAbilitazioni_GaPersonaleAbilitazioniTipi_PersonaleAbilitazioneTipoId",
                        column: x => x.PersonaleAbilitazioneTipoId,
                        principalTable: "GaPersonaleAbilitazioniTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleAbilitazioni_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleArticoli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleArticoloTipologiaId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleArticoloModelloId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleArticoloDpiId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleArticoli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleArticoli_GaPersonaleArticoliDpis_PersonaleArticoloDpiId",
                        column: x => x.PersonaleArticoloDpiId,
                        principalTable: "GaPersonaleArticoliDpis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleArticoli_GaPersonaleArticoliModelli_PersonaleArticoloModelloId",
                        column: x => x.PersonaleArticoloModelloId,
                        principalTable: "GaPersonaleArticoliModelli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleArticoli_GaPersonaleArticoliTipologie_PersonaleArticoloTipologiaId",
                        column: x => x.PersonaleArticoloTipologiaId,
                        principalTable: "GaPersonaleArticoliTipologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleRetributivi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleRetributivoTipoId = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DettaglioRetributivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleRetributivi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleRetributivi_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleRetributivi_GaPersonaleRetributiviTipi_PersonaleRetributivoTipoId",
                        column: x => x.PersonaleRetributivoTipoId,
                        principalTable: "GaPersonaleRetributiviTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleSanzioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaleSanzioneMotivoId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleSanzioneDescrizioneId = table.Column<long>(type: "bigint", nullable: false),
                    DettaglioSanzione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleSanzioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleSanzioni_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleSanzioni_GaPersonaleSanzioniDescrizioni_PersonaleSanzioneDescrizioneId",
                        column: x => x.PersonaleSanzioneDescrizioneId,
                        principalTable: "GaPersonaleSanzioniDescrizioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleSanzioni_GaPersonaleSanzioniMotivi_PersonaleSanzioneMotivoId",
                        column: x => x.PersonaleSanzioneMotivoId,
                        principalTable: "GaPersonaleSanzioniMotivi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleScadenze",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleScadenzaTipoId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleScadenzaDettaglioId = table.Column<long>(type: "bigint", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleScadenze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleScadenze_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleScadenze_GaPersonaleScadenzeDettagli_PersonaleScadenzaDettaglioId",
                        column: x => x.PersonaleScadenzaDettaglioId,
                        principalTable: "GaPersonaleScadenzeDettagli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleScadenze_GaPersonaleScadenzeTipi_PersonaleScadenzaTipoId",
                        column: x => x.PersonaleScadenzaTipoId,
                        principalTable: "GaPersonaleScadenzeTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPersonaleSchedeConsegneDettagli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleSchedaConsegnaId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleMagazzinoArticoloId = table.Column<long>(type: "bigint", nullable: false),
                    Taglia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qta = table.Column<int>(type: "int", nullable: false),
                    PersonaleArticoloId = table.Column<long>(type: "bigint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPersonaleSchedeConsegneDettagli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleSchedeConsegneDettagli_GaPersonaleArticoli_PersonaleArticoloId",
                        column: x => x.PersonaleArticoloId,
                        principalTable: "GaPersonaleArticoli",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GaPersonaleSchedeConsegneDettagli_GaPersonaleSchedeConsegne_PersonaleSchedaConsegnaId",
                        column: x => x.PersonaleSchedaConsegnaId,
                        principalTable: "GaPersonaleSchedeConsegne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleDipendenti_GlobalCentroCostoId",
                table: "GaPersonaleDipendenti",
                column: "GlobalCentroCostoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleDipendenti_GlobalSedeId",
                table: "GaPersonaleDipendenti",
                column: "GlobalSedeId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleDipendenti_PersonaleAssunzioneId",
                table: "GaPersonaleDipendenti",
                column: "PersonaleAssunzioneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleDipendenti_PersonaleQualificaId",
                table: "GaPersonaleDipendenti",
                column: "PersonaleQualificaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleAbilitazioni_PersonaleAbilitazioneTipoId",
                table: "GaPersonaleAbilitazioni",
                column: "PersonaleAbilitazioneTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleAbilitazioni_PersonaleDipendenteId",
                table: "GaPersonaleAbilitazioni",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleArticoli_PersonaleArticoloDpiId",
                table: "GaPersonaleArticoli",
                column: "PersonaleArticoloDpiId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleArticoli_PersonaleArticoloModelloId",
                table: "GaPersonaleArticoli",
                column: "PersonaleArticoloModelloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleArticoli_PersonaleArticoloTipologiaId",
                table: "GaPersonaleArticoli",
                column: "PersonaleArticoloTipologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleRetributivi_PersonaleDipendenteId",
                table: "GaPersonaleRetributivi",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleRetributivi_PersonaleRetributivoTipoId",
                table: "GaPersonaleRetributivi",
                column: "PersonaleRetributivoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleSanzioni_PersonaleDipendenteId",
                table: "GaPersonaleSanzioni",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleSanzioni_PersonaleSanzioneDescrizioneId",
                table: "GaPersonaleSanzioni",
                column: "PersonaleSanzioneDescrizioneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleSanzioni_PersonaleSanzioneMotivoId",
                table: "GaPersonaleSanzioni",
                column: "PersonaleSanzioneMotivoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleScadenze_PersonaleDipendenteId",
                table: "GaPersonaleScadenze",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleScadenze_PersonaleScadenzaDettaglioId",
                table: "GaPersonaleScadenze",
                column: "PersonaleScadenzaDettaglioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleScadenze_PersonaleScadenzaTipoId",
                table: "GaPersonaleScadenze",
                column: "PersonaleScadenzaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleSchedeConsegne_PersonaleDipendenteId",
                table: "GaPersonaleSchedeConsegne",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleSchedeConsegneDettagli_PersonaleArticoloId",
                table: "GaPersonaleSchedeConsegneDettagli",
                column: "PersonaleArticoloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleSchedeConsegneDettagli_PersonaleSchedaConsegnaId",
                table: "GaPersonaleSchedeConsegneDettagli",
                column: "PersonaleSchedaConsegnaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPersonaleDipendenti");

            migrationBuilder.DropTable(
                name: "GaPersonaleAssunzioni");

            migrationBuilder.DropTable(
                name: "GaPersonaleQualifiche");

            migrationBuilder.DropTable(
                name: "GaPersonaleAbilitazioni");

            migrationBuilder.DropTable(
                name: "GaPersonaleRetributivi");

            migrationBuilder.DropTable(
                name: "GaPersonaleSanzioni");

            migrationBuilder.DropTable(
                name: "GaPersonaleScadenze");

            migrationBuilder.DropTable(
                name: "GaPersonaleSchedeConsegneDettagli");

            migrationBuilder.DropTable(
                name: "GaPersonaleAbilitazioniTipi");

            migrationBuilder.DropTable(
                name: "GaPersonaleRetributiviTipi");

            migrationBuilder.DropTable(
                name: "GaPersonaleSanzioniDescrizioni");

            migrationBuilder.DropTable(
                name: "GaPersonaleSanzioniMotivi");

            migrationBuilder.DropTable(
                name: "GaPersonaleScadenzeDettagli");

            migrationBuilder.DropTable(
                name: "GaPersonaleScadenzeTipi");

            migrationBuilder.DropTable(
                name: "GaPersonaleArticoli");

            migrationBuilder.DropTable(
                name: "GaPersonaleSchedeConsegne");

            migrationBuilder.DropTable(
                name: "GaPersonaleArticoliDpis");

            migrationBuilder.DropTable(
                name: "GaPersonaleArticoliModelli");

            migrationBuilder.DropTable(
                name: "GaPersonaleArticoliTipologie");
        }
    }
}
