namespace GaCloudServer.Admin.EntityFramework.SqlServer.Constants
{
    public static class ScriptConsts
    {
        //Global
        public const string GlobalMigration = @".\Scripts\Global\";
        public const string CREATE_ViewGlobal = "CREATE_ViewGlobal.sql";
        public const string CREATE_ObjectGlobal = "CREATE_ObjectGlobal.sql";
        public const string DROP_ViewGlobal = "DROP_ViewGlobal.sql";
        public const string DROP_ObjectGlobal = "DROP_ObjectGlobal.sql";

        //Autorizzazioni
        public const string GaAutorizzazioniMigration = @".\Scripts\Autorizzazioni\";
        public const string CREATE_ViewGaAutorizzazioniDocumenti = "CREATE_ViewGaAutorizzazioniDocumenti.sql";
        public const string DROP_ViewGaAutorizzazioniDocumenti = "DROP_ViewGaAutorizzazioniDocumenti.sql";

        //Cdr
        public const string GaCdrMigration = @".\Scripts\Cdr\";
        public const string CREATE_ViewGaCdr = "CREATE_ViewGaCdr.sql";
        public const string DROP_ViewGaCdr = "DROP_ViewGaCdr.sql";

        //Contratti
        public const string GaContrattiMigration = @".\Scripts\Contratti\";
        public const string CREATE_ViewGaContratti = "CREATE_ViewGaContratti.sql";
        public const string DROP_ViewGaContratti = "DROP_ViewGaContratti";
        public const string CREATE_SpGaContratti = "CREATE_SpGaContratti.sql";
        public const string DROP_SpGaContratti = "DROP_SpGaContratti.sql";

        //Mezzi
        public const string GaMezziMigration= @".\Scripts\Mezzi\";
        public const string CREATE_ViewGaMezzi = "CREATE_ViewGaMezzi.sql";
        public const string DROP_ViewGaMezzi = "DROP_ViewGaMezzi.sql";

        //BackOffice
        public const string GaBackOfficeMigration = @".\Scripts\BackOffice\";
        public const string CREATE_SpGaBackOffice = "CREATE_SpGaBackOffice.sql";
        public const string CREATE_SpGaBackOffice_V2 = "CREATE_SpGaBackOffice_V2.sql";
        public const string DROP_SpGaBackOffice = "DROP_SpGaBackOffice.sql";
        public const string DROP_SpGaBackOffice_V2 = "DROP_SpGaBackOffice_V2.sql";
        public const string CREATE_ViewGaBackOffice = "CREATE_ViewGaBackOffice.sql";
        public const string CREATE_ViewGaBackOffice_V2 = "CREATE_ViewGaBackOffice_V2.sql";
        public const string CREATE_ViewGaBackOffice_V3 = "CREATE_ViewGaBackOffice_V3.sql";
        public const string DROP_ViewGaBackOffice = "DROP_ViewGaBackOffice.sql";
        public const string DROP_ViewGaBackOffice_V2 = "DROP_ViewGaBackOffice_V2.sql";
        public const string DROP_ViewGaBackOffice_V3 = "DROP_ViewGaBackOffice_V3.sql";

        //PrenotazioneAuto
        public const string GaPrenotazioneAutoMigration = @".\Scripts\PrenotazioneAuto\";
        public const string CREATE_ViewGaPrenotazioneAuto = "CREATE_ViewGaPrenotazioneAuto.sql";
        public const string DROP_ViewGaPrenotazioneAuto = "DROP_ViewGaPrenotazioneAuto.sql";

        //LinkedServer
        public const string LinkedServerMigration = @".\Scripts\LinkedServer\";
        public const string CREATE_LinkedServer2082756 = "CREATE_LinkedServer2082756.sql";
        public const string DROP_LinkedServer2082756 = "DROP_LinkedServer2082756";

        //Notification
        public const string NotificationMigration = @".\Scripts\Notification\";
        public const string CREATE_ViewNotification = "CREATE_ViewNotification.sql";
        public const string DROP_ViewNotification = "DROP_ViewNotification.sql";

        //Csr
        public const string GaCsrMigration = @".\Scripts\Csr\";
        public const string CREATE_ViewGaCsr = "CREATE_ViewGaCsr.sql";
        public const string DROP_ViewGaCsr = "DROP_ViewGaCsr.sql";

        //Reclami
        public const string GaReclamiMigration = @".\Scripts\Reclami\";
        public const string CREATE_ViewGaReclami = "CREATE_ViewGaReclami.sql";
        public const string DROP_ViewGaReclami = "DROP_ViewGaReclami.sql";

        //Segnalazioni
        public const string GaSegnalazioniMigration = @".\Scripts\Segnalazioni\";
        public const string EcSegnalazioniMigration = @".\Scripts\Segnalazioni\";
        public const string CREATE_ViewGaSegnalazioni = "CREATE_ViewGaSegnalazioni.sql";
        public const string DROP_ViewGaSegnalazioni = "DROP_ViewGaSegnalazioni.sql";
        public const string CREATE_ViewEcSegnalazioni = "CREATE_ViewEcSegnalazioni.sql";
        public const string DROP_ViewEcSegnalazioni = "DROP_ViewEcSegnalazioni.sql";

        //Personale
        public const string GaPersonaleMigration = @".\Scripts\Personale\";
        public const string CREATE_ViewGaPersonale = "CREATE_ViewGaPersonale.sql";
        public const string DROP_ViewGaPersonale = "DROP_ViewGaPersonale.sql";

        //ContactCenter
        public const string GaContactCenterMigration = @".\Scripts\ContactCenter\";
        public const string CREATE_ViewGaContactCenter = "CREATE_ViewGaContactCenter.sql";
        public const string DROP_ViewGaContactCenter = "DROP_ViewGaContactCenter.sql";
        public const string CREATE_ViewFoContactCenter = "CREATE_ViewFoContactCenter.sql";
        public const string DROP_ViewFoContactCenter = "DROP_ViewFoContactCenter.sql";

        //Presenze
        public const string GaPresenzeMigration = @".\Scripts\Presenze\";
        public const string CREATE_ViewGaPresenze = "CREATE_ViewGaPresenze.sql";
        public const string DROP_ViewGaPresenze = "DROP_ViewGaPresenze.sql";
        public const string CREATE_ViewGaPresenze_V2 = "CREATE_ViewGaPresenze_V2.sql";
        public const string DROP_ViewGaPresenze_V2 = "DROP_ViewGaPresenze_V2.sql";

        //Recapiti
        public const string GaRecapitiMigration = @".\Scripts\Recapiti\";
        public const string CREATE_ViewGaRecapiti = "CREATE_ViewGaRecapiti.sql";
        public const string DROP_ViewGaRecapiti = "DROP_ViewGaRecapiti.sql";

        //Jobs
        public const string JobsMigration = @".\Scripts\Jobs\";
        public const string CREATE_TableJobs = "CREATE_TableJobs.sql";
        public const string DROP_TableJobs = "DROP_TableJobs.sql";

        //Ost
        public const string OstMigration = @".\Scripts\Ost\";
        public const string CREATE_ViewOst = "CREATE_ViewOst.sql";
        public const string DROP_ViewOst = "DROP_ViewOst.sql";
    }
}
