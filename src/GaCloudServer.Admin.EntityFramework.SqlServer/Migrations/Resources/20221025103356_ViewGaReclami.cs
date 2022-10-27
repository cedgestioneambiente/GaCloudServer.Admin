using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class ViewGaReclami : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaReclamiMigration, ScriptConsts.CREATE_ViewGaReclami));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaReclamiMigration, ScriptConsts.DROP_ViewGaReclami));
        }
    }
}
