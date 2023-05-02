using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Consorzio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsorzioCersSmaltimenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioCersSmaltimenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioComuni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioComuni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioCers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pericoloso = table.Column<bool>(type: "bit", nullable: false),
                    Immagine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsorzioCerSmaltimentoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioCers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsorzioCers_ConsorzioCersSmaltimenti_ConsorzioCerSmaltimentoId",
                        column: x => x.ConsorzioCerSmaltimentoId,
                        principalTable: "ConsorzioCersSmaltimenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioDestinatari",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsorzioComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CdPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioDestinatari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsorzioDestinatari_ConsorzioComuni_ConsorzioComuneId",
                        column: x => x.ConsorzioComuneId,
                        principalTable: "ConsorzioComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioProduttori",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsorzioComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CdPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioProduttori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsorzioProduttori_ConsorzioComuni_ConsorzioComuneId",
                        column: x => x.ConsorzioComuneId,
                        principalTable: "ConsorzioComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioTrasportatori",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsorzioComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CdPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioTrasportatori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsorzioTrasportatori_ConsorzioComuni_ConsorzioComuneId",
                        column: x => x.ConsorzioComuneId,
                        principalTable: "ConsorzioComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioRegistrazioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesoTotale = table.Column<float>(type: "real", nullable: false),
                    Operazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRegistrazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsorzioCerId = table.Column<long>(type: "bigint", nullable: false),
                    ConsorzioProduttoreId = table.Column<long>(type: "bigint", nullable: false),
                    ConsorzioTrasportatoreId = table.Column<long>(type: "bigint", nullable: false),
                    ConsorzioDestinatarioId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioRegistrazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsorzioRegistrazioni_ConsorzioCers_ConsorzioCerId",
                        column: x => x.ConsorzioCerId,
                        principalTable: "ConsorzioCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsorzioRegistrazioni_ConsorzioDestinatari_ConsorzioDestinatarioId",
                        column: x => x.ConsorzioDestinatarioId,
                        principalTable: "ConsorzioDestinatari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsorzioRegistrazioni_ConsorzioProduttori_ConsorzioProduttoreId",
                        column: x => x.ConsorzioProduttoreId,
                        principalTable: "ConsorzioProduttori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsorzioRegistrazioni_ConsorzioTrasportatori_ConsorzioTrasportatoreId",
                        column: x => x.ConsorzioTrasportatoreId,
                        principalTable: "ConsorzioTrasportatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioRegistrazioniAllegati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsorzioRegistrazioneId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioRegistrazioniAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsorzioRegistrazioniAllegati_ConsorzioRegistrazioni_ConsorzioRegistrazioneId",
                        column: x => x.ConsorzioRegistrazioneId,
                        principalTable: "ConsorzioRegistrazioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioCers_ConsorzioCerSmaltimentoId",
                table: "ConsorzioCers",
                column: "ConsorzioCerSmaltimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioDestinatari_ConsorzioComuneId",
                table: "ConsorzioDestinatari",
                column: "ConsorzioComuneId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioProduttori_ConsorzioComuneId",
                table: "ConsorzioProduttori",
                column: "ConsorzioComuneId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioRegistrazioni_ConsorzioCerId",
                table: "ConsorzioRegistrazioni",
                column: "ConsorzioCerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioRegistrazioni_ConsorzioDestinatarioId",
                table: "ConsorzioRegistrazioni",
                column: "ConsorzioDestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioRegistrazioni_ConsorzioProduttoreId",
                table: "ConsorzioRegistrazioni",
                column: "ConsorzioProduttoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioRegistrazioni_ConsorzioTrasportatoreId",
                table: "ConsorzioRegistrazioni",
                column: "ConsorzioTrasportatoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioRegistrazioniAllegati_ConsorzioRegistrazioneId",
                table: "ConsorzioRegistrazioniAllegati",
                column: "ConsorzioRegistrazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioTrasportatori_ConsorzioComuneId",
                table: "ConsorzioTrasportatori",
                column: "ConsorzioComuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsorzioRegistrazioniAllegati");

            migrationBuilder.DropTable(
                name: "ConsorzioRegistrazioni");

            migrationBuilder.DropTable(
                name: "ConsorzioCers");

            migrationBuilder.DropTable(
                name: "ConsorzioDestinatari");

            migrationBuilder.DropTable(
                name: "ConsorzioProduttori");

            migrationBuilder.DropTable(
                name: "ConsorzioTrasportatori");

            migrationBuilder.DropTable(
                name: "ConsorzioCersSmaltimenti");

            migrationBuilder.DropTable(
                name: "ConsorzioComuni");
        }
    }
}
