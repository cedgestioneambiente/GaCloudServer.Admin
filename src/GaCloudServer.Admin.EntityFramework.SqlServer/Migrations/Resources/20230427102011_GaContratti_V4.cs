using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContratti_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiModalitas_ContrattiModalitaId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropIndex(
                name: "IX_GaContrattiDocumenti_ContrattiModalitaId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "AffariGenerali",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "Commerciale",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "Comunicazione",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "Contabilita",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "ContrattiModalitaId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "ContrattiPreventivoId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "Direzione",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "Informatica",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "Personale",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "QualitaSicurezza",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "Tecnico",
                table: "GaContrattiDocumenti");

            migrationBuilder.RenameColumn(
                name: "PreventivoNumero",
                table: "GaContrattiDocumenti",
                newName: "ContrattiModalita");

            migrationBuilder.AlterColumn<bool>(
                name: "Routing",
                table: "NotificationEvents",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContrattiModalita",
                table: "GaContrattiDocumenti",
                newName: "PreventivoNumero");

            migrationBuilder.AlterColumn<bool>(
                name: "Routing",
                table: "NotificationEvents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AffariGenerali",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Commerciale",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Comunicazione",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Contabilita",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ContrattiModalitaId",
                table: "GaContrattiDocumenti",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ContrattiPreventivoId",
                table: "GaContrattiDocumenti",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Direzione",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Informatica",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Personale",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QualitaSicurezza",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tecnico",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiModalitaId",
                table: "GaContrattiDocumenti",
                column: "ContrattiModalitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiModalitas_ContrattiModalitaId",
                table: "GaContrattiDocumenti",
                column: "ContrattiModalitaId",
                principalTable: "GaContrattiModalitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
