using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviGarbages_GarbageId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviObjects_ObjectId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PreventiviObjectConditions_GaPreventiviObjects_ObjectId",
                table: "PreventiviObjectConditions");

            migrationBuilder.DropIndex(
                name: "IX_GaPreventiviObjectServices_GarbageId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreventiviObjectConditions",
                table: "PreventiviObjectConditions");

            migrationBuilder.DropColumn(
                name: "GarbageId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.RenameTable(
                name: "PreventiviObjectConditions",
                newName: "GaPreventiviObjectConditions");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "GaPreventiviObjectServices",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_GaPreventiviObjectServices_ObjectId",
                table: "GaPreventiviObjectServices",
                newName: "IX_GaPreventiviObjectServices_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_PreventiviObjectConditions_ObjectId",
                table: "GaPreventiviObjectConditions",
                newName: "IX_GaPreventiviObjectConditions_ObjectId");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "GaPreventiviObjectServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GaPreventiviObjectConditions",
                table: "GaPreventiviObjectConditions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GaPreventiviDestinations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dangerous = table.Column<bool>(type: "bit", nullable: false),
                    Analysis = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviDestinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviProducers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CfPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviProducers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectSections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProducerId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationId = table.Column<long>(type: "bigint", nullable: false),
                    Garbages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjectSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectSections_GaPreventiviDestinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "GaPreventiviDestinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectSections_GaPreventiviObjects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "GaPreventiviObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjectSections_GaPreventiviProducers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "GaPreventiviProducers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectSections_DestinationId",
                table: "GaPreventiviObjectSections",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectSections_ObjectId",
                table: "GaPreventiviObjectSections",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectSections_ProducerId",
                table: "GaPreventiviObjectSections",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectConditions_GaPreventiviObjects_ObjectId",
                table: "GaPreventiviObjectConditions",
                column: "ObjectId",
                principalTable: "GaPreventiviObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviObjectSections_SectionId",
                table: "GaPreventiviObjectServices",
                column: "SectionId",
                principalTable: "GaPreventiviObjectSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectConditions_GaPreventiviObjects_ObjectId",
                table: "GaPreventiviObjectConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviObjectSections_SectionId",
                table: "GaPreventiviObjectServices");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjectSections");

            migrationBuilder.DropTable(
                name: "GaPreventiviDestinations");

            migrationBuilder.DropTable(
                name: "GaPreventiviProducers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GaPreventiviObjectConditions",
                table: "GaPreventiviObjectConditions");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "GaPreventiviObjectServices");

            migrationBuilder.RenameTable(
                name: "GaPreventiviObjectConditions",
                newName: "PreventiviObjectConditions");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "GaPreventiviObjectServices",
                newName: "ObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_GaPreventiviObjectServices_SectionId",
                table: "GaPreventiviObjectServices",
                newName: "IX_GaPreventiviObjectServices_ObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_GaPreventiviObjectConditions_ObjectId",
                table: "PreventiviObjectConditions",
                newName: "IX_PreventiviObjectConditions_ObjectId");

            migrationBuilder.AddColumn<long>(
                name: "GarbageId",
                table: "GaPreventiviObjectServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreventiviObjectConditions",
                table: "PreventiviObjectConditions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjectServices_GarbageId",
                table: "GaPreventiviObjectServices",
                column: "GarbageId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviGarbages_GarbageId",
                table: "GaPreventiviObjectServices",
                column: "GarbageId",
                principalTable: "GaPreventiviGarbages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GaPreventiviObjectServices_GaPreventiviObjects_ObjectId",
                table: "GaPreventiviObjectServices",
                column: "ObjectId",
                principalTable: "GaPreventiviObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreventiviObjectConditions_GaPreventiviObjects_ObjectId",
                table: "PreventiviObjectConditions",
                column: "ObjectId",
                principalTable: "GaPreventiviObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
