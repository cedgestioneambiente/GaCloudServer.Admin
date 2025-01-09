using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Deposit",
                table: "GaPreventiviObjectPayouts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "GaPreventiviObjectPayouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentTermId",
                table: "GaPreventiviObjectPayouts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "GaPreventiviPaymentTerms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviPaymentTerms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectPayouts_PaymentTermId",
                table: "GaPreventiviObjectPayouts",
                column: "PaymentTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectPayouts_GaPreventiviPaymentTerms_PaymentTermId",
                table: "GaPreventiviObjectPayouts",
                column: "PaymentTermId",
                principalTable: "GaPreventiviPaymentTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectPayouts_GaPreventiviPaymentTerms_PaymentTermId",
                table: "GaPreventiviObjectPayouts");

            migrationBuilder.DropTable(
                name: "GaPreventiviPaymentTerms");

            migrationBuilder.DropIndex(
                name: "IX_GaPreventiviObjectPayouts_PaymentTermId",
                table: "GaPreventiviObjectPayouts");

            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "GaPreventiviObjectPayouts");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "GaPreventiviObjectPayouts");

            migrationBuilder.DropColumn(
                name: "PaymentTermId",
                table: "GaPreventiviObjectPayouts");
        }
    }
}
