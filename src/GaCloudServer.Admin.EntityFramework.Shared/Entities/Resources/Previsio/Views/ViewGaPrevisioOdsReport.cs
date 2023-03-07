using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views
{
    public class ViewGaPrevisioOdsReport:GenericEntity
    {
        public string IDservizio { get; set; }
        public int? ContaServizi { get; set; }
        public DateTime? DataOraIniMezzo { get; set; }
        public DateTime? DataOraFineMezzo { get; set; }
        public int? MinutiMezzo { get; set; }
        public int? EffettivoMinMezzo { get; set; }
        public DateTime? DataOraIniAutista { get; set; }
        public DateTime? DataOraFineAutista { get; set; }
        public int? MinutiAutista { get; set; }
        public int? EffettivoMinAutista { get; set; }
        public double? KmPartenza { get; set; }
        public double? KmFine { get; set; }
        public string Committente { get; set; }
        public string Servizio { get; set; }
        public string Categoria { get; set; }
        public string NomeCliente { get; set; }
        public string DescrizioneProduttore { get; set; }
        public string IndirizzoImpiantoProduttore { get; set; }
        public string LocalitaImpiantoProduttore { get; set; }
        public string Autista { get; set; }
        public string Operatore { get; set; }
        public string Mezzo { get; set; }
        public string Rimorchio { get; set; }
        public string DescrizioneDestinatario { get; set; }
        public string IndirizzoImpiantoDestinatario { get; set; }
        public string LocalitaImpiantoDestinatario { get; set; }
        public string DescrizioneIntermediario { get; set; }
        public string IndirizzoImpiantoIntermediario { get; set; }
        public string LocalitaImpiantoIntermediario { get; set; }
        public string DescrizioneIntermediario1 { get; set; }
        public string IndirizzoImpiantoIntermediario1 { get; set; }
        public string LocalitaImpiantoIntermediario1 { get; set; }
        public string CodiceCer { get; set; }
        public string DescrizioneRifiuto { get; set; }
        public string Operazione { get; set; }
        public string NumMov { get; set; }
        public string IdMov { get; set; }
        public double? Quaton { get; set; }
        public string Targa { get; set; }
        public DateTime? DtReg { get; set; }
        public bool Annullato { get; set; }
        public bool Completo { get; set; }
        public bool Confermato { get; set; }
        public bool FaseAnnullata { get; set; }
    }
}
