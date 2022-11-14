using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPersonale_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GlobalSettoreId",
                table: "GaPersonaleDipendenti",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GaPersonaleDipendenti_GlobalSettoreId",
                table: "GaPersonaleDipendenti",
                column: "GlobalSettoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPersonaleDipendenti_GlobalSettori_GlobalSettoreId",
                table: "GaPersonaleDipendenti",
                column: "GlobalSettoreId",
                principalTable: "GlobalSettori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPersonaleDipendenti_GlobalSettori_GlobalSettoreId",
                table: "GaPersonaleDipendenti");

            migrationBuilder.DropIndex(
                name: "IX_GaPersonaleDipendenti_GlobalSettoreId",
                table: "GaPersonaleDipendenti");

            migrationBuilder.DropColumn(
                name: "GlobalSettoreId",
                table: "GaPersonaleDipendenti");
        }
    }
}
