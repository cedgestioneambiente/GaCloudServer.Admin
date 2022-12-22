using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class Global : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalCentriCosti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalCentriCosti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalSedi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalSedi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalSettori",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalSettori", x => x.Id);
                });

            migrationBuilder.InsertData(
                            table: "GlobalSedi",
                            columns: new[] { "Id", "Descrizione", "Disabled" },
                            values: new object[,]
                            {
                                            { 1,"NOVI LIGURE" ,false},
                                            { 2,"TORTONA" ,false},
                                            { 4,"ASMT" ,false},
                            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalCentriCosti");

            migrationBuilder.DropTable(
                name: "GlobalSedi");

            migrationBuilder.DropTable(
                name: "GlobalSettori");
        }
    }
}
