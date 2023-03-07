using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaBackOffice_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaBackOfficeMargini",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MargineRsu = table.Column<double>(type: "float", nullable: false),
                    MargineCarta = table.Column<double>(type: "float", nullable: false),
                    MarginePlastica = table.Column<double>(type: "float", nullable: false),
                    MargineVetro = table.Column<double>(type: "float", nullable: false),
                    MargineUmido = table.Column<double>(type: "float", nullable: false),
                    PesoSpecificoRsu = table.Column<double>(type: "float", nullable: false),
                    PesoSpecificoCarta = table.Column<double>(type: "float", nullable: false),
                    PesoSpecificoPlastica = table.Column<double>(type: "float", nullable: false),
                    PesoSpecificoVetro = table.Column<double>(type: "float", nullable: false),
                    PesoSpecificoUmido = table.Column<double>(type: "float", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaBackOfficeMargini", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaBackOfficeZone",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CadenzaRsu = table.Column<int>(type: "int", nullable: false),
                    CadenzaCarta = table.Column<int>(type: "int", nullable: false),
                    CadenzaPlastica = table.Column<int>(type: "int", nullable: false),
                    CadenzaUmido = table.Column<int>(type: "int", nullable: false),
                    CadenzaVetro = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaBackOfficeZone", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaBackOfficeMargini");

            migrationBuilder.DropTable(
                name: "GaBackOfficeZone");
        }
    }
}
