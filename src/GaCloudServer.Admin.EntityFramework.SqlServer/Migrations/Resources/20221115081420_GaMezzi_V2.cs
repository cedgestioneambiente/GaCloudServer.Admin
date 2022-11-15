using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaMezzi_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaMezziVeicoli_GaMezziCantieri_MezziCantiereId",
                table: "GaMezziVeicoli");

            migrationBuilder.DropTable(
                name: "GaMezziCantieri");

            migrationBuilder.RenameColumn(
                name: "MezziCantiereId",
                table: "GaMezziVeicoli",
                newName: "GlobalSedeId");

            migrationBuilder.RenameIndex(
                name: "IX_GaMezziVeicoli_MezziCantiereId",
                table: "GaMezziVeicoli",
                newName: "IX_GaMezziVeicoli_GlobalSedeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaMezziVeicoli_GlobalSedi_GlobalSedeId",
                table: "GaMezziVeicoli",
                column: "GlobalSedeId",
                principalTable: "GlobalSedi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaMezziVeicoli_GlobalSedi_GlobalSedeId",
                table: "GaMezziVeicoli");

            migrationBuilder.RenameColumn(
                name: "GlobalSedeId",
                table: "GaMezziVeicoli",
                newName: "MezziCantiereId");

            migrationBuilder.RenameIndex(
                name: "IX_GaMezziVeicoli_GlobalSedeId",
                table: "GaMezziVeicoli",
                newName: "IX_GaMezziVeicoli_MezziCantiereId");

            migrationBuilder.CreateTable(
                name: "GaMezziCantieri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaMezziCantieri", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GaMezziVeicoli_GaMezziCantieri_MezziCantiereId",
                table: "GaMezziVeicoli",
                column: "MezziCantiereId",
                principalTable: "GaMezziCantieri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
