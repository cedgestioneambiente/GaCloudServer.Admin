using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaContratti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaContrattiPermessi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiPermessi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiServizi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiServizi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiTipologie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiTipologie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaContrattiUtentiOnPermessi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContrattiPermessoId = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaContrattiUtentiOnPermessi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaContrattiUtentiOnPermessi_GaContrattiPermessi_ContrattiPermessoId",
                        column: x => x.ContrattiPermessoId,
                        principalTable: "GaContrattiPermessi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaContrattiUtentiOnPermessi_ContrattiPermessoId",
                table: "GaContrattiUtentiOnPermessi",
                column: "ContrattiPermessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaContrattiServizi");

            migrationBuilder.DropTable(
                name: "GaContrattiTipologie");

            migrationBuilder.DropTable(
                name: "GaContrattiUtentiOnPermessi");

            migrationBuilder.DropTable(
                name: "GaContrattiPermessi");
        }
    }
}
