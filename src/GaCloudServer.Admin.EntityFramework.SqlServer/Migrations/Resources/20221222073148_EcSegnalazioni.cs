using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class EcSegnalazioni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EcSegnalazioniStati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcSegnalazioniStati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EcSegnalazioniTipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcSegnalazioniTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EcSegnalazioniDocumenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegnalazioniTipoId = table.Column<long>(type: "bigint", nullable: false),
                    SegnalazioniStatoId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitudine = table.Column<float>(type: "real", nullable: false),
                    Latitudine = table.Column<float>(type: "real", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataOra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sanzione = table.Column<bool>(type: "bit", nullable: false),
                    NoteSanzione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteGestione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcSegnalazioniDocumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcSegnalazioniDocumenti_EcSegnalazioniStati_SegnalazioniStatoId",
                        column: x => x.SegnalazioniStatoId,
                        principalTable: "EcSegnalazioniStati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EcSegnalazioniDocumenti_EcSegnalazioniTipi_SegnalazioniTipoId",
                        column: x => x.SegnalazioniTipoId,
                        principalTable: "EcSegnalazioniTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EcSegnalazioniAllegati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegnalazioniDocumentoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcSegnalazioniAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcSegnalazioniAllegati_EcSegnalazioniDocumenti_SegnalazioniDocumentoId",
                        column: x => x.SegnalazioniDocumentoId,
                        principalTable: "EcSegnalazioniDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcSegnalazioniAllegati_SegnalazioniDocumentoId",
                table: "EcSegnalazioniAllegati",
                column: "SegnalazioniDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EcSegnalazioniDocumenti_SegnalazioniStatoId",
                table: "EcSegnalazioniDocumenti",
                column: "SegnalazioniStatoId");

            migrationBuilder.CreateIndex(
                name: "IX_EcSegnalazioniDocumenti_SegnalazioniTipoId",
                table: "EcSegnalazioniDocumenti",
                column: "SegnalazioniTipoId");

            migrationBuilder.InsertData(
            table: "EcSegnalazioniStati",
            columns: new[] { "Id", "Descrizione", "Disabled" },
            values: new object[,]
            {
                                { 1,"NUOVA" ,false},
                                { 2,"IN GESTIONE" ,false},
                                { 3,"GESTITA" ,false},
                                { 4,"ANNULLATA" ,false},
            });



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcSegnalazioniAllegati");

            migrationBuilder.DropTable(
                name: "EcSegnalazioniDocumenti");

            migrationBuilder.DropTable(
                name: "EcSegnalazioniStati");

            migrationBuilder.DropTable(
                name: "EcSegnalazioniTipi");
        }
    }
}
