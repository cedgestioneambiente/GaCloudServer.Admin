using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaDispositivi_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaDispositiviModuli_GaPersonaleDipendenti_PersonaleDipendenteId1",
                table: "GaDispositiviModuli");

            migrationBuilder.DropIndex(
                name: "IX_GaDispositiviModuli_PersonaleDipendenteId1",
                table: "GaDispositiviModuli");

            migrationBuilder.DropColumn(
                name: "PersonaleDipendenteId1",
                table: "GaDispositiviModuli");

            migrationBuilder.AlterColumn<long>(
                name: "PersonaleDipendenteId",
                table: "GaDispositiviModuli",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviModuli_PersonaleDipendenteId",
                table: "GaDispositiviModuli",
                column: "PersonaleDipendenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaDispositiviModuli_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaDispositiviModuli",
                column: "PersonaleDipendenteId",
                principalTable: "GaPersonaleDipendenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaDispositiviModuli_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaDispositiviModuli");

            migrationBuilder.DropIndex(
                name: "IX_GaDispositiviModuli_PersonaleDipendenteId",
                table: "GaDispositiviModuli");

            migrationBuilder.AlterColumn<string>(
                name: "PersonaleDipendenteId",
                table: "GaDispositiviModuli",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PersonaleDipendenteId1",
                table: "GaDispositiviModuli",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviModuli_PersonaleDipendenteId1",
                table: "GaDispositiviModuli",
                column: "PersonaleDipendenteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GaDispositiviModuli_GaPersonaleDipendenti_PersonaleDipendenteId1",
                table: "GaDispositiviModuli",
                column: "PersonaleDipendenteId1",
                principalTable: "GaPersonaleDipendenti",
                principalColumn: "Id");
        }
    }
}
