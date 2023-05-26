using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaCrm_V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaCrmEventComuni",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodAzi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<long>(type: "bigint", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaCrmEventComuni", x => x.Id);
                });

            // InitData EventStates
            migrationBuilder.InsertData(
                table: "GaCrmEventComuni",
                columns: new[] { "Id","CodAzi", "Descrizione","Duration", "Disabled" },
                values: new object[,]
                {
                    { 1, "C01","ALLUVIONI PIOVERA", 90, false},
                    { 2, "C02","ALZANO SCRIVIA", 90, false},
                    { 3, "C03","BASALUZZO", 90, false},
                    { 4, "C04","CAPRIATA D'ORBA", 90, false},
                    { 5, "C05","CARBONARA SCRIVIA", 90, false},
                    { 6, "C06","CAREZZANO", 90, false},
                    { 7, "C07","CARROSIO", 90, false},
                    { 8, "C08","CASSANO SPINOLA", 90, false},
                    { 9, "C09","CASTALLAR GUIDOBONO", 90, false},
                    { 10, "C10","CASTELLAZZO BORMIDA", 90, false},
                    { 11, "C11","CASTELNUOVO SCRIVIA", 90, false},
                    { 12, "C12","FRACONALTO", 90, false},
                    { 13, "C13","FRANCAVILLA BISIO", 90, false},
                    { 14, "C14","FRESONARA", 90, false},
                    { 15, "C15","GAVI", 90, false},
                    { 16, "C16","GUAZZORA", 90, false},
                    { 17, "C17","ISOLA SANT'ANTONIO", 90, false},
                    { 18, "C18","MOLINO DEI TORTI", 90, false},
                    { 19, "C19","NOVI LIGURE", 90, false},
                    { 20, "C20","PARODI LIGURE", 90, false},
                    { 21, "C21","PASTURANA", 90, false},
                    { 22, "C22","PONTECURONE", 90, false},
                    { 23, "C23","POZZOLO FORMIGARO", 90, false},
                    { 24, "C24","PREDOSA", 90, false},
                    { 25, "C25","SALE", 90, false},
                    { 26, "C26","SARDIGLIANO", 90, false},
                    { 27, "C27","SERRAVALLE SCRIVIA", 90, false},
                    { 28, "C28","SPINETO SCRIVIA", 90, false},
                    { 29, "C29","TASSAROLO", 90, false},
                    { 30, "C30","TORTONA", 90, false},
                    { 31, "C31","VIGUZZOLO", 90, false},
                    { 32, "C32","VILLAROMAGNANO", 90, false},
                    { 33, "C33","VOLTAGGIO", 90, false},

                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaCrmEventComuni");
        }
    }
}
