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
        public const string ALTER_ViewGaCdrComuniOnCentri = "ALTER_ViewGaCdrComuniOnCentri.sql";
        public const string CREATE_ViewGaCdr = "CREATE_ViewGaCdr.sql";
        public const string DROP_ViewGaCdr = "DROP_ViewGaCdr.sql";

        //Contratti
        public const string GaContrattiMigration = @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\Contratti\";
        public const string CREATE_PrivateViewGaContrattiPermessiList = "CREATE_PrivateViewGaContrattiPermessiList.sql";
        public const string DROP_PrivateViewGaContrattiPermessiList = "DROP_PrivateViewGaContrattiPermessiList.sql";
        public const string CREATE_ViewGaContrattiUtentiOnPermessi = "CREATE_ViewGaContrattiUtentiOnPermessi.sql";
        public const string DROP_ViewGaContrattiUtentiOnPermessi = "DROP_ViewGaContrattiUtentiOnPermessi.sql";
        public const string CREATE_ViewGaContrattiUtenti = "CREATE_ViewGaContrattiUtenti.sql";
        public const string DROP_ViewGaContrattiUtenti = "DROP_ViewGaContrattiUtenti.sql";

        //Mezzi
        public const string GaMezziMigration= @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\Mezzi\";
        public const string CREATE_ViewGaMezzi = "CREATE_ViewGaMezzi.sql";
        public const string DROP_ViewGaMezzi = "DROP_ViewGaMezzi.sql";

        //BackOffice
        public const string GaBackOffice = @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\BackOffice\";
        public const string CREATE_SpGaBackOffice = "CREATE_SpGaBackOffice.sql";
        public const string DROP_SpGaBackOffice = "DROP_SpGaBackOffice.sql";
        public const string CREATE_ViewGaBackOffice = "CREATE_ViewGaBackOffice.sql";
        public const string DROP_ViewGaBackOffice = "DROP_ViewGaBackOffice.sql";

        //PrenotazioneAuto
        public const string GaPrenotazioneAuto = @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\PrenotazioneAuto\";
        public const string CREATE_ViewGaPrenotazioneAuto = "CREATE_ViewGaPrenotazioneAuto.sql";
        public const string DROP_ViewGaPrenotazioneAuto = "DROP_ViewGaPrenotazioneAuto.sql";

        //LinkedServer
        public const string LinkedServer= @"..\GaCloudServer.Admin.EntityFramework.SqlServer\Scripts\LinkedServer\";
        public const string CREATE_LinkedServer2082756 = "CREATE_LinkedServer2082756.sql";
        public const string DROP_LinkedServer2082756 = "DROP_LinkedServer2082756";
    }
}
