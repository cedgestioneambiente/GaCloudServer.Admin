using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCdr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaCdrCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Centro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCentri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pericoloso = table.Column<bool>(type: "bit", nullable: true),
                    Peso = table.Column<bool>(type: "bit", nullable: true),
                    Qta = table.Column<bool>(type: "bit", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrComuni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrComuni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCersDettagli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCerId = table.Column<long>(type: "bigint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesoDefault = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCersDettagli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrCersDettagli_GaCdrCers_CdrCerId",
                        column: x => x.CdrCerId,
                        principalTable: "GaCdrCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrCersOnCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCentroId = table.Column<long>(type: "bigint", nullable: false),
                    CdrCerId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrCersOnCentri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrCersOnCentri_GaCdrCentri_CdrCentroId",
                        column: x => x.CdrCentroId,
                        principalTable: "GaCdrCentri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCdrCersOnCentri_GaCdrCers_CdrCerId",
                        column: x => x.CdrCerId,
                        principalTable: "GaCdrCers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaCdrComuniOnCentri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdrCentroId = table.Column<long>(type: "bigint", nullable: false),
                    CdrComuneId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCdrComuniOnCentri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaCdrComuniOnCentri_GaCdrCentri_CdrCentroId",
                        column: x => x.CdrCentroId,
                        principalTable: "GaCdrCentri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaCdrComuniOnCentri_GaCdrComuni_CdrComuneId",
                        column: x => x.CdrComuneId,
                        principalTable: "GaCdrComuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersDettagli_CdrCerId",
                table: "GaCdrCersDettagli",
                column: "CdrCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersOnCentri_CdrCentroId",
                table: "GaCdrCersOnCentri",
                column: "CdrCentroId");


            migrationBuilder.CreateIndex(
                name: "IX_GaCdrCersOnCentri_CdrCerId",
                table: "GaCdrCersOnCentri",
                column: "CdrCerId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrComuniOnCentri_CdrCentroId",
                table: "GaCdrComuniOnCentri",
                column: "CdrCentroId");

            migrationBuilder.CreateIndex(
                name: "IX_GaCdrComuniOnCentri_CdrComuneId",
                table: "GaCdrComuniOnCentri",
                column: "CdrComuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaCdrCersDettagli");

            migrationBuilder.DropTable(
                name: "GaCdrCersOnCentri");

            migrationBuilder.DropTable(
                name: "GaCdrComuniOnCentri");

            migrationBuilder.DropTable(
                name: "GaCdrCers");

            migrationBuilder.DropTable(
                name: "GaCdrCentri");

            migrationBuilder.DropTable(
                name: "GaCdrComuni");
        }
    }
}
