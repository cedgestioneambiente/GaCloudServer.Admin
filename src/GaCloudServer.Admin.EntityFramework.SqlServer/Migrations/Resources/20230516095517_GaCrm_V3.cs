using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sended",
                table: "GaCrmEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "GaCrmEventDevices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrmEventId = table.Column<long>(type: "bigint", nullable: false),
                    CrmTicketId = table.Column<int>(type: "int", nullable: false),
                    Identi1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identi2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipCon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesCon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtCon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtRit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Selected = table.Column<bool>(type: "bit", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCrmEventDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCrmEventDevices_GaCrmEvents_CrmEventId",
                        column: x => x.CrmEventId,
                        principalTable: "GaCrmEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaCrmEventDevices_CrmEventId",
                table: "GaCrmEventDevices",
                column: "CrmEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaCrmEventDevices");

            migrationBuilder.DropColumn(
                name: "Sended",
                table: "GaCrmEvents");
        }
    }
}
