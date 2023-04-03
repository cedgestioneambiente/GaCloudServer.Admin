using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class App_Views_V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.Tasks, ScriptConsts.CREATE_ViewTasks));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.CREATE_ViewGaCdr));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.QueryBuilder, ScriptConsts.CREATE_ViewQueryBuilder));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.Tasks, ScriptConsts.DROP_ViewTasks));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.DROP_ViewGaCdr));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.QueryBuilder, ScriptConsts.DROP_ViewQueryBuilder));
        }
    }
}
