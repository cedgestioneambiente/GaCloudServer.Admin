using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPresenze_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPresenzeRichieste_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaPresenzeRichieste");

            migrationBuilder.AlterColumn<long>(
                name: "PersonaleDipendenteId",
                table: "GaPresenzeRichieste",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PresenzeDipendenteId",
                table: "GaPresenzeRichieste",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "TotaleOre",
                table: "GaPresenzeRichieste",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "HhFerie",
                table: "GaPresenzeProfili",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GaPresenzeDateEscluse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeDateEscluse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeOrari",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeOrari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeDipendenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaleDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    Matricola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresenzeOrarioId = table.Column<long>(type: "bigint", nullable: false),
                    PresenzeProfiloId = table.Column<long>(type: "bigint", nullable: false),
                    HhFerie = table.Column<double>(type: "float", nullable: false),
                    GgFerie = table.Column<double>(type: "float", nullable: false),
                    GgPermessiCcnl = table.Column<double>(type: "float", nullable: false),
                    HhPermessiCcnl = table.Column<double>(type: "float", nullable: false),
                    HhRecupero = table.Column<double>(type: "float", nullable: false),
                    Abilitato = table.Column<bool>(type: "bit", nullable: false),
                    PrivilegiElevati = table.Column<bool>(type: "bit", nullable: false),
                    AutoApprova = table.Column<bool>(type: "bit", nullable: false),
                    SuperUser = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeDipendenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeDipendenti_GaPersonaleDipendenti_PersonaleDipendenteId",
                        column: x => x.PersonaleDipendenteId,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeDipendenti_GaPresenzeOrari_PresenzeOrarioId",
                        column: x => x.PresenzeOrarioId,
                        principalTable: "GaPresenzeOrari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeDipendenti_GaPresenzeProfili_PresenzeProfiloId",
                        column: x => x.PresenzeProfiloId,
                        principalTable: "GaPresenzeProfili",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeOrariGiornate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresenzeOrarioId = table.Column<long>(type: "bigint", nullable: false),
                    Giorno = table.Column<int>(type: "int", nullable: false),
                    OraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OraFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PausaInizio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PausaFine = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeOrariGiornate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeOrariGiornate_GaPresenzeOrari_PresenzeOrarioId",
                        column: x => x.PresenzeOrarioId,
                        principalTable: "GaPresenzeOrari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPresenzeBancheOreUtilizzi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresenzeDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    PresenzeRichiestaId = table.Column<long>(type: "bigint", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Qta = table.Column<double>(type: "float", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPresenzeBancheOreUtilizzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPresenzeBancheOreUtilizzi_GaPresenzeDipendenti_PresenzeDipendenteId",
                        column: x => x.PresenzeDipendenteId,
                        principalTable: "GaPresenzeDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPresenzeBancheOreUtilizzi_GaPresenzeRichieste_PresenzeRichiestaId",
                        column: x => x.PresenzeRichiestaId,
                        principalTable: "GaPresenzeRichieste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeBancheOreUtilizzi_PresenzeDipendenteId",
                table: "GaPresenzeBancheOreUtilizzi",
                column: "PresenzeDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeBancheOreUtilizzi_PresenzeRichiestaId",
                table: "GaPresenzeBancheOreUtilizzi",
                column: "PresenzeRichiestaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeDipendenti_PersonaleDipendenteId",
                table: "GaPresenzeDipendenti",
                column: "PersonaleDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeDipendenti_PresenzeOrarioId",
                table: "GaPresenzeDipendenti",
                column: "PresenzeOrarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeDipendenti_PresenzeProfiloId",
                table: "GaPresenzeDipendenti",
                column: "PresenzeProfiloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeOrariGiornate_PresenzeOrarioId",
                table: "GaPresenzeOrariGiornate",
                column: "PresenzeOrarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPresenzeRichieste_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaPresenzeRichieste",
                column: "PersonaleDipendenteId",
                principalTable: "GaPersonaleDipendenti",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPresenzeRichieste_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropTable(
                name: "GaPresenzeBancheOreUtilizzi");

            migrationBuilder.DropTable(
                name: "GaPresenzeDateEscluse");

            migrationBuilder.DropTable(
                name: "GaPresenzeOrariGiornate");

            migrationBuilder.DropTable(
                name: "GaPresenzeDipendenti");

            migrationBuilder.DropTable(
                name: "GaPresenzeOrari");

            migrationBuilder.DropColumn(
                name: "PresenzeDipendenteId",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropColumn(
                name: "TotaleOre",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropColumn(
                name: "HhFerie",
                table: "GaPresenzeProfili");

            migrationBuilder.AlterColumn<long>(
                name: "PersonaleDipendenteId",
                table: "GaPresenzeRichieste",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GaPresenzeRichieste_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaPresenzeRichieste",
                column: "PersonaleDipendenteId",
                principalTable: "GaPersonaleDipendenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
