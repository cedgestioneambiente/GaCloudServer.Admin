using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaProgetti_V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaProgettiJobsUndertakingsStates",
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
                    table.PrimaryKey("PK_GaProgettiJobsUndertakingsStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaProgettiJobsUndertakings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgettiJobId = table.Column<long>(type: "bigint", nullable: false),
                    Resources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgettiJobUndertakingStateId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaProgettiJobsUndertakings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaProgettiJobsUndertakings_GaProgettiJobsUndertakingsStates_ProgettiJobUndertakingStateId",
                        column: x => x.ProgettiJobUndertakingStateId,
                        principalTable: "GaProgettiJobsUndertakingsStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaProgettiJobsUndertakingsAllegati",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgettiJobUndertakingId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_GaProgettiJobsUndertakingsAllegati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaProgettiJobsUndertakingsAllegati_GaProgettiJobsUndertakings_ProgettiJobUndertakingId",
                        column: x => x.ProgettiJobUndertakingId,
                        principalTable: "GaProgettiJobsUndertakings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaProgettiJobsUndertakings_ProgettiJobUndertakingStateId",
                table: "GaProgettiJobsUndertakings",
                column: "ProgettiJobUndertakingStateId");

            migrationBuilder.CreateIndex(
                name: "IX_GaProgettiJobsUndertakingsAllegati_ProgettiJobUndertakingId",
                table: "GaProgettiJobsUndertakingsAllegati",
                column: "ProgettiJobUndertakingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaProgettiJobsUndertakingsAllegati");

            migrationBuilder.DropTable(
                name: "GaProgettiJobsUndertakings");

            migrationBuilder.DropTable(
                name: "GaProgettiJobsUndertakingsStates");
        }
    }
}
