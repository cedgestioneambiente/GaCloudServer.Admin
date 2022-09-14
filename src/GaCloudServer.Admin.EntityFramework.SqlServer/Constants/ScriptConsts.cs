namespace GaCloudServer.Admin.EntityFramework.SqlServer.Constants
{
    public static class ScriptConsts
    {
        public const string GaAutorizzazioniMigration = @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\Autorizzazioni\";
        public const string CREATE_ViewGaAutorizzazioniDocumenti = "CREATE_ViewGaAutorizzazioniDocumenti.sql";
        public const string DROP_ViewGaAutorizzazioniDocumenti = "DROP_ViewGaAutorizzazioniDocumenti.sql";

        public const string GaCdrMigration= @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\Cdr\";

        public const string GaMezziMigration= @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\Mezzi\";
        public const string CREATE_ViewGaMezzi = "CREATE_ViewGaMezzi.sql";
        public const string DROP_ViewGaMezzi = "DROP_ViewGaMezzi.sql";
    }
}
