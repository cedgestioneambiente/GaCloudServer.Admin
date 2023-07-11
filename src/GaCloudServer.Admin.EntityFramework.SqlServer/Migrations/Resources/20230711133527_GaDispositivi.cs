using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaDispositivi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaDispositiviCategorie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviCategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviClassi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviClassi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviMarche",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviMarche", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviModelli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviModelli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviModuli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaleDipendenteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaleDipendenteId1 = table.Column<long>(type: "bigint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviModuli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaDispositiviModuli_GaPersonaleDipendenti_PersonaleDipendenteId1",
                        column: x => x.PersonaleDipendenteId1,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviTipologie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviTipologie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispositiviTipologiaId = table.Column<long>(type: "bigint", nullable: false),
                    DispositiviMarcaId = table.Column<long>(type: "bigint", nullable: false),
                    DispositiviModelloId = table.Column<long>(type: "bigint", nullable: false),
                    DispositiviClasseId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaDispositiviItems_GaDispositiviClassi_DispositiviClasseId",
                        column: x => x.DispositiviClasseId,
                        principalTable: "GaDispositiviClassi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaDispositiviItems_GaDispositiviMarche_DispositiviMarcaId",
                        column: x => x.DispositiviMarcaId,
                        principalTable: "GaDispositiviMarche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaDispositiviItems_GaDispositiviModelli_DispositiviModelloId",
                        column: x => x.DispositiviModelloId,
                        principalTable: "GaDispositiviModelli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaDispositiviItems_GaDispositiviTipologie_DispositiviTipologiaId",
                        column: x => x.DispositiviTipologiaId,
                        principalTable: "GaDispositiviTipologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviStocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispositiviItemId = table.Column<long>(type: "bigint", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltriDati = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRegistrazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDismissione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DispositiviCategoriaId = table.Column<long>(type: "bigint", nullable: false),
                    Disponibile = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaDispositiviStocks_GaDispositiviCategorie_DispositiviCategoriaId",
                        column: x => x.DispositiviCategoriaId,
                        principalTable: "GaDispositiviCategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaDispositiviStocks_GaDispositiviItems_DispositiviItemId",
                        column: x => x.DispositiviItemId,
                        principalTable: "GaDispositiviItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviOnDipendenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispositiviStockId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaleDipendenteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataConsegna = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRitiro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonaleDipendenteId1 = table.Column<long>(type: "bigint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviOnDipendenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaDispositiviOnDipendenti_GaDispositiviStocks_DispositiviStockId",
                        column: x => x.DispositiviStockId,
                        principalTable: "GaDispositiviStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaDispositiviOnDipendenti_GaPersonaleDipendenti_PersonaleDipendenteId1",
                        column: x => x.PersonaleDipendenteId1,
                        principalTable: "GaPersonaleDipendenti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GaDispositiviOnModuli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispositiviModuloId = table.Column<long>(type: "bigint", nullable: false),
                    DispositiviOnDipendenteId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaDispositiviOnModuli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaDispositiviOnModuli_GaDispositiviModuli_DispositiviModuloId",
                        column: x => x.DispositiviModuloId,
                        principalTable: "GaDispositiviModuli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaDispositiviOnModuli_GaDispositiviOnDipendenti_DispositiviOnDipendenteId",
                        column: x => x.DispositiviOnDipendenteId,
                        principalTable: "GaDispositiviOnDipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviItems_DispositiviClasseId",
                table: "GaDispositiviItems",
                column: "DispositiviClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviItems_DispositiviMarcaId",
                table: "GaDispositiviItems",
                column: "DispositiviMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviItems_DispositiviModelloId",
                table: "GaDispositiviItems",
                column: "DispositiviModelloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviItems_DispositiviTipologiaId",
                table: "GaDispositiviItems",
                column: "DispositiviTipologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviModuli_PersonaleDipendenteId1",
                table: "GaDispositiviModuli",
                column: "PersonaleDipendenteId1");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviOnDipendenti_DispositiviStockId",
                table: "GaDispositiviOnDipendenti",
                column: "DispositiviStockId");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviOnDipendenti_PersonaleDipendenteId1",
                table: "GaDispositiviOnDipendenti",
                column: "PersonaleDipendenteId1");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviOnModuli_DispositiviModuloId",
                table: "GaDispositiviOnModuli",
                column: "DispositiviModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviOnModuli_DispositiviOnDipendenteId",
                table: "GaDispositiviOnModuli",
                column: "DispositiviOnDipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviStocks_DispositiviCategoriaId",
                table: "GaDispositiviStocks",
                column: "DispositiviCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviStocks_DispositiviItemId",
                table: "GaDispositiviStocks",
                column: "DispositiviItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaDispositiviOnModuli");

            migrationBuilder.DropTable(
                name: "GaDispositiviModuli");

            migrationBuilder.DropTable(
                name: "GaDispositiviOnDipendenti");

            migrationBuilder.DropTable(
                name: "GaDispositiviStocks");

            migrationBuilder.DropTable(
                name: "GaDispositiviCategorie");

            migrationBuilder.DropTable(
                name: "GaDispositiviItems");

            migrationBuilder.DropTable(
                name: "GaDispositiviClassi");

            migrationBuilder.DropTable(
                name: "GaDispositiviMarche");

            migrationBuilder.DropTable(
                name: "GaDispositiviModelli");

            migrationBuilder.DropTable(
                name: "GaDispositiviTipologie");
        }
    }
}
