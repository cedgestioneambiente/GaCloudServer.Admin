using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Notification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "NotificationApps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationApps", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "NotificationRolesOnApps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationAppId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRolesOnApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationRolesOnApps_NotificationApps_NotificationAppId",
                        column: x => x.NotificationAppId,
                        principalTable: "NotificationApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationUsersOnApps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationAppId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationUsersOnApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationUsersOnApps_NotificationApps_NotificationAppId",
                        column: x => x.NotificationAppId,
                        principalTable: "NotificationApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRolesOnApps_NotificationAppId",
                table: "NotificationRolesOnApps",
                column: "NotificationAppId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUsersOnApps_NotificationAppId",
                table: "NotificationUsersOnApps",
                column: "NotificationAppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "NotificationRolesOnApps");

            migrationBuilder.DropTable(
                name: "NotificationUsersOnApps");

            migrationBuilder.DropTable(
                name: "NotificationApps");
        }
    }
}
