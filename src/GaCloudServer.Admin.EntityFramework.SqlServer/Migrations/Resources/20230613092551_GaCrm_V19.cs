using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrintTemplate",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.AddColumn<long>(
                name: "ContactCenterPrintTemplateId",
                table: "GaContactCenterTipiRichieste",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactCenterPrintTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCenterPrintTemplates", x => x.Id);
                });

            // InitData EventStates
            migrationBuilder.InsertData(
                table: "ContactCenterPrintTemplates",
                columns: new[] { "Id", "Descrizione","Template", "Disabled" },
                values: new object[,]
                {
                    { 1, "Default","CrmEventDefault", false}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCenterPrintTemplates");

            migrationBuilder.DropColumn(
                name: "ContactCenterPrintTemplateId",
                table: "GaContactCenterTipiRichieste");

            migrationBuilder.AddColumn<string>(
                name: "PrintTemplate",
                table: "GaContactCenterTipiRichieste",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
