using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPreventiviGarbages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dangerous = table.Column<bool>(type: "bit", nullable: false),
                    Analysis = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviGarbages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectServiceTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GaugeId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjectServiceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectServiceTypes_CommonGauges_GaugeId",
                        column: x => x.GaugeId,
                        principalTable: "CommonGauges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IvaCodeId = table.Column<long>(type: "bigint", nullable: false),
                    GrabageId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CostUnit = table.Column<double>(type: "float", nullable: false),
                    CostTotal = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesExtra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Analysis = table.Column<bool>(type: "bit", nullable: false),
                    AnalysisDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjectServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectServices_CommonIvaCodes_IvaCodeId",
                        column: x => x.IvaCodeId,
                        principalTable: "CommonIvaCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectServices_GaPreventiviGarbages_GrabageId",
                        column: x => x.GrabageId,
                        principalTable: "GaPreventiviGarbages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectServices_GaPreventiviObjectServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "GaPreventiviObjectServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServices_GrabageId",
                table: "GaPreventiviObjectServices",
                column: "GrabageId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServices_IvaCodeId",
                table: "GaPreventiviObjectServices",
                column: "IvaCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServices_ServiceTypeId",
                table: "GaPreventiviObjectServices",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServiceTypes_GaugeId",
                table: "GaPreventiviObjectServiceTypes",
                column: "GaugeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPreventiviObjectServices");

            migrationBuilder.DropTable(
                name: "GaPreventiviGarbages");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjectServiceTypes");
        }
    }
}
