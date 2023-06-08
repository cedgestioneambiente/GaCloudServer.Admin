using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Consorzio_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsorzioCers_ConsorzioCersSmaltimenti_ConsorzioCerSmaltimentoId",
                table: "ConsorzioCers");

            migrationBuilder.DropTable(
                name: "ConsorzioCersSmaltimenti");

            migrationBuilder.DropIndex(
                name: "IX_ConsorzioCers_ConsorzioCerSmaltimentoId",
                table: "ConsorzioCers");

            migrationBuilder.DropColumn(
                name: "Operazione",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropColumn(
                name: "ConsorzioCerSmaltimentoId",
                table: "ConsorzioCers");

            migrationBuilder.RenameColumn(
                name: "CdPiva",
                table: "ConsorzioTrasportatori",
                newName: "CfPiva");

            migrationBuilder.RenameColumn(
                name: "CdPiva",
                table: "ConsorzioProduttori",
                newName: "CfPiva");

            migrationBuilder.RenameColumn(
                name: "CdPiva",
                table: "ConsorzioDestinatari",
                newName: "CfPiva");

            migrationBuilder.AddColumn<long>(
                name: "ConsorzioOperazioneId",
                table: "ConsorzioRegistrazioni",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ConsorzioPeriodoId",
                table: "ConsorzioRegistrazioni",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ConsorzioPeriodi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Giorni = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioPeriodi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioSmaltimenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioSmaltimenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsorzioOperazioni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsorzioSmaltimentoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioOperazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsorzioOperazioni_ConsorzioSmaltimenti_ConsorzioSmaltimentoId",
                        column: x => x.ConsorzioSmaltimentoId,
                        principalTable: "ConsorzioSmaltimenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioRegistrazioni_ConsorzioOperazioneId",
                table: "ConsorzioRegistrazioni",
                column: "ConsorzioOperazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioRegistrazioni_ConsorzioPeriodoId",
                table: "ConsorzioRegistrazioni",
                column: "ConsorzioPeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioOperazioni_ConsorzioSmaltimentoId",
                table: "ConsorzioOperazioni",
                column: "ConsorzioSmaltimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsorzioRegistrazioni_ConsorzioOperazioni_ConsorzioOperazioneId",
                table: "ConsorzioRegistrazioni",
                column: "ConsorzioOperazioneId",
                principalTable: "ConsorzioOperazioni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsorzioRegistrazioni_ConsorzioPeriodi_ConsorzioPeriodoId",
                table: "ConsorzioRegistrazioni",
                column: "ConsorzioPeriodoId",
                principalTable: "ConsorzioPeriodi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsorzioRegistrazioni_ConsorzioOperazioni_ConsorzioOperazioneId",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsorzioRegistrazioni_ConsorzioPeriodi_ConsorzioPeriodoId",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropTable(
                name: "ConsorzioOperazioni");

            migrationBuilder.DropTable(
                name: "ConsorzioPeriodi");

            migrationBuilder.DropTable(
                name: "ConsorzioSmaltimenti");

            migrationBuilder.DropIndex(
                name: "IX_ConsorzioRegistrazioni_ConsorzioOperazioneId",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropIndex(
                name: "IX_ConsorzioRegistrazioni_ConsorzioPeriodoId",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropColumn(
                name: "ConsorzioOperazioneId",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.DropColumn(
                name: "ConsorzioPeriodoId",
                table: "ConsorzioRegistrazioni");

            migrationBuilder.RenameColumn(
                name: "CfPiva",
                table: "ConsorzioTrasportatori",
                newName: "CdPiva");

            migrationBuilder.RenameColumn(
                name: "CfPiva",
                table: "ConsorzioProduttori",
                newName: "CdPiva");

            migrationBuilder.RenameColumn(
                name: "CfPiva",
                table: "ConsorzioDestinatari",
                newName: "CdPiva");

            migrationBuilder.AddColumn<string>(
                name: "Operazione",
                table: "ConsorzioRegistrazioni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConsorzioCerSmaltimentoId",
                table: "ConsorzioCers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ConsorzioCersSmaltimenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioCersSmaltimenti", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioCers_ConsorzioCerSmaltimentoId",
                table: "ConsorzioCers",
                column: "ConsorzioCerSmaltimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsorzioCers_ConsorzioCersSmaltimenti_ConsorzioCerSmaltimentoId",
                table: "ConsorzioCers",
                column: "ConsorzioCerSmaltimentoId",
                principalTable: "ConsorzioCersSmaltimenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
