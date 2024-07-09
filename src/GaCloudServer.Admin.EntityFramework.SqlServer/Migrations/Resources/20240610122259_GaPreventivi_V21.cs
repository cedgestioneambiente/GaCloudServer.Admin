using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "GaPreventiviObjectPayouts");

            migrationBuilder.AddColumn<long>(
                name: "BankAccountId",
                table: "GaPreventiviObjectPayouts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "CommonBankAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonBankAccounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectPayouts_BankAccountId",
                table: "GaPreventiviObjectPayouts",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectPayouts_CommonBankAccounts_BankAccountId",
                table: "GaPreventiviObjectPayouts",
                column: "BankAccountId",
                principalTable: "CommonBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectPayouts_CommonBankAccounts_BankAccountId",
                table: "GaPreventiviObjectPayouts");

            migrationBuilder.DropTable(
                name: "CommonBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_GaPreventiviObjectPayouts_BankAccountId",
                table: "GaPreventiviObjectPayouts");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "GaPreventiviObjectPayouts");

            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "GaPreventiviObjectPayouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
