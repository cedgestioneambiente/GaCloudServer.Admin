using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCsr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaCsrCodiciCers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modalita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCsrCodiciCers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCsrComuni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCsrComuni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCsrDestinatari",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCsrDestinatari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCsrProduttori",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCsrProduttori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCsrTrasportatori",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCsrTrasportatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCsrRipartizioniPercentuali",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CsrComuneId = table.Column<long>(type: "bigint", nullable: false),
                    CsrProduttoreId = table.Column<long>(type: "bigint", nullable: false),
                    Percentuale = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCsrRipartizioniPercentuali", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCsrRipartizioniPercentuali_GaCsrComuni_CsrComuneId",
                        column: x => x.CsrComuneId,
                        principalTable: "GaCsrComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCsrRipartizioniPercentuali_GaCsrProduttori_CsrProduttoreId",
                        column: x => x.CsrProduttoreId,
                        principalTable: "GaCsrProduttori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaCsrRegistrazioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CsrComuneId = table.Column<long>(type: "bigint", nullable: false),
                    CsrCodiceCerId = table.Column<long>(type: "bigint", nullable: false),
                    CsrDestinatarioId = table.Column<long>(type: "bigint", nullable: false),
                    CsrTrasportatoreId = table.Column<long>(type: "bigint", nullable: false),
                    PesoTotale = table.Column<int>(type: "int", nullable: false),
                    Operazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCsrRegistrazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioni_GaCsrCodiciCers_CsrCodiceCerId",
                        column: x => x.CsrCodiceCerId,
                        principalTable: "GaCsrCodiciCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioni_GaCsrComuni_CsrComuneId",
                        column: x => x.CsrComuneId,
                        principalTable: "GaCsrComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioni_GaCsrDestinatari_CsrDestinatarioId",
                        column: x => x.CsrDestinatarioId,
                        principalTable: "GaCsrDestinatari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioni_GaCsrTrasportatori_CsrTrasportatoreId",
                        column: x => x.CsrTrasportatoreId,
                        principalTable: "GaCsrTrasportatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaCsrRegistrazioniPesi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CsrProduttoreId = table.Column<long>(type: "bigint", nullable: false),
                    CsrCodiceCerId = table.Column<long>(type: "bigint", nullable: false),
                    CsrDestinatarioId = table.Column<long>(type: "bigint", nullable: false),
                    CsrTrasportatoreId = table.Column<long>(type: "bigint", nullable: false),
                    CsrComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Percentuale = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    CsrRegistrazioneId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCsrRegistrazioniPesi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioniPesi_GaCsrCodiciCers_CsrCodiceCerId",
                        column: x => x.CsrCodiceCerId,
                        principalTable: "GaCsrCodiciCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioniPesi_GaCsrDestinatari_CsrDestinatarioId",
                        column: x => x.CsrDestinatarioId,
                        principalTable: "GaCsrDestinatari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioniPesi_GaCsrProduttori_CsrProduttoreId",
                        column: x => x.CsrProduttoreId,
                        principalTable: "GaCsrProduttori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioniPesi_GaCsrRegistrazioni_CsrRegistrazioneId",
                        column: x => x.CsrRegistrazioneId,
                        principalTable: "GaCsrRegistrazioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCsrRegistrazioniPesi_GaCsrTrasportatori_CsrTrasportatoreId",
                        column: x => x.CsrTrasportatoreId,
                        principalTable: "GaCsrTrasportatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioni_CsrCodiceCerId",
                table: "GaCsrRegistrazioni",
                column: "CsrCodiceCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioni_CsrComuneId",
                table: "GaCsrRegistrazioni",
                column: "CsrComuneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioni_CsrDestinatarioId",
                table: "GaCsrRegistrazioni",
                column: "CsrDestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioni_CsrTrasportatoreId",
                table: "GaCsrRegistrazioni",
                column: "CsrTrasportatoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioniPesi_CsrCodiceCerId",
                table: "GaCsrRegistrazioniPesi",
                column: "CsrCodiceCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioniPesi_CsrDestinatarioId",
                table: "GaCsrRegistrazioniPesi",
                column: "CsrDestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioniPesi_CsrProduttoreId",
                table: "GaCsrRegistrazioniPesi",
                column: "CsrProduttoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioniPesi_CsrRegistrazioneId",
                table: "GaCsrRegistrazioniPesi",
                column: "CsrRegistrazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRegistrazioniPesi_CsrTrasportatoreId",
                table: "GaCsrRegistrazioniPesi",
                column: "CsrTrasportatoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRipartizioniPercentuali_CsrComuneId",
                table: "GaCsrRipartizioniPercentuali",
                column: "CsrComuneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCsrRipartizioniPercentuali_CsrProduttoreId",
                table: "GaCsrRipartizioniPercentuali",
                column: "CsrProduttoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaCsrRegistrazioniPesi");

            migrationBuilder.DropTable(
                name: "GaCsrRipartizioniPercentuali");

            migrationBuilder.DropTable(
                name: "GaCsrRegistrazioni");

            migrationBuilder.DropTable(
                name: "GaCsrProduttori");

            migrationBuilder.DropTable(
                name: "GaCsrCodiciCers");

            migrationBuilder.DropTable(
                name: "GaCsrComuni");

            migrationBuilder.DropTable(
                name: "GaCsrDestinatari");

            migrationBuilder.DropTable(
                name: "GaCsrTrasportatori");
        }
    }
}
