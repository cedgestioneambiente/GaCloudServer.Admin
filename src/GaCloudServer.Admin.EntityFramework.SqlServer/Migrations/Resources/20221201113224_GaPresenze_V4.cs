using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPresenze_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GgFerie",
                table: "GaPresenzeProfili");

            migrationBuilder.DropColumn(
                name: "GgLavorativi",
                table: "GaPresenzeProfili");

            migrationBuilder.DropColumn(
                name: "GgPermessiCcnl",
                table: "GaPresenzeProfili");

            migrationBuilder.AlterColumn<double>(
                name: "HhPermessiCcnl",
                table: "GaPresenzeProfili",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "HhFerie",
                table: "GaPresenzeProfili",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HhPermessiCcnl",
                table: "GaPresenzeProfili",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "HhFerie",
                table: "GaPresenzeProfili",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "GgFerie",
                table: "GaPresenzeProfili",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GgLavorativi",
                table: "GaPresenzeProfili",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GgPermessiCcnl",
                table: "GaPresenzeProfili",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
