using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views
{
    public class ViewGaPreventiviAnticipi : GenericEntity
    {
        public string RagioneSociale { get; set; }
        public string Numero { get; set; }
        public DateTime DataPreventivo { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string CfPiva { get; set; }
        public double ValorePrevisto { get; set; }
        public double? ValoreIncassato { get; set; }
        public string NoteContabili { get; set; }
        public string NoteOperative { get; set; }
        public string Causale { get; set; }
        public bool Pagato { get; set; }
        public bool Fatturato { get; set; }
        public long PreventiviAnticipoTipologiaId { get; set; }
        public long PreventiviAnticipoPagamentoId { get; set; }
        public string TipoPagamento { get; set; }
        public string TipoLavoro { get; set; }
        public string Saldo { get; set; }

    }
}
