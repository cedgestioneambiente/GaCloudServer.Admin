using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class GaProvetti_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caption",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Miles",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Parent",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "GaProgettiJobs");

            migrationBuilder.RenameColumn(
                name: "Res",
                table: "GaProgettiJobs",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "GaProgettiJobs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GaProgettiJobs",
                newName: "Resources");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "GaProgettiJobs",
                newName: "Links");

            migrationBuilder.RenameColumn(
                name: "Depend",
                table: "GaProgettiJobs",
                newName: "Group_id");

            migrationBuilder.RenameColumn(
                name: "Comp",
                table: "GaProgettiJobs",
                newName: "Color");

            migrationBuilder.AddColumn<bool>(
                name: "Draggable",
                table: "GaProgettiJobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Expandable",
                table: "GaProgettiJobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Linkable",
                table: "GaProgettiJobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "GaProgettiJobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "GaProgettiJobs",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Draggable",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Expandable",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Linkable",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "GaProgettiJobs");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "GaProgettiJobs");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "GaProgettiJobs",
                newName: "Res");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "GaProgettiJobs",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "Resources",
                table: "GaProgettiJobs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Links",
                table: "GaProgettiJobs",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "Group_id",
                table: "GaProgettiJobs",
                newName: "Depend");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "GaProgettiJobs",
                newName: "Comp");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "GaProgettiJobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "GaProgettiJobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "GaProgettiJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Miles",
                table: "GaProgettiJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Open",
                table: "GaProgettiJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Parent",
                table: "GaProgettiJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "GaProgettiJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
