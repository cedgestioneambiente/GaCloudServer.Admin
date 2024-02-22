using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPreventiviAnticipiPagamenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviAnticipiPagamenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviAnticipiTipologie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviAnticipiTipologie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviAnticipi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPreventivo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CfPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Incasato = table.Column<double>(type: "float", nullable: true),
                    ImportoTotale = table.Column<double>(type: "float", nullable: true),
                    Anticipo = table.Column<double>(type: "float", nullable: true),
                    NoteContabili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteOperative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Causale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pagato = table.Column<bool>(type: "bit", nullable: false),
                    Fatturato = table.Column<bool>(type: "bit", nullable: false),
                    RegistratoContabilita = table.Column<bool>(type: "bit", nullable: false),
                    PreventiviAnticipoTipologiaId = table.Column<long>(type: "bigint", nullable: false),
                    PreventiviAnticipoPagamentoId = table.Column<long>(type: "bigint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviAnticipi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviAnticipi_GaPreventiviAnticipiTipologie_PreventiviAnticipoTipologiaId",
                        column: x => x.PreventiviAnticipoTipologiaId,
                        principalTable: "GaPreventiviAnticipiTipologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviAnticipiAllegati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreventiviAnticipoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviAnticipiAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviAnticipiAllegati_GaPreventiviAnticipi_PreventiviAnticipoId",
                        column: x => x.PreventiviAnticipoId,
                        principalTable: "GaPreventiviAnticipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviAnticipi_PreventiviAnticipoTipologiaId",
                table: "GaPreventiviAnticipi",
                column: "PreventiviAnticipoTipologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviAnticipiAllegati_PreventiviAnticipoId",
                table: "GaPreventiviAnticipiAllegati",
                column: "PreventiviAnticipoId");

            migrationBuilder.InsertData(
                           table: "GaPreventiviAnticipiTipologie",
                           columns: new[] { "Id", "Descrizione", "Disabled" },
                           values: new object[,]
                           {
                                            { 1,"PREVENTIVO" ,false},
                                            { 2,"COMPOSTIERA" ,false},
                                            { 3,"LUCCHETTI" ,false},
                                            { 4,"NON TROVATO" ,false},
                                            { 5,"ALTRO - SPECIFICARE NELLE NOTE" ,false},
                           });

            migrationBuilder.InsertData(
                           table: "GaPreventiviAnticipiPagamenti",
                           columns: new[] { "Id", "Descrizione", "Disabled" },
                           values: new object[,]
                           {
                                            { 1,"BONIFICO" ,false},
                                            { 2,"POS" ,false},
                                            { 3,"CONTANTI" ,false},
                           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPreventiviAnticipiAllegati");

            migrationBuilder.DropTable(
                name: "GaPreventiviAnticipiPagamenti");

            migrationBuilder.DropTable(
                name: "GaPreventiviAnticipi");

            migrationBuilder.DropTable(
                name: "GaPreventiviAnticipiTipologie");
        }
    }
}
