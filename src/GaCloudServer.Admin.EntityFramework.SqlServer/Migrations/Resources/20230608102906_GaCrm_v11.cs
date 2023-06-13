using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaCrmTickets_GaContactCenterTipiRichieste_ContactCenterTipoRichiestaId",
                table: "GaCrmTickets");

            migrationBuilder.DropColumn(
                name: "ContactCenterTioRichiestaId",
                table: "GaCrmTickets");

            migrationBuilder.AlterColumn<long>(
                name: "ContactCenterTipoRichiestaId",
                table: "GaCrmTickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GaCrmTickets_GaContactCenterTipiRichieste_ContactCenterTipoRichiestaId",
                table: "GaCrmTickets",
                column: "ContactCenterTipoRichiestaId",
                principalTable: "GaContactCenterTipiRichieste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaCrmTickets_GaContactCenterTipiRichieste_ContactCenterTipoRichiestaId",
                table: "GaCrmTickets");

            migrationBuilder.AlterColumn<long>(
                name: "ContactCenterTipoRichiestaId",
                table: "GaCrmTickets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ContactCenterTioRichiestaId",
                table: "GaCrmTickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_GaCrmTickets_GaContactCenterTipiRichieste_ContactCenterTipoRichiestaId",
                table: "GaCrmTickets",
                column: "ContactCenterTipoRichiestaId",
                principalTable: "GaContactCenterTipiRichieste",
                principalColumn: "Id");
        }
    }
}
