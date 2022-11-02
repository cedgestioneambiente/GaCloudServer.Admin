using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPersonale_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "GaPersonaleDipendentiScadenze",
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
                    table.PrimaryKey("PK_GaPersonaleDipendentiScadenze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPersonaleDipendentiScadenze_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleDipendentiScadenze_GaPersonaleScadenzeDettagli_PersonaleScadenzaDettaglioId",
                        column: x => x.PersonaleScadenzaDettaglioId,
                        principalTable: "GaPersonaleScadenzeDettagli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPersonaleDipendentiScadenze_GaPersonaleScadenzeTipi_PersonaleScadenzaTipoId",
                        column: x => x.PersonaleScadenzaTipoId,
                        principalTable: "GaPersonaleScadenzeTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleDipendentiScadenze_PersonaleDipendenteId",
                table: "GaPersonaleDipendentiScadenze",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleDipendentiScadenze_PersonaleScadenzaDettaglioId",
                table: "GaPersonaleDipendentiScadenze",
                column: "PersonaleScadenzaDettaglioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleDipendentiScadenze_PersonaleScadenzaTipoId",
                table: "GaPersonaleDipendentiScadenze",
                column: "PersonaleScadenzaTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPersonaleDipendentiScadenze");

            migrationBuilder.DropTable(
                name: "GaPersonaleScadenzeDettagli");

            migrationBuilder.DropTable(
                name: "GaPersonaleScadenzeTipi");
        }
    }
}
