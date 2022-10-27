using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class ViewGa_EcSegnalazioni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaSegnalazioniMigration, ScriptConsts.CREATE_ViewGaSegnalazioni));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.EcSegnalazioniMigration, ScriptConsts.CREATE_ViewEcSegnalazioni));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaSegnalazioniMigration, ScriptConsts.DROP_ViewGaSegnalazioni));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.EcSegnalazioniMigration, ScriptConsts.DROP_ViewEcSegnalazioni));
        }
    }
}
