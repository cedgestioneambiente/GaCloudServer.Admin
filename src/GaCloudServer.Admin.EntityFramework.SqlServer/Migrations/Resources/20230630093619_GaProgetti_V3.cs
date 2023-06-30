using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaProgetti_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaProgettiWorkSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgettiWorkId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddJobNotification = table.Column<bool>(type: "bit", nullable: false),
                    UpdateJobNotification = table.Column<bool>(type: "bit", nullable: false),
                    DeleteJobNotification = table.Column<bool>(type: "bit", nullable: false),
                    WorkStatusMail = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaProgettiWorkSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaProgettiWorkSettings_GaProgettiWorks_ProgettiWorkId",
                        column: x => x.ProgettiWorkId,
                        principalTable: "GaProgettiWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaProgettiWorkSettings_ProgettiWorkId",
                table: "GaProgettiWorkSettings",
                column: "ProgettiWorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaProgettiWorkSettings");
        }
    }
}
