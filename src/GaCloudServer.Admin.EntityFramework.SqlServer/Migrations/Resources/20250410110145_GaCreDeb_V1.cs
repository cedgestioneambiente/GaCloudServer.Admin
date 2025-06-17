using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCreDeb_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaCreDebCanali",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCanale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescCanale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContoNeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exclude = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCreDebCanali", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCreDebConti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContoTari = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodFis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContoNeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCreDebConti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCreDebObjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtPag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumPag = table.Column<int>(type: "int", nullable: false),
                    TotPag = table.Column<double>(type: "float", nullable: false),
                    Contab = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCreDebObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCreDebObjectDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTask = table.Column<long>(type: "bigint", nullable: false),
                    CodCli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumFat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtFat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAvPag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContoC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Incrim = table.Column<double>(type: "float", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Segno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskId = table.Column<long>(type: "bigint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCreDebObjectDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCreDebObjectDetails_GaCreDebObjects_TaskId",
                        column: x => x.TaskId,
                        principalTable: "GaCreDebObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaCreDebObjectDetails_TaskId",
                table: "GaCreDebObjectDetails",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaCreDebCanali");

            migrationBuilder.DropTable(
                name: "GaCreDebConti");

            migrationBuilder.DropTable(
                name: "GaCreDebObjectDetails");

            migrationBuilder.DropTable(
                name: "GaCreDebObjects");
        }
    }
}
