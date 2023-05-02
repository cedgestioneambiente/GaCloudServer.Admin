using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class App_Views_V18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.Consorzio, ScriptConsts.CREATE_ViewConsorzio));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCsrMigration, ScriptConsts.CREATE_ViewGaCsr_V2));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.Consorzio, ScriptConsts.DROP_ViewConsorzio));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCsrMigration, ScriptConsts.DROP_ViewGaCsr_V2));
        }
    }
}
