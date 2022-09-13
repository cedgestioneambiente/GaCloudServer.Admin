namespace GaCloudServer.Admin.EntityFramework.SqlServer.Constants
{
    public static class ScriptConsts
    {
        //Autorizzazioni
        public const string GaAutorizzazioniMigration = @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\Autorizzazioni\";
        public const string CREATE_ViewGaAutorizzazioniDocumenti = "CREATE_ViewGaAutorizzazioniDocumenti.sql";
        public const string DROP_ViewGaAutorizzazioniDocumenti = "DROP_ViewGaAutorizzazioniDocumenti.sql";

        //Cdr
        public const string GaCdrMigration= @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\Cdr\";
        public const string CREATE_ViewGaCdrCersOnCentri = "CREATE_ViewGaCdrCersOnCentri.sql";
        public const string DROP_ViewGaCdrCersOnCentri = "DROP_ViewGaCdrCersOnCentri.sql";
        public const string CREATE_ViewGaCdrComuniOnCentri = "CREATE_ViewGaCdrComuniOnCentri.sql";
        public const string DROP_ViewGaCdrComuniOnCentri = "DROP_ViewGaCdrComuniOnCentri.sql";
        public const string CREATE_PrivateViewGaCdrCersOnCentri = "CREATE_PrivateViewGaCdrCersOnCentri.sql";
        public const string DROP_PrivateViewGaCdrCersOnCentri = "DROP_PrivateViewGaCdrCersOnCentri.sql";
        public const string CREATE_PrivateViewGaCdrCersList = "CREATE_PrivateViewGaCdrCersList.sql";
        public const string DROP_PrivateViewGaCdrCersList = "DROP_PrivateViewGaCdrCersList.sql";
        public const string CREATE_PrivateViewGaCdrComuniList = "CREATE_PrivateViewGaCdrComuniList.sql";
        public const string DROP_PrivateViewGaCdrComuniList = "DROP_PrivateViewGaCdrComuniList.sql";
        public const string CREATE_ViewGaCdrComuni = "CREATE_ViewGaCdrComuni.sql";
        public const string DROP_ViewGaCdrComuni = "DROP_ViewGaCdrComuni.sql";

        //Contratti
        public const string GaContrattiMigration = @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\Contratti\";
        public const string CREATE_PrivateViewGaContrattiPermessiList = "CREATE_PrivateViewGaContrattiPermessiList.sql";
        public const string DROP_PrivateViewGaContrattiPermessiList = "DROP_PrivateViewGaContrattiPermessiList.sql";
        public const string CREATE_ViewGaContrattiUtentiOnPermessi = "CREATE_ViewGaContrattiUtentiOnPermessi.sql";
        public const string DROP_ViewGaContrattiUtentiOnPermessi = "DROP_ViewGaContrattiUtentiOnPermessi";
        public const string CREATE_ViewGaContrattiUtenti = "CREATE_ViewGaContrattiUtenti.sql";
        public const string DROP_ViewGaContrattiUtenti = "DROP_ViewGaContrattiUtenti";
    }
}
