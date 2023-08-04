using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Task_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TasksActions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemId = table.Column<long>(type: "bigint", nullable: false),
                    TasksItemId = table.Column<long>(type: "bigint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TasksActions_TasksItems_TasksItemId",
                        column: x => x.TasksItemId,
                        principalTable: "TasksItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TasksActions_TasksItemId",
                table: "TasksActions",
                column: "TasksItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TasksActions");
        }
    }
}
