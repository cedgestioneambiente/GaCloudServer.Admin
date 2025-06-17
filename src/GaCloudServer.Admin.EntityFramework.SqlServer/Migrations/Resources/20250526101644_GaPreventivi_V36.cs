using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaPreventivi_V36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaPreventiviIsmartDocumenti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codcli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prgfat = table.Column<int>(type: "int", nullable: false),
                    IdDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numfat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codsez = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtfat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pagato = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailInviata = table.Column<bool>(type: "bit", nullable: false),
                    Gestito = table.Column<bool>(type: "bit", nullable: false),
                    DataInserimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataGestione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaPreventiviIsmartDocumenti", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaPreventiviIsmartDocumenti");
        }
    }
}
