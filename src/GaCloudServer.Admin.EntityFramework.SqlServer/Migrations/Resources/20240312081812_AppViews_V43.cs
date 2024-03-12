using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class AppViews_V43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaPreventivi, ScriptConsts.CREATE_ViewGaPreventivi));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaBackOfficeMigration, ScriptConsts.CREATE_ViewGaBackOffice_V8));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaPreventivi, ScriptConsts.DROP_ViewGaPreventivi));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaBackOfficeMigration, ScriptConsts.DROP_ViewGaBackOffice_V8));
        }
    }
}
