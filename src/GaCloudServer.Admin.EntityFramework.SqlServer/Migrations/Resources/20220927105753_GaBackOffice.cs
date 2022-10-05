using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaBackOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaBackOfficeParametriOnCategorie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KgMqAnnui = table.Column<double>(type: "float", nullable: false),
                    KgMqSmaltimento = table.Column<double>(type: "float", nullable: false),
                    KgMqSmaltimentoGg = table.Column<double>(type: "float", nullable: false),
                    KgMqRecupero = table.Column<double>(type: "float", nullable: false),
                    KgMqRecuperoGg = table.Column<double>(type: "float", nullable: false),
                    PercentualeCarta = table.Column<double>(type: "float", nullable: false),
                    PercentualePlastica = table.Column<double>(type: "float", nullable: false),
                    PercentualeVetro = table.Column<double>(type: "float", nullable: false),
                    PercentualeUmido = table.Column<double>(type: "float", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Kc = table.Column<double>(type: "float", nullable: false),
                    Kd = table.Column<double>(type: "float", nullable: false),
                    NumeroSvuotamenti = table.Column<int>(type: "int", nullable: false),
                    TFissa = table.Column<double>(type: "float", nullable: false),
                    TVarCalcolata = table.Column<double>(type: "float", nullable: false),
                    TVarMisurata = table.Column<double>(type: "float", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaBackOfficeParametriOnCategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaBackOfficeStatiTickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaBackOfficeStatiTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaBackOfficeTipiTickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaBackOfficeTipiTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaBackOfficeTickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BackOfficeTipoTicketId = table.Column<long>(type: "bigint", nullable: false),
                    NumCon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackOfficeStatoTicketId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaBackOfficeTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaBackOfficeTickets_GaBackOfficeStatiTickets_BackOfficeStatoTicketId",
                        column: x => x.BackOfficeStatoTicketId,
                        principalTable: "GaBackOfficeStatiTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaBackOfficeTickets_GaBackOfficeTipiTickets_BackOfficeTipoTicketId",
                        column: x => x.BackOfficeTipoTicketId,
                        principalTable: "GaBackOfficeTipiTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaBackOfficeTickets_BackOfficeStatoTicketId",
                table: "GaBackOfficeTickets",
                column: "BackOfficeStatoTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_GaBackOfficeTickets_BackOfficeTipoTicketId",
                table: "GaBackOfficeTickets",
                column: "BackOfficeTipoTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaBackOfficeParametriOnCategorie");

            migrationBuilder.DropTable(
                name: "GaBackOfficeTickets");

            migrationBuilder.DropTable(
                name: "GaBackOfficeStatiTickets");

            migrationBuilder.DropTable(
                name: "GaBackOfficeTipiTickets");
        }
    }
}
