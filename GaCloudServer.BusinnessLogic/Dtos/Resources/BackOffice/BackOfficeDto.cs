using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice
{
    #region BackOfficeStatiTickets
    public class BackOfficeStatoTicketDto:GenericListDto
    {
    }

    public class BackOfficeStatiTicketsDto:GenericPagedListDto<BackOfficeStatoTicketDto>
    {
    }
    #endregion

    #region BackOfficeTipiTickets
    public class BackOfficeTipoTicketDto:GenericListDto
    {
    }

    public class BackOfficeTipiTicketsDto:GenericPagedListDto<BackOfficeTipoTicketDto>
    {
    }
    #endregion

    #region BackOfficeTickets
    public class BackOfficeTicketDto:GenericDto
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public long BackOfficeTipoTicketId { get; set; }
        public string NumCon { get; set; }
        public string Descrizione { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public long BackOfficeStatoTicketId { get; set; }
        public string UserId { get; set; }
        public bool Disabled { get; set; }
    }

    public class BackOfficeTicketsDto:GenericPagedListDto<BackOfficeTicketDto>
    {
        
    }
    #endregion

    #region Internal
    public class BackOfficeMaxContDto
    {
        public double Secco { get; set; }
        public double Carta { get; set; }
        public double Plastica { get; set; }
        public double Umido { get; set; }
        public double Vegetale { get; set; }
        public double Vetro { get; set; }

        public BackOfficeMaxContDto()
        {
            Secco = 0;
            Carta = 0;
            Plastica = 0;
            Umido = 0;
            Vegetale = 0;
            Vetro = 0;
        }
    }

    public class BackOfficeCategoriaOnUtenzaDto
    {
        public string CodCategoria { get; set; }
        public string DescCategoria { get; set; }
        public double KgMqSmaltimentoRsu { get; set; }
        public double KgMqRecuperoCarta { get; set; }
        public double KgMqRecuperoPlastica { get; set; }
        public double KgMqRecuperoVetro { get; set; }
        public double KgMqRecuperoUmido { get; set; }
        public int PercentualeAutoSmaltimento { get; set; }
        public int NumeroSvuotamentiRsu { get; set; }
        public int Superficie { get; set; }

        public BackOfficeCategoriaOnUtenzaDto() { }

    }

    public class BackOfficeUtenzaPartiteDto : GenericPagedListDto<ViewGaBackOfficeUtenzePartite> { 
    }
    #endregion

}
