using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneLocali
{
    public class PrenotazioneLocaliRegistrazione : GenericEntity
    {
        public string Colore { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public bool InteraGiornata { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string? Motivazione { get; set; }
        public long PrenotazioneLocaliUfficioId { get; set; }

        public PrenotazioneLocaliUfficio PrenotazioneLocaliUfficio { get; set; }
    }
}