using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContratti_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiTipologie_ContrattiTipologiaId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropIndex(
                name: "IX_GaContrattiDocumenti_ContrattiTipologiaId",
                table: "GaContrattiDocumenti");

            migrationBuilder.DropColumn(
                name: "ContrattiTipologiaId",
                table: "GaContrattiDocumenti");

            migrationBuilder.AddColumn<string>(
                name: "ContrattiTipologia",
                table: "GaContrattiDocumenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GaContrattiDocumentiAllegati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContrattiDocumentoId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiDocumentiAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContrattiDocumentiAllegati_GaContrattiDocumenti_ContrattiDocumentoId",
                        column: x => x.ContrattiDocumentoId,
                        principalTable: "GaContrattiDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumentiAllegati_ContrattiDocumentoId",
                table: "GaContrattiDocumentiAllegati",
                column: "ContrattiDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaContrattiDocumentiAllegati");

            migrationBuilder.DropColumn(
                name: "ContrattiTipologia",
                table: "GaContrattiDocumenti");

            migrationBuilder.AddColumn<long>(
                name: "ContrattiTipologiaId",
                table: "GaContrattiDocumenti",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiDocumenti_ContrattiTipologiaId",
                table: "GaContrattiDocumenti",
                column: "ContrattiTipologiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaContrattiDocumenti_GaContrattiTipologie_ContrattiTipologiaId",
                table: "GaContrattiDocumenti",
                column: "ContrattiTipologiaId",
                principalTable: "GaContrattiTipologie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
