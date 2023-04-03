using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContratti_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiFornitori_ContrattiFornitoreId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiServizi_ContrattiServizioId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropTable(
                name: "GaContrattiFornitori");

            migrationBuilder.DropIndex(
                name: "IX_GaContrattiDocumenti_ContrattiFornitoreId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "ContrattiFornitoreId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "Preventivo",
                table: "GaContrattiDocumenti");

            migrationBuilder.RenameColumn(
                name: "ContrattiServizioId",
                table: "GaContrattiDocumenti",
                newName: "ContrattiSoggettoId");

            migrationBuilder.RenameIndex(
                name: "IX_GaContrattiDocumenti_ContrattiServizioId",
                table: "GaContrattiDocumenti",
                newName: "IX_GaContrattiDocumenti_ContrattiSoggettoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataScadenza",
                table: "GaContrattiDocumenti",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ContrattiPreventivoId",
                table: "GaContrattiDocumenti",
                type: "bigint",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Permissions",
            //    table: "GaContrattiDocumenti",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "GaContrattiSoggetti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartitaIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SedeLegale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecapitoFatture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fornitore = table.Column<bool>(type: "bit", nullable: false),
                    Cliente = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiSoggetti", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiSoggetti_ContrattiSoggettoId",
                table: "GaContrattiDocumenti",
                column: "ContrattiSoggettoId",
                principalTable: "GaContrattiSoggetti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiSoggetti_ContrattiSoggettoId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropTable(
                name: "GaContrattiSoggetti");

            migrationBuilder.DropColumn(
                name: "ContrattiPreventivoId",
                table: "GaContrattiDocumenti");

            //migrationBuilder.DropColumn(
            //    name: "Permissions",
            //    table: "GaContrattiDocumenti");

            migrationBuilder.RenameColumn(
                name: "ContrattiSoggettoId",
                table: "GaContrattiDocumenti",
                newName: "ContrattiServizioId");

            migrationBuilder.RenameIndex(
                name: "IX_GaContrattiDocumenti_ContrattiSoggettoId",
                table: "GaContrattiDocumenti",
                newName: "IX_GaContrattiDocumenti_ContrattiServizioId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataScadenza",
                table: "GaContrattiDocumenti",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "ContrattiFornitoreId",
                table: "GaContrattiDocumenti",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Preventivo",
                table: "GaContrattiDocumenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "GaContrattiFornitori",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartitaIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecapitoFatture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SedeLegale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiFornitori", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiFornitoreId",
                table: "GaContrattiDocumenti",
                column: "ContrattiFornitoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiFornitori_ContrattiFornitoreId",
                table: "GaContrattiDocumenti",
                column: "ContrattiFornitoreId",
                principalTable: "GaContrattiFornitori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiServizi_ContrattiServizioId",
                table: "GaContrattiDocumenti",
                column: "ContrattiServizioId",
                principalTable: "GaContrattiServizi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
