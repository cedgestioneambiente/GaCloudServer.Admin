using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaSegnalazioni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaSegnalazioniStati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaSegnalazioniStati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaSegnalazioniTipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaSegnalazioniTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaSegnalazioniDocumenti",
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
                    table.PrimaryKey("PK_GaSegnalazioniDocumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaSegnalazioniDocumenti_GaSegnalazioniStati_SegnalazioniStatoId",
                        column: x => x.SegnalazioniStatoId,
                        principalTable: "GaSegnalazioniStati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaSegnalazioniDocumenti_GaSegnalazioniTipi_SegnalazioniTipoId",
                        column: x => x.SegnalazioniTipoId,
                        principalTable: "GaSegnalazioniTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaSegnalazioniAllegati",
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
                    table.PrimaryKey("PK_GaSegnalazioniAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaSegnalazioniAllegati_GaSegnalazioniDocumenti_SegnalazioniDocumentoId",
                        column: x => x.SegnalazioniDocumentoId,
                        principalTable: "GaSegnalazioniDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaSegnalazioniAllegati_SegnalazioniDocumentoId",
                table: "GaSegnalazioniAllegati",
                column: "SegnalazioniDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaSegnalazioniDocumenti_SegnalazioniStatoId",
                table: "GaSegnalazioniDocumenti",
                column: "SegnalazioniStatoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaSegnalazioniDocumenti_SegnalazioniTipoId",
                table: "GaSegnalazioniDocumenti",
                column: "SegnalazioniTipoId");


            migrationBuilder.InsertData(
            table: "GaSegnalazioniStati",
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
                name: "GaSegnalazioniAllegati");

            migrationBuilder.DropTable(
                name: "GaSegnalazioniDocumenti");

            migrationBuilder.DropTable(
                name: "GaSegnalazioniStati");

            migrationBuilder.DropTable(
                name: "GaSegnalazioniTipi");
        }
    }
}
