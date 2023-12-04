using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPrevisio_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPrevisioAnomalieLetture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteSegnalazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteGestione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gestito = table.Column<bool>(type: "bit", nullable: false),
                    Evento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCont = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contratto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Utenza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Longitudine = table.Column<double>(type: "float", nullable: false),
                    Latitudine = table.Column<double>(type: "float", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPrevisioAnomalieLetture", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPrevisioAnomalieLetture");
        }
    }
}
