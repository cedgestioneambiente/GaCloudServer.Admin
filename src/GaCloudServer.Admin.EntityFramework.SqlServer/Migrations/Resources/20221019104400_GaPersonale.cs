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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPersonaleDipendenti");

            migrationBuilder.DropTable(
                name: "GaPersonaleAssunzioni");

            migrationBuilder.DropTable(
                name: "GaPersonaleQualifiche");
        }
    }
}
