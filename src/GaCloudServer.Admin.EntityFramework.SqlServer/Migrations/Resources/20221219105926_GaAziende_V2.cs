using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaAziende_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaContactCenterTickets_GlobalSedi_GlobalSedeId",
                table: "GaContactCenterTickets");

            migrationBuilder.RenameColumn(
                name: "GlobalSedeId",
                table: "GaContactCenterTickets",
                newName: "AziendeListaId");

            migrationBuilder.RenameIndex(
                name: "IX_GaContactCenterTickets_GlobalSedeId",
                table: "GaContactCenterTickets",
                newName: "IX_GaContactCenterTickets_AziendeListaId");

            migrationBuilder.AddColumn<bool>(
                name: "ContactCenterTicket",
                table: "GaAziendeListe",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DescrizioneBreve",
                table: "GaAziendeListe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GaContactCenterTickets_GaAziendeListe_AziendeListaId",
                table: "GaContactCenterTickets",
                column: "AziendeListaId",
                principalTable: "GaAziendeListe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaContactCenterTickets_GaAziendeListe_AziendeListaId",
                table: "GaContactCenterTickets");

            migrationBuilder.DropColumn(
                name: "ContactCenterTicket",
                table: "GaAziendeListe");

            migrationBuilder.DropColumn(
                name: "DescrizioneBreve",
                table: "GaAziendeListe");

            migrationBuilder.RenameColumn(
                name: "AziendeListaId",
                table: "GaContactCenterTickets",
                newName: "GlobalSedeId");

            migrationBuilder.RenameIndex(
                name: "IX_GaContactCenterTickets_AziendeListaId",
                table: "GaContactCenterTickets",
                newName: "IX_GaContactCenterTickets_GlobalSedeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaContactCenterTickets_GlobalSedi_GlobalSedeId",
                table: "GaContactCenterTickets",
                column: "GlobalSedeId",
                principalTable: "GlobalSedi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
