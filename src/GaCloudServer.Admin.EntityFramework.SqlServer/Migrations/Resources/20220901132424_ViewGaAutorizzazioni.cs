using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class ViewGaAutorizzazioni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaAutorizzazioniMigration,ScriptConsts.CREATE_ViewGaAutorizzazioniDocumenti));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaAutorizzazioniMigration, ScriptConsts.DROP_ViewGaAutorizzazioniDocumenti));
        }
    }
}
