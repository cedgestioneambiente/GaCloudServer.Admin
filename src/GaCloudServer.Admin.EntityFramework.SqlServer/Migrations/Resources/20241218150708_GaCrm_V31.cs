using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CrmTicketTipoAzioneId",
                table: "GaCrmTicketAzioni",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmTicketAzioni_CrmTicketTipoAzioneId",
                table: "GaCrmTicketAzioni",
                column: "CrmTicketTipoAzioneId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaCrmTicketAzioni_GaReclamiTipiAzioni_CrmTicketTipoAzioneId",
                table: "GaCrmTicketAzioni",
                column: "CrmTicketTipoAzioneId",
                principalTable: "GaReclamiTipiAzioni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaCrmTicketAzioni_GaReclamiTipiAzioni_CrmTicketTipoAzioneId",
                table: "GaCrmTicketAzioni");

            migrationBuilder.DropIndex(
                name: "IX_GaCrmTicketAzioni_CrmTicketTipoAzioneId",
                table: "GaCrmTicketAzioni");

            migrationBuilder.DropColumn(
                name: "CrmTicketTipoAzioneId",
                table: "GaCrmTicketAzioni");
        }
    }
}
