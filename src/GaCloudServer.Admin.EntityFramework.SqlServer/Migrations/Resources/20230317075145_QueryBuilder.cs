using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class QueryBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcSegnalazioniAllegati");

            migrationBuilder.CreateTable(
                name: "EcSegnalazioniDocumentiImmagini",
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
                    table.PrimaryKey("PK_EcSegnalazioniDocumentiImmagini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcSegnalazioniDocumentiImmagini_EcSegnalazioniDocumenti_SegnalazioniDocumentoId",
                        column: x => x.SegnalazioniDocumentoId,
                        principalTable: "EcSegnalazioniDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueryBuilderParamTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryBuilderParamTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QueryBuilderSections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryBuilderSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QueryBuilderScripts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueryBuilderSectionId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryBuilderScripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueryBuilderScripts_QueryBuilderSections_QueryBuilderSectionId",
                        column: x => x.QueryBuilderSectionId,
                        principalTable: "QueryBuilderSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueryBuilderParamOnScripts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueryBuilderScriptId = table.Column<long>(type: "bigint", nullable: false),
                    QueryBuilderParamTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryBuilderParamOnScripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueryBuilderParamOnScripts_QueryBuilderParamTypes_QueryBuilderParamTypeId",
                        column: x => x.QueryBuilderParamTypeId,
                        principalTable: "QueryBuilderParamTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QueryBuilderParamOnScripts_QueryBuilderScripts_QueryBuilderScriptId",
                        column: x => x.QueryBuilderScriptId,
                        principalTable: "QueryBuilderScripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcSegnalazioniDocumentiImmagini_SegnalazioniDocumentoId",
                table: "EcSegnalazioniDocumentiImmagini",
                column: "SegnalazioniDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryBuilderParamOnScripts_QueryBuilderParamTypeId",
                table: "QueryBuilderParamOnScripts",
                column: "QueryBuilderParamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryBuilderParamOnScripts_QueryBuilderScriptId",
                table: "QueryBuilderParamOnScripts",
                column: "QueryBuilderScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryBuilderScripts_QueryBuilderSectionId",
                table: "QueryBuilderScripts",
                column: "QueryBuilderSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcSegnalazioniDocumentiImmagini");

            migrationBuilder.DropTable(
                name: "QueryBuilderParamOnScripts");

            migrationBuilder.DropTable(
                name: "QueryBuilderParamTypes");

            migrationBuilder.DropTable(
                name: "QueryBuilderScripts");

            migrationBuilder.DropTable(
                name: "QueryBuilderSections");

            migrationBuilder.CreateTable(
                name: "EcSegnalazioniAllegati",
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
                    table.PrimaryKey("PK_EcSegnalazioniAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcSegnalazioniAllegati_EcSegnalazioniDocumenti_SegnalazioniDocumentoId",
                        column: x => x.SegnalazioniDocumentoId,
                        principalTable: "EcSegnalazioniDocumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcSegnalazioniAllegati_SegnalazioniDocumentoId",
                table: "EcSegnalazioniAllegati",
                column: "SegnalazioniDocumentoId");
        }
    }
}
