using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectStatuses",
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
                    table.PrimaryKey("PK_GaPreventiviObjectStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjectTypes",
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
                    table.PrimaryKey("PK_GaPreventiviObjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviObjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInserimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodComune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CfPiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cellulare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Via = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCiv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    AssigneeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCompletamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjects_GaPreventiviObjectStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "GaPreventiviObjectStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaPreventiviObjects_GaPreventiviObjectTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "GaPreventiviObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaPreventiviActions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaPreventiviActions_GaPreventiviObjects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "GaPreventiviObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviActions_ObjectId",
                table: "GaPreventiviActions",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjects_StatusId",
                table: "GaPreventiviObjects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GaPreventiviObjects_TypeId",
                table: "GaPreventiviObjects",
                column: "TypeId");

            //put initial data
            migrationBuilder.InsertData(
                table: "GaPreventiviObjectStatuses",
                columns: new[] { "Id", "Descrizione", "CreatedAt", "CreatedBy", "Disabled" },
                values: new object[,]
                {
                    { 1,"In Gestione",DateTime.Now,"system_init", false},
                    { 2,"Completato",DateTime.Now,"system_init", false},
                    { 3,"Annullato",DateTime.Now,"system_init", false},
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPreventiviActions");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjects");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjectStatuses");

            migrationBuilder.DropTable(
                name: "GaPreventiviObjectTypes");
        }
    }
}
