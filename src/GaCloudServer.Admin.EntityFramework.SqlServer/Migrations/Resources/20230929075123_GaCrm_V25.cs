using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaCrmEventDevices_GaCrmEvents_CrmEventId",
                table: "GaCrmEventDevices");

            migrationBuilder.DropIndex(
                name: "IX_GaCrmEventDevices_CrmEventId",
                table: "GaCrmEventDevices");

            migrationBuilder.AlterColumn<long>(
                name: "CrmTicketId",
                table: "GaCrmEventDevices",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CrmEventId",
                table: "GaCrmEventDevices",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CrmTicketId",
                table: "GaCrmEventDevices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CrmEventId",
                table: "GaCrmEventDevices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmEventDevices_CrmEventId",
                table: "GaCrmEventDevices",
                column: "CrmEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaCrmEventDevices_GaCrmEvents_CrmEventId",
                table: "GaCrmEventDevices",
                column: "CrmEventId",
                principalTable: "GaCrmEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
