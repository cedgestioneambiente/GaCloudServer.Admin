using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectServiceTypes_CommonGauges_GaugeId",
                table: "GaPreventiviObjectServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_GaPreventiviObjectServiceTypes_GaugeId",
                table: "GaPreventiviObjectServiceTypes");

            migrationBuilder.DropColumn(
                name: "GaugeId",
                table: "GaPreventiviObjectServiceTypes");

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypeDetailId",
                table: "GaPreventiviObjectServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectServiceTypeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaugeId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjectServiceTypeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectServiceTypeDetails_CommonGauges_GaugeId",
                        column: x => x.GaugeId,
                        principalTable: "CommonGauges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectServiceTypeDetails_GaPreventiviObjectServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "GaPreventiviObjectServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServices_ServiceTypeDetailId",
                table: "GaPreventiviObjectServices",
                column: "ServiceTypeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServiceTypeDetails_GaugeId",
                table: "GaPreventiviObjectServiceTypeDetails",
                column: "GaugeId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServiceTypeDetails_ServiceTypeId",
                table: "GaPreventiviObjectServiceTypeDetails",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviObjectServiceTypeDetails_ServiceTypeDetailId",
                table: "GaPreventiviObjectServices",
                column: "ServiceTypeDetailId",
                principalTable: "GaPreventiviObjectServiceTypeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviObjectServiceTypeDetails_ServiceTypeDetailId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjectServiceTypeDetails");

            migrationBuilder.DropIndex(
                name: "IX_GaPreventiviObjectServices_ServiceTypeDetailId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.DropColumn(
                name: "ServiceTypeDetailId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.AddColumn<long>(
                name: "GaugeId",
                table: "GaPreventiviObjectServiceTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServiceTypes_GaugeId",
                table: "GaPreventiviObjectServiceTypes",
                column: "GaugeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectServiceTypes_CommonGauges_GaugeId",
                table: "GaPreventiviObjectServiceTypes",
                column: "GaugeId",
                principalTable: "CommonGauges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
