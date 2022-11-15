using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Ga_EcSegnalazioni_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcSegnalazioniFotos");

            migrationBuilder.DropTable(
                name: "GaSegnalazioniFotos");

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
                name: "IX_EcSegnalazioniAllegati_SegnalazioniDocumentoId",
                table: "EcSegnalazioniAllegati",
                column: "SegnalazioniDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaSegnalazioniAllegati_SegnalazioniDocumentoId",
                table: "GaSegnalazioniAllegati",
                column: "SegnalazioniDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcSegnalazioniAllegati");

            migrationBuilder.DropTable(
                name: "GaSegnalazioniAllegati");

            migrationBuilder.CreateTable(
                name: "EcSegnalazioniFotos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegnalazioniDocumentoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcSegnalazioniFotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcSegnalazioniFotos_EcSegnalazioniDocumenti_SegnalazioniDocumentoId",
                        column: x => x.SegnalazioniDocumentoId,
                        principalTable: "EcSegnalazioniDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaSegnalazioniFotos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegnalazioniDocumentoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaSegnalazioniFotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaSegnalazioniFotos_GaSegnalazioniDocumenti_SegnalazioniDocumentoId",
                        column: x => x.SegnalazioniDocumentoId,
                        principalTable: "GaSegnalazioniDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcSegnalazioniFotos_SegnalazioniDocumentoId",
                table: "EcSegnalazioniFotos",
                column: "SegnalazioniDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaSegnalazioniFotos_SegnalazioniDocumentoId",
                table: "GaSegnalazioniFotos",
                column: "SegnalazioniDocumentoId");
        }
    }
}
