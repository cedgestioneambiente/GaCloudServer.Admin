using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class ViewGaContratti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.CREATE_ViewGaContrattiUtenti));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.CREATE_PrivateViewGaContrattiPermessiList));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.CREATE_ViewGaContrattiUtentiOnPermessi)); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.DROP_ViewGaContrattiUtenti));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.DROP_PrivateViewGaContrattiPermessiList));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.DROP_ViewGaContrattiUtentiOnPermessi));
        }
    }
}
