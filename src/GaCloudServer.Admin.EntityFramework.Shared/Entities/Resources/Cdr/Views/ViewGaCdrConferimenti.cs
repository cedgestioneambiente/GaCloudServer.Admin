using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views
{
    public class ViewGaCdrConferimenti : GenericEntity
    {
        public DateTime Data { get; set; }
        public string CdrUtenteId { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string Centro { get; set; }
        public string RagioneSociale { get; set; }
        public string CfPiva { get; set; }
        public string Comune { get; set; }
        public string Cer { get; set; }
        public string CerDettaglio { get; set; }
        public double Peso { get; set; }
        public int Quantita { get; set; }
        public string imm { get; set; }
        public string Targa { get; set; }
        public string Note { get; set; }
        public string UtenteRegistrazione { get; set; }
    }
}
