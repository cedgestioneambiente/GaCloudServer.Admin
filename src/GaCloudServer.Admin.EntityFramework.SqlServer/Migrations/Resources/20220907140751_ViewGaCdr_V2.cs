using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class ViewGaCdr_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.CREATE_ViewGaCdrCersOnCentri));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.CREATE_ViewGaCdrComuniOnCentri));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.CREATE_PrivateViewGaCdrCersOnCentri));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.CREATE_ViewGaCdrComuni));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.DROP_ViewGaCdrCersOnCentri));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.DROP_ViewGaCdrComuniOnCentri));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.DROP_PrivateViewGaCdrCersOnCentri));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.DROP_ViewGaCdrComuni));
        }
    }
}
