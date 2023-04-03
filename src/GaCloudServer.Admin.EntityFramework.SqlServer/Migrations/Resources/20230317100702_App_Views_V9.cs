using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class App_Views_V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "QueryBuilderParamOnScripts",
                type: "nvarchar(max)",
                nullable: true);
            //migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.QueryBuilder, ScriptConsts.CREATE_ViewQueryBuilder));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "QueryBuilderParamOnScripts");
            //migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.QueryBuilder, ScriptConsts.DROP_ViewQueryBuilder));
        }
    }
}
