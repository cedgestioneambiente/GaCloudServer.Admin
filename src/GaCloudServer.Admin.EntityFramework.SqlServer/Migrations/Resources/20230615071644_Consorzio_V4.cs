using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Consorzio_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Conteggio",
                table: "ConsorzioCers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCrm, ScriptConsts.CREATE_ViewGaCrm_V5));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conteggio",
                table: "ConsorzioCers");

            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCrm, ScriptConsts.DROP_ViewGaCrm_V5));
        }
    }
}
