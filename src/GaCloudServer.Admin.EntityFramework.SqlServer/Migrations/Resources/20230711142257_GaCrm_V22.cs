using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RitardoCausaAzienda",
                table: "GaCrmEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RitardoCausaUtente",
                table: "GaCrmEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GiorniGestione",
                table: "GaContactCenterTipiRichieste",
                type: "int",
                nullable: true);

            // InitData EventStates
            migrationBuilder.InsertData(
                table: "ContactCenterStatoRichiesta",
                columns: new[] { "Id", "Descrizione", "Disabled" },
                values: new object[,]
                {
            { 4, "GESTITO IN RITARDO CAUSA UTENTE", false},
            { 5, "GESTITO IN RITARDO CAUSA AZIENDA" , false},
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RitardoCausaAzienda",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "RitardoCausaUtente",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "GiorniGestione",
                table: "GaContactCenterTipiRichieste");
        }
    }
}
