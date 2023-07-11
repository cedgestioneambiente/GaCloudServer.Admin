using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaDispositivi_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaDispositiviOnDipendenti_GaPersonaleDipendenti_PersonaleDipendenteId1",
                table: "GaDispositiviOnDipendenti");

            migrationBuilder.DropIndex(
                name: "IX_GaDispositiviOnDipendenti_PersonaleDipendenteId1",
                table: "GaDispositiviOnDipendenti");

            migrationBuilder.DropColumn(
                name: "PersonaleDipendenteId1",
                table: "GaDispositiviOnDipendenti");

            migrationBuilder.AlterColumn<long>(
                name: "PersonaleDipendenteId",
                table: "GaDispositiviOnDipendenti",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviOnDipendenti_PersonaleDipendenteId",
                table: "GaDispositiviOnDipendenti",
                column: "PersonaleDipendenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaDispositiviOnDipendenti_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaDispositiviOnDipendenti",
                column: "PersonaleDipendenteId",
                principalTable: "GaPersonaleDipendenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaDispositiviOnDipendenti_GaPersonaleDipendenti_PersonaleDipendenteId",
                table: "GaDispositiviOnDipendenti");

            migrationBuilder.DropIndex(
                name: "IX_GaDispositiviOnDipendenti_PersonaleDipendenteId",
                table: "GaDispositiviOnDipendenti");

            migrationBuilder.AlterColumn<string>(
                name: "PersonaleDipendenteId",
                table: "GaDispositiviOnDipendenti",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PersonaleDipendenteId1",
                table: "GaDispositiviOnDipendenti",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaDispositiviOnDipendenti_PersonaleDipendenteId1",
                table: "GaDispositiviOnDipendenti",
                column: "PersonaleDipendenteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GaDispositiviOnDipendenti_GaPersonaleDipendenti_PersonaleDipendenteId1",
                table: "GaDispositiviOnDipendenti",
                column: "PersonaleDipendenteId1",
                principalTable: "GaPersonaleDipendenti",
                principalColumn: "Id");
        }
    }
}
