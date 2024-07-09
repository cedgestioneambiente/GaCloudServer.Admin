using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviGarbages_GrabageId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.RenameColumn(
                name: "GrabageId",
                table: "GaPreventiviObjectServices",
                newName: "GarbageId");

            migrationBuilder.RenameIndex(
                name: "IX_GaPreventiviObjectServices_GrabageId",
                table: "GaPreventiviObjectServices",
                newName: "IX_GaPreventiviObjectServices_GarbageId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviGarbages_GarbageId",
                table: "GaPreventiviObjectServices",
                column: "GarbageId",
                principalTable: "GaPreventiviGarbages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviGarbages_GarbageId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.RenameColumn(
                name: "GarbageId",
                table: "GaPreventiviObjectServices",
                newName: "GrabageId");

            migrationBuilder.RenameIndex(
                name: "IX_GaPreventiviObjectServices_GarbageId",
                table: "GaPreventiviObjectServices",
                newName: "IX_GaPreventiviObjectServices_GrabageId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviGarbages_GrabageId",
                table: "GaPreventiviObjectServices",
                column: "GrabageId",
                principalTable: "GaPreventiviGarbages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
