using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaCrmEventAreas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCrmEventAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCrmEventStates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCrmEventStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCrmEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodAzi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodCli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpRowNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSchedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RagSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cellulare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCiv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domest = table.Column<bool>(type: "bit", nullable: false),
                    CrmEventStateId = table.Column<long>(type: "bigint", nullable: false),
                    CrmEventAreaId = table.Column<long>(type: "bigint", nullable: false),
                    CrmTicketId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCrmEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCrmEvents_GaCrmEventAreas_CrmEventAreaId",
                        column: x => x.CrmEventAreaId,
                        principalTable: "GaCrmEventAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCrmEvents_GaCrmEventStates_CrmEventStateId",
                        column: x => x.CrmEventStateId,
                        principalTable: "GaCrmEventStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmEvents_CrmEventAreaId",
                table: "GaCrmEvents",
                column: "CrmEventAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmEvents_CrmEventStateId",
                table: "GaCrmEvents",
                column: "CrmEventStateId");

            // InitData EventStates
            migrationBuilder.InsertData(
                table: "GaCrmEventStates",
                columns: new[] { "Id", "Descrizione", "Disabled" },
                values: new object[,]
                {
            { 1, "In Lavorazione", false},
            { 2, "Completato" , false},
            { 3, "Riprogrammato", false },
            { 4, "Annullato", false },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaCrmEvents");

            migrationBuilder.DropTable(
                name: "GaCrmEventAreas");

            migrationBuilder.DropTable(
                name: "GaCrmEventStates");
        }
    }
}
