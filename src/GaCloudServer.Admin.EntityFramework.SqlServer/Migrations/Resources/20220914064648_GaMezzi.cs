using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaMezzi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaMezziAlimentazioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziAlimentazioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziCantieri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziCantieri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziClassi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziClassi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziPatenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziPatenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziPeriodiScadenze",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziPeriodiScadenze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziProprietari",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziProprietari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziScadenzeTipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziScadenzeTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziTipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziVeicoli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Targa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargaPrecedente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attrezzatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnoImmatricolazione = table.Column<int>(type: "int", nullable: false),
                    AlboGestori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScadenzaContratto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelaio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortataKg = table.Column<int>(type: "int", nullable: false),
                    MassaKg = table.Column<int>(type: "int", nullable: false),
                    Dismesso = table.Column<bool>(type: "bit", nullable: false),
                    DismessoData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ce = table.Column<bool>(type: "bit", nullable: false),
                    ManualeUsoManutenzione = table.Column<bool>(type: "bit", nullable: false),
                    CatalogoRicambi = table.Column<bool>(type: "bit", nullable: false),
                    MezziTipoId = table.Column<long>(type: "bigint", nullable: false),
                    MezziProprietarioId = table.Column<long>(type: "bigint", nullable: false),
                    MezziCantiereId = table.Column<long>(type: "bigint", nullable: false),
                    MezziClasseId = table.Column<long>(type: "bigint", nullable: false),
                    MezziAlimentazioneId = table.Column<long>(type: "bigint", nullable: false),
                    MezziPatenteId = table.Column<long>(type: "bigint", nullable: false),
                    MezziPeriodoScadenzaId = table.Column<long>(type: "bigint", nullable: false),
                    Garanzia = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziVeicoli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaMezziVeicoli_GaMezziAlimentazioni_MezziAlimentazioneId",
                        column: x => x.MezziAlimentazioneId,
                        principalTable: "GaMezziAlimentazioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaMezziVeicoli_GaMezziCantieri_MezziCantiereId",
                        column: x => x.MezziCantiereId,
                        principalTable: "GaMezziCantieri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaMezziVeicoli_GaMezziClassi_MezziClasseId",
                        column: x => x.MezziClasseId,
                        principalTable: "GaMezziClassi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaMezziVeicoli_GaMezziPatenti_MezziPatenteId",
                        column: x => x.MezziPatenteId,
                        principalTable: "GaMezziPatenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaMezziVeicoli_GaMezziPeriodiScadenze_MezziPeriodoScadenzaId",
                        column: x => x.MezziPeriodoScadenzaId,
                        principalTable: "GaMezziPeriodiScadenze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaMezziVeicoli_GaMezziProprietari_MezziProprietarioId",
                        column: x => x.MezziProprietarioId,
                        principalTable: "GaMezziProprietari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaMezziVeicoli_GaMezziTipi_MezziTipoId",
                        column: x => x.MezziTipoId,
                        principalTable: "GaMezziTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziDocumenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MezziVeicoloId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziDocumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaMezziDocumenti_GaMezziVeicoli_MezziVeicoloId",
                        column: x => x.MezziVeicoloId,
                        principalTable: "GaMezziVeicoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaMezziScadenze",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MezziVeicoloId = table.Column<long>(type: "bigint", nullable: false),
                    MezziScadenzaTipoId = table.Column<long>(type: "bigint", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaScadenza = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziScadenze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaMezziScadenze_GaMezziScadenzeTipi_MezziScadenzaTipoId",
                        column: x => x.MezziScadenzaTipoId,
                        principalTable: "GaMezziScadenzeTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaMezziScadenze_GaMezziVeicoli_MezziVeicoloId",
                        column: x => x.MezziVeicoloId,
                        principalTable: "GaMezziVeicoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziDocumenti_MezziVeicoloId",
                table: "GaMezziDocumenti",
                column: "MezziVeicoloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziScadenze_MezziScadenzaTipoId",
                table: "GaMezziScadenze",
                column: "MezziScadenzaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziScadenze_MezziVeicoloId",
                table: "GaMezziScadenze",
                column: "MezziVeicoloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziVeicoli_MezziAlimentazioneId",
                table: "GaMezziVeicoli",
                column: "MezziAlimentazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziVeicoli_MezziCantiereId",
                table: "GaMezziVeicoli",
                column: "MezziCantiereId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziVeicoli_MezziClasseId",
                table: "GaMezziVeicoli",
                column: "MezziClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziVeicoli_MezziPatenteId",
                table: "GaMezziVeicoli",
                column: "MezziPatenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziVeicoli_MezziPeriodoScadenzaId",
                table: "GaMezziVeicoli",
                column: "MezziPeriodoScadenzaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziVeicoli_MezziProprietarioId",
                table: "GaMezziVeicoli",
                column: "MezziProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaMezziVeicoli_MezziTipoId",
                table: "GaMezziVeicoli",
                column: "MezziTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaMezziDocumenti");

            migrationBuilder.DropTable(
                name: "GaMezziScadenze");

            migrationBuilder.DropTable(
                name: "GaMezziScadenzeTipi");

            migrationBuilder.DropTable(
                name: "GaMezziVeicoli");

            migrationBuilder.DropTable(
                name: "GaMezziAlimentazioni");

            migrationBuilder.DropTable(
                name: "GaMezziCantieri");

            migrationBuilder.DropTable(
                name: "GaMezziClassi");

            migrationBuilder.DropTable(
                name: "GaMezziPatenti");

            migrationBuilder.DropTable(
                name: "GaMezziPeriodiScadenze");

            migrationBuilder.DropTable(
                name: "GaMezziProprietari");

            migrationBuilder.DropTable(
                name: "GaMezziTipi");
        }
    }
}
