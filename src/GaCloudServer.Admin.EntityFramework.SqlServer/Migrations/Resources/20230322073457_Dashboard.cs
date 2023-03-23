using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Dashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardSections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DashboardSectionId = table.Column<long>(type: "bigint", nullable: false),
                    DashboardTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardItems_DashboardSections_DashboardSectionId",
                        column: x => x.DashboardSectionId,
                        principalTable: "DashboardSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DashboardItems_DashboardTypes_DashboardTypeId",
                        column: x => x.DashboardTypeId,
                        principalTable: "DashboardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardStores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DashboardItemId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardStores_DashboardItems_DashboardItemId",
                        column: x => x.DashboardItemId,
                        principalTable: "DashboardItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItems_DashboardSectionId",
                table: "DashboardItems",
                column: "DashboardSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItems_DashboardTypeId",
                table: "DashboardItems",
                column: "DashboardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardStores_DashboardItemId",
                table: "DashboardStores",
                column: "DashboardItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardStores");

            migrationBuilder.DropTable(
                name: "DashboardItems");

            migrationBuilder.DropTable(
                name: "DashboardSections");

            migrationBuilder.DropTable(
                name: "DashboardTypes");
        }
    }
}
