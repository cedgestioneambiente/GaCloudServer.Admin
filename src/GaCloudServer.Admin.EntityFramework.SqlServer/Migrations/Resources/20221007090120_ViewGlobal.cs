using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class ViewGlobal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaGlobalMigration, ScriptConsts.CREATE_ObjectGaGlobal));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaGlobalMigration, ScriptConsts.CREATE_ViewGaGlobal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaGlobalMigration, ScriptConsts.DROP_ObjectGaGlobal));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaGlobalMigration, ScriptConsts.DROP_ViewGaGlobal));
        }
    }
}
