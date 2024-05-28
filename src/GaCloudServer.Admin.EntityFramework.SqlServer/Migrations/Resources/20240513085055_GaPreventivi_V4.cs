using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectInspectionModes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjectInspectionModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectInspections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    DateInspection = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExecution = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssigneeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteInspection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjectInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectInspections_GaPreventiviObjectInspectionModes_ModeId",
                        column: x => x.ModeId,
                        principalTable: "GaPreventiviObjectInspectionModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectInspections_GaPreventiviObjects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "GaPreventiviObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectInspections_GaPreventiviObjectStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "GaPreventiviObjectStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectInspectionAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectInspectionId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjectInspectionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectInspectionAttachments_GaPreventiviObjectInspections_ObjectInspectionId",
                        column: x => x.ObjectInspectionId,
                        principalTable: "GaPreventiviObjectInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectInspectionImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectInspectionId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjectInspectionImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectInspectionImages_GaPreventiviObjectInspections_ObjectInspectionId",
                        column: x => x.ObjectInspectionId,
                        principalTable: "GaPreventiviObjectInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectInspectionAttachments_ObjectInspectionId",
                table: "GaPreventiviObjectInspectionAttachments",
                column: "ObjectInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectInspectionImages_ObjectInspectionId",
                table: "GaPreventiviObjectInspectionImages",
                column: "ObjectInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectInspections_ModeId",
                table: "GaPreventiviObjectInspections",
                column: "ModeId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectInspections_ObjectId",
                table: "GaPreventiviObjectInspections",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectInspections_StatusId",
                table: "GaPreventiviObjectInspections",
                column: "StatusId");

            //put initial data
            migrationBuilder.InsertData(
                table: "GaPreventiviObjectInspectionModes",
                columns: new[] { "Id", "Descrizione", "CreatedAt", "CreatedBy", "Disabled" },
                values: new object[,]
                {
                    { 1,"Non specificata",DateTime.Now,"system_init", false},
                    { 2,"Sopralluogo necessario",DateTime.Now,"system_init", false},
                    { 3,"Sopralluogo non necessario",DateTime.Now,"system_init", false},
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPreventiviObjectInspectionAttachments");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjectInspectionImages");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjectInspections");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjectInspectionModes");
        }
    }
}
