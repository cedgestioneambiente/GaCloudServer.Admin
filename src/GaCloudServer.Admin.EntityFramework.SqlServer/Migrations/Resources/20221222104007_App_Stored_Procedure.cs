using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class App_Stored_Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaBackOfficeMigration, ScriptConsts.CREATE_SpGaBackOffice));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.CREATE_SpGaContratti));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaBackOfficeMigration, ScriptConsts.DROP_SpGaBackOffice));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.DROP_SpGaContratti));
        }
    }
}
