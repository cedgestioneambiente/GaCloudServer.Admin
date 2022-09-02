using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaAutorizzazioni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaAutorizzazioniTipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaAutorizzazioniTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaAutorizzazioniDocumenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorizzazioniTipoId = table.Column<long>(type: "bigint", nullable: false),
                    DataRilascio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preavviso = table.Column<int>(type: "int", nullable: false),
                    Archiviata = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaAutorizzazioniDocumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaAutorizzazioniDocumenti_GaAutorizzazioniTipi_AutorizzazioniTipoId",
                        column: x => x.AutorizzazioniTipoId,
                        principalTable: "GaAutorizzazioniTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaAutorizzazioniAllegati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutorizzazioniDocumentoId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_GaAutorizzazioniAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaAutorizzazioniAllegati_GaAutorizzazioniDocumenti_AutorizzazioniDocumentoId",
                        column: x => x.AutorizzazioniDocumentoId,
                        principalTable: "GaAutorizzazioniDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaAutorizzazioniAllegati_AutorizzazioniDocumentoId",
                table: "GaAutorizzazioniAllegati",
                column: "AutorizzazioniDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaAutorizzazioniDocumenti_AutorizzazioniTipoId",
                table: "GaAutorizzazioniDocumenti",
                column: "AutorizzazioniTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaAutorizzazioniAllegati");

            migrationBuilder.DropTable(
                name: "GaAutorizzazioniDocumenti");

            migrationBuilder.DropTable(
                name: "GaAutorizzazioniTipi");
        }
    }
}
