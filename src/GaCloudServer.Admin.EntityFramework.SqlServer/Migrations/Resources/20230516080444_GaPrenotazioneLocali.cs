using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPrenotazioneLocali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPrenotazioneLocaliSedi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPrenotazioneLocaliSedi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPrenotazioneLocaliUffici",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenotazioneLocaliSedeId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPrenotazioneLocaliUffici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPrenotazioneLocaliUffici_GaPrenotazioneLocaliSedi_PrenotazioneLocaliSedeId",
                        column: x => x.PrenotazioneLocaliSedeId,
                        principalTable: "GaPrenotazioneLocaliSedi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPrenotazioneLocaliRegistrazioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InteraGiornata = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motivazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenotazioneLocaliUfficioId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPrenotazioneLocaliRegistrazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPrenotazioneLocaliRegistrazioni_GaPrenotazioneLocaliUffici_PrenotazioneLocaliUfficioId",
                        column: x => x.PrenotazioneLocaliUfficioId,
                        principalTable: "GaPrenotazioneLocaliUffici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPrenotazioneLocaliRegistrazioni_PrenotazioneLocaliUfficioId",
                table: "GaPrenotazioneLocaliRegistrazioni",
                column: "PrenotazioneLocaliUfficioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPrenotazioneLocaliUffici_PrenotazioneLocaliSedeId",
                table: "GaPrenotazioneLocaliUffici",
                column: "PrenotazioneLocaliSedeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPrenotazioneLocaliRegistrazioni");

            migrationBuilder.DropTable(
                name: "GaPrenotazioneLocaliUffici");

            migrationBuilder.DropTable(
                name: "GaPrenotazioneLocaliSedi");
        }
    }
}
