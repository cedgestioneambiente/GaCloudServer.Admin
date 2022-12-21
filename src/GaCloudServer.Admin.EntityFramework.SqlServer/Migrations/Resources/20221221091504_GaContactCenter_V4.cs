using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContactCenter_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaContactCenterMailsOnTickets_GaContactCenterTickets_ContactCenterMailId",
                table: "GaContactCenterMailsOnTickets");

            migrationBuilder.AddForeignKey(
                name: "FK_GaContactCenterMailsOnTickets_GaContactCenterMails_ContactCenterMailId",
                table: "GaContactCenterMailsOnTickets",
                column: "ContactCenterMailId",
                principalTable: "GaContactCenterMails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaContactCenterMailsOnTickets_GaContactCenterMails_ContactCenterMailId",
                table: "GaContactCenterMailsOnTickets");

            migrationBuilder.AddForeignKey(
                name: "FK_GaContactCenterMailsOnTickets_GaContactCenterTickets_ContactCenterMailId",
                table: "GaContactCenterMailsOnTickets",
                column: "ContactCenterMailId",
                principalTable: "GaContactCenterTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
