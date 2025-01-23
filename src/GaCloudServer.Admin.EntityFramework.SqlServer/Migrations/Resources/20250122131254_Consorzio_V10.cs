using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Consorzio_V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConsorzioInternalId",
                table: "ConsorzioTrasportatori",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConsorzioInternalId",
                table: "ConsorzioProduttori",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConsorzioInternalId",
                table: "ConsorzioDestinatari",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsorzioInternalId",
                table: "ConsorzioTrasportatori");

            migrationBuilder.DropColumn(
                name: "ConsorzioInternalId",
                table: "ConsorzioProduttori");

            migrationBuilder.DropColumn(
                name: "ConsorzioInternalId",
                table: "ConsorzioDestinatari");
        }
    }
}
