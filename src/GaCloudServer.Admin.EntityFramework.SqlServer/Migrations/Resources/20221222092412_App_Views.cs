using GaCloudServer.Admin.EntityFramework.SqlServer.Constants;
using GaCloudServer.Admin.EntityFramework.SqlServer.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Migrations.Resources
{
    public partial class App_Views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GlobalMigration, ScriptConsts.CREATE_ViewGlobal));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GlobalMigration, ScriptConsts.CREATE_ObjectGlobal));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.JobsMigration, ScriptConsts.CREATE_TableJobs));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.NotificationMigration, ScriptConsts.CREATE_ViewNotification));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaAutorizzazioniMigration, ScriptConsts.CREATE_ViewGaAutorizzazioniDocumenti));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaBackOfficeMigration, ScriptConsts.CREATE_ViewGaBackOffice));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.CREATE_ViewGaCdr));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.CREATE_ViewGaContratti));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaMezziMigration, ScriptConsts.CREATE_ViewGaMezzi));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaPrenotazioneAutoMigration, ScriptConsts.CREATE_ViewGaPrenotazioneAuto));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCsrMigration, ScriptConsts.CREATE_ViewGaCsr));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaReclamiMigration, ScriptConsts.CREATE_ViewGaReclami));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaSegnalazioniMigration, ScriptConsts.CREATE_ViewGaSegnalazioni));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaSegnalazioniMigration, ScriptConsts.CREATE_ViewEcSegnalazioni));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaPersonaleMigration, ScriptConsts.CREATE_ViewGaPersonale));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaPresenzeMigration, ScriptConsts.CREATE_ViewGaPresenze));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContactCenterMigration, ScriptConsts.CREATE_ViewGaContactCenter));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContactCenterMigration, ScriptConsts.CREATE_ViewFoContactCenter));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaRecapitiMigration, ScriptConsts.CREATE_ViewGaRecapiti));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GlobalMigration, ScriptConsts.DROP_ViewGlobal));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GlobalMigration, ScriptConsts.DROP_ObjectGlobal));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.JobsMigration, ScriptConsts.DROP_TableJobs));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.NotificationMigration, ScriptConsts.DROP_ViewNotification));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaAutorizzazioniMigration, ScriptConsts.DROP_ViewGaAutorizzazioniDocumenti));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaBackOfficeMigration, ScriptConsts.DROP_ViewGaBackOffice));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCdrMigration, ScriptConsts.DROP_ViewGaCdr));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContrattiMigration, ScriptConsts.DROP_ViewGaContratti));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaMezziMigration, ScriptConsts.DROP_ViewGaMezzi));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaPrenotazioneAutoMigration, ScriptConsts.DROP_ViewGaPrenotazioneAuto));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaCsrMigration, ScriptConsts.DROP_ViewGaCsr));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaReclamiMigration, ScriptConsts.DROP_ViewGaReclami));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaSegnalazioniMigration, ScriptConsts.DROP_ViewGaSegnalazioni));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaSegnalazioniMigration, ScriptConsts.DROP_ViewEcSegnalazioni));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaPersonaleMigration, ScriptConsts.DROP_ViewGaPersonale));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaPresenzeMigration, ScriptConsts.DROP_ViewGaPresenze));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContactCenterMigration, ScriptConsts.DROP_ViewGaContactCenter));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaContactCenterMigration, ScriptConsts.DROP_ViewFoContactCenter));
            migrationBuilder.Sql(MigrationHelper.CommandToString(ScriptConsts.GaRecapitiMigration, ScriptConsts.DROP_ViewGaRecapiti));
        }
    }
}
