
using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.BackOffice
{
    #region BackOfficeStatiTickets
    public class BackOfficeStatoTicketApiDto : GenericListApiDto
    {
    }

    public class BackOfficeStatiTicketsApiDto : GenericPagedListApiDto<BackOfficeStatoTicketApiDto>
    {
    }
    #endregion

    #region BackOfficeTipiTickets
    public class BackOfficeTipoTicketApiDto : GenericListApiDto
    {
    }

    public class BackOfficeTipiTicketsApiDto : GenericPagedListApiDto<BackOfficeTipoTicketApiDto>
    {
    }
    #endregion

    #region BackOfficeTickets
    public class BackOfficeTicketApiDto : GenericApiDto
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

    public class BackOfficeTicketsApiDto : GenericPagedListApiDto<BackOfficeTicketApiDto>
    {

    }
    #endregion

}
