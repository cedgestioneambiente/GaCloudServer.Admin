using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPresenze_V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPresenzeRichieste_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropIndex(
                name: "IX_GaPresenzeRichieste_PersonaleDipendenteId",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropColumn(
                name: "PersonaleDipendenteId",
                table: "GaPresenzeRichieste");

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeRichieste_PresenzeDipendenteId",
                table: "GaPresenzeRichieste",
                column: "PresenzeDipendenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPresenzeRichieste_GaPresenzeDipendenti_PresenzeDipendenteId",
                table: "GaPresenzeRichieste",
                column: "PresenzeDipendenteId",
                principalTable: "GaPresenzeDipendenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPresenzeRichieste_GaPresenzeDipendenti_PresenzeDipendenteId",
                table: "GaPresenzeRichieste");

            migrationBuilder.DropIndex(
                name: "IX_GaPresenzeRichieste_PresenzeDipendenteId",
                table: "GaPresenzeRichieste");

            migrationBuilder.AddColumn<long>(
                name: "PersonaleDipendenteId",
                table: "GaPresenzeRichieste",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaPresenzeRichieste_PersonaleDipendenteId",
                table: "GaPresenzeRichieste",
                column: "PersonaleDipendenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPresenzeRichieste_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaPresenzeRichieste",
                column: "PersonaleDipendenteId",
                principalTable: "GaPersonaleDipendenti",
                principalColumn: "Id");
        }
    }
}
