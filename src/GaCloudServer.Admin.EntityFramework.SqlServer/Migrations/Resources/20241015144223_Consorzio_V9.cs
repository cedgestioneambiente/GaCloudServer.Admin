using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Consorzio_V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsorzioComuniDemografie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsorzioComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Anno2022 = table.Column<int>(type: "int", nullable: false),
                    Anno2023 = table.Column<int>(type: "int", nullable: false),
                    Anno2024 = table.Column<int>(type: "int", nullable: false),
                    Anno2025 = table.Column<int>(type: "int", nullable: false),
                    Anno2026 = table.Column<int>(type: "int", nullable: false),
                    Anno2027 = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsorzioComuniDemografie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsorzioComuniDemografie_ConsorzioComuni_ConsorzioComuneId",
                        column: x => x.ConsorzioComuneId,
                        principalTable: "ConsorzioComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsorzioComuniDemografie_ConsorzioComuneId",
                table: "ConsorzioComuniDemografie",
                column: "ConsorzioComuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsorzioComuniDemografie");
        }
    }
}
