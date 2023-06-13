using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categ",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategDesc",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodFis",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodZona",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Partita",
                table: "GaCrmEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoId",
                table: "GaCrmEvents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categ",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "CategDesc",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "CodFis",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "CodZona",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "Partita",
                table: "GaCrmEvents");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "GaCrmEvents");
        }
    }
}
