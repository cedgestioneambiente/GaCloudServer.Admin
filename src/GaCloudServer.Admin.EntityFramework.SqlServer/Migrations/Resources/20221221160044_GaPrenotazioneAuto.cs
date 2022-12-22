using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPrenotazioneAuto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPrenotazioneAutoSedi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPrenotazioneAutoSedi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPrenotazioneAutoVeicoli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Targa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenotazioneAutoSedeId = table.Column<long>(type: "bigint", nullable: false),
                    Weekend = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPrenotazioneAutoVeicoli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPrenotazioneAutoVeicoli_GaPrenotazioneAutoSedi_PrenotazioneAutoSedeId",
                        column: x => x.PrenotazioneAutoSedeId,
                        principalTable: "GaPrenotazioneAutoSedi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPrenotazioneAutoRegistrazioni",
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
                    RealeUtilizzatore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenotazioneAutoVeicoloId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPrenotazioneAutoRegistrazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPrenotazioneAutoRegistrazioni_GaPrenotazioneAutoVeicoli_PrenotazioneAutoVeicoloId",
                        column: x => x.PrenotazioneAutoVeicoloId,
                        principalTable: "GaPrenotazioneAutoVeicoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPrenotazioneAutoRegistrazioni_PrenotazioneAutoVeicoloId",
                table: "GaPrenotazioneAutoRegistrazioni",
                column: "PrenotazioneAutoVeicoloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPrenotazioneAutoVeicoli_PrenotazioneAutoSedeId",
                table: "GaPrenotazioneAutoVeicoli",
                column: "PrenotazioneAutoSedeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPrenotazioneAutoRegistrazioni");

            migrationBuilder.DropTable(
                name: "GaPrenotazioneAutoVeicoli");

            migrationBuilder.DropTable(
                name: "GaPrenotazioneAutoSedi");
        }
    }
}
