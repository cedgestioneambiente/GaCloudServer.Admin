using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ObjectId",
                table: "GaPreventiviObjectServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServices_ObjectId",
                table: "GaPreventiviObjectServices",
                column: "ObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviObjects_ObjectId",
                table: "GaPreventiviObjectServices",
                column: "ObjectId",
                principalTable: "GaPreventiviObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviObjects_ObjectId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.DropIndex(
                name: "IX_GaPreventiviObjectServices_ObjectId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "GaPreventiviObjectServices");
        }
    }
}
