using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class ViewGaRecapiti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaRecapitiMigration, ScriptConsts.CREATE_ViewGaRecapiti));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaRecapitiMigration, ScriptConsts.DROP_ViewGaRecapiti));
        }
    }
}
