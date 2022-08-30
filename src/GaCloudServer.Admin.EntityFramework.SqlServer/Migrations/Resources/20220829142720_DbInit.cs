using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class DbInit : Migration
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
                name: "GaCdrCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Centro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCentri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pericoloso = table.Column<bool>(type: "bit", nullable: false),
                    Peso = table.Column<bool>(type: "bit", nullable: false),
                    Qta = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrComuni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrComuni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiPermessi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiPermessi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiServizi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiServizi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiTipologie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiTipologie", x => x.Id);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCersDettagli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCerId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesoDefault = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCersDettagli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrCersDettagli_GaCdrCers_CdrCerId",
                        column: x => x.CdrCerId,
                        principalTable: "GaCdrCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCersOnCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCentroId = table.Column<long>(type: "bigint", nullable: false),
                    CdrCerId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCersOnCentri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrCersOnCentri_GaCdrCentri_CdrCentroId",
                        column: x => x.CdrCentroId,
                        principalTable: "GaCdrCentri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaCdrCersOnCentri_GaCdrCers_CdrCerId",
                        column: x => x.CdrCerId,
                        principalTable: "GaCdrCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrComuniOnCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCentroId = table.Column<long>(type: "bigint", nullable: false),
                    CdrComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrComuniOnCentri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrComuniOnCentri_GaCdrCentri_CdrCentroId",
                        column: x => x.CdrCentroId,
                        principalTable: "GaCdrCentri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaCdrComuniOnCentri_GaCdrComuni_CdrComuneId",
                        column: x => x.CdrComuneId,
                        principalTable: "GaCdrComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiUtentiOnPermessi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContrattoPermessoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiUtentiOnPermessi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContrattiUtentiOnPermessi_GaContrattiPermessi_ContrattoPermessoId",
                        column: x => x.ContrattoPermessoId,
                        principalTable: "GaContrattiPermessi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaAutorizzazioniAllegati_AutorizzazioniDocumentoId",
                table: "GaAutorizzazioniAllegati",
                column: "AutorizzazioniDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaAutorizzazioniDocumenti_AutorizzazioniTipoId",
                table: "GaAutorizzazioniDocumenti",
                column: "AutorizzazioniTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersDettagli_CdrCerId",
                table: "GaCdrCersDettagli",
                column: "CdrCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersOnCentri_CdrCentroId",
                table: "GaCdrCersOnCentri",
                column: "CdrCentroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersOnCentri_CdrCerId",
                table: "GaCdrCersOnCentri",
                column: "CdrCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrComuniOnCentri_CdrCentroId",
                table: "GaCdrComuniOnCentri",
                column: "CdrCentroId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrComuniOnCentri_CdrComuneId",
                table: "GaCdrComuniOnCentri",
                column: "CdrComuneId");

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiUtentiOnPermessi_ContrattoPermessoId",
                table: "GaContrattiUtentiOnPermessi",
                column: "ContrattoPermessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaAutorizzazioniAllegati");

            migrationBuilder.DropTable(
                name: "GaCdrCersDettagli");

            migrationBuilder.DropTable(
                name: "GaCdrCersOnCentri");

            migrationBuilder.DropTable(
                name: "GaCdrComuniOnCentri");

            migrationBuilder.DropTable(
                name: "GaContrattiServizi");

            migrationBuilder.DropTable(
                name: "GaContrattiTipologie");

            migrationBuilder.DropTable(
                name: "GaContrattiUtentiOnPermessi");

            migrationBuilder.DropTable(
                name: "GaAutorizzazioniDocumenti");

            migrationBuilder.DropTable(
                name: "GaCdrCers");

            migrationBuilder.DropTable(
                name: "GaCdrCentri");

            migrationBuilder.DropTable(
                name: "GaCdrComuni");

            migrationBuilder.DropTable(
                name: "GaContrattiPermessi");

            migrationBuilder.DropTable(
                name: "GaAutorizzazioniTipi");
        }
    }
}
