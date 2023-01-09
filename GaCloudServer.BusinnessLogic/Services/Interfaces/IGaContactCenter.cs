using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaContactCenterService
    {
        #region GaContactCenterComuni
        Task<ContactCenterComuniDto> GetGaContactCenterComuniAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterComuneDto> GetGaContactCenterComuneByIdAsync(long id);

        Task<long> AddGaContactCenterComuneAsync(ContactCenterComuneDto dto);
        Task<long> UpdateGaContactCenterComuneAsync(ContactCenterComuneDto dto);

        Task<bool> DeleteGaContactCenterComuneAsync(long id);

        #region Functions
        Task<bool> ValidateGaContactCenterComuneAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContactCenterComuneAsync(long id);
        #endregion

        #endregion

        #region GaContactCenterProvenienze
        Task<ContactCenterProvenienzeDto> GetGaContactCenterProvenienzeAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterProvenienzaDto> GetGaContactCenterProvenienzaByIdAsync(long id);

        Task<long> AddGaContactCenterProvenienzaAsync(ContactCenterProvenienzaDto dto);
        Task<long> UpdateGaContactCenterProvenienzaAsync(ContactCenterProvenienzaDto dto);

        Task<bool> DeleteGaContactCenterProvenienzaAsync(long id);

        #region Functions
        Task<bool> ValidateGaContactCenterProvenienzaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContactCenterProvenienzaAsync(long id);
        #endregion

        #endregion

        #region GaContactCenterStatiRichieste
        Task<ContactCenterStatiRichiesteDto> GetGaContactCenterStatiRichiesteAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterStatoRichiestaDto> GetGaContactCenterStatoRichiestaByIdAsync(long id);

        Task<long> AddGaContactCenterStatoRichiestaAsync(ContactCenterStatoRichiestaDto dto);
        Task<long> UpdateGaContactCenterStatoRichiestaAsync(ContactCenterStatoRichiestaDto dto);

        Task<bool> DeleteGaContactCenterStatoRichiestaAsync(long id);

        #region Functions
        Task<bool> ValidateGaContactCenterStatoRichiestaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContactCenterStatoRichiestaAsync(long id);
        #endregion

        #endregion

        #region GaContactCenterTipiRichieste
        Task<ContactCenterTipiRichiesteDto> GetGaContactCenterTipiRichiesteAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterTipoRichiestaDto> GetGaContactCenterTipoRichiestaByIdAsync(long id);

        Task<long> AddGaContactCenterTipoRichiestaAsync(ContactCenterTipoRichiestaDto dto);
        Task<long> UpdateGaContactCenterTipoRichiestaAsync(ContactCenterTipoRichiestaDto dto);

        Task<bool> DeleteGaContactCenterTipoRichiestaAsync(long id);

        #region Functions
        Task<bool> ValidateGaContactCenterTipoRichiestaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaContactCenterTipoRichiestaAsync(long id);
        #endregion

        #endregion

        #region GaContactCenterMails
        Task<ContactCenterMailsDto> GetGaContactCenterMailsAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterMailDto> GetGaContactCenterMailByIdAsync(long id);

        Task<long> AddGaContactCenterMailAsync(ContactCenterMailDto dto);
        Task<long> UpdateGaContactCenterMailAsync(ContactCenterMailDto dto);

        Task<bool> DeleteGaContactCenterMailAsync(long id);

        #region Functions
        Task<bool> ValidateGaContactCenterMailAsync(long id, string mail);
        Task<bool> ChangeStatusGaContactCenterMailAsync(long id);
        #endregion

        #endregion

        #region GaContactCenterAllegati
        Task<ContactCenterAllegatiDto> GetGaContactCenterAllegatiByTicketIdAsync(long contactCenterTicketId);
        Task<ContactCenterAllegatoDto> GetGaContactCenterAllegatoByIdAsync(long id);

        Task<long> AddGaContactCenterAllegatoAsync(ContactCenterAllegatoDto dto);
        Task<long> UpdateGaContactCenterAllegatoAsync(ContactCenterAllegatoDto dto);

        Task<bool> DeleteGaContactCenterAllegatoAsync(long id);

        #region Functions
        //Task<bool> ValidateGaContactCenterAllegatoAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaContactCenterAllegatoAsync(long id);
        #endregion

        #endregion

        #region GaContactCenterMailsOnTickets
        Task<ContactCenterMailsOnTicketsDto> GetGaContactCenterMailsOnTicketsAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterMailsOnTicketsDto> GetGaContactCenterMailsOnTicketsByTicketIdAsync(long ticketId);
        Task<ContactCenterMailOnTicketDto> GetGaContactCenterMailOnTicketByIdAsync(long id);

        Task<bool> AddGaContactCenterMailOnTicketAsync(long id, ContactCenterMailsOnTicketsDto dto);
        Task<long> UpdateGaContactCenterMailOnTicketAsync(ContactCenterMailOnTicketDto dto);

        Task<bool> DeleteGaContactCenterMailOnTicketAsync(long id);

        #region Functions
        //Task<bool> ValidateGaContactCenterMailOnTicketAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaContactCenterMailOnTicketAsync(long id);
        #endregion

        #endregion

        #region GaContactCenterTickets
        Task<ContactCenterTicketsDto> GetGaContactCenterTicketsAsync(int page = 1, int pageSize = 0);
        Task<ContactCenterTicketDto> GetGaContactCenterTicketByIdAsync(long id);

        Task<long> AddGaContactCenterTicketAsync(ContactCenterTicketDto dto);
        Task<long> UpdateGaContactCenterTicketAsync(ContactCenterTicketDto dto);

        Task<bool> DeleteGaContactCenterTicketAsync(long id);

        #region Functions
        //Task<bool> ValidateGaContactCenterTicketAsync(long id, string descrizione);
        //Task<bool> ChangeStatusGaContactCenterTicketAsync(long id);
        Task<PagedList<ViewGaContactCenterTicketsIngombranti>> GetGaContactCenterTicketsIngAsync(long comuneId, DateTime dataEsecuzione);
        Task<bool> DuplicateGaContactCenterTicketAsync(long[] ticketsId, string userId, bool stampato);
        Task<bool> SetDoneGaContactCenterTicketAsync(long[] ticketsId);
        Task<bool> SetUndoneGaContactCenterTicketAsync(long[] ticketsId);
        Task<bool> SetPrintedGaContactCenterTicketsAsync(long[] ticketsId);
        #endregion

        #region Views
        Task<List<ViewGaContactCenterTickets>> GetGaContactCenterTicketsIngPrintAsync(string comune, DateTime? dataEsecuzione, int tipoStampa);
        Task<List<ViewFoContactCenterTickets>> GetFoContactCenterTicketsIngPrintAsync(string comune, DateTime? dataEsecuzione, int tipoStampa);
        Task<List<ViewGaContactCenterTickets>> GetGaContactCenterTicketsIntPrintAsync(long? fromId, long? toId, DateTime? fromData, DateTime? toData);
        Task<List<ViewFoContactCenterTickets>> GetFoContactCenterTicketsIntPrintAsync(long? fromId, long? toId, DateTime? fromData, DateTime? toData);
        PagedList<ViewGaContactCenterTickets> GetViewGaContactCenterTicketsQueryable(GridOperationsModel filterParams);
        PagedList<ViewFoContactCenterTickets> GetViewFoContactCenterTicketsQueryable(GridOperationsModel filterParams);
        List<ViewGaContactCenterTickets> GetViewGaContactCenterTicketsQueryableNoSkip(GridOperationsModel filterParams);
        List<ViewFoContactCenterTickets> GetViewFoContactCenterTicketsQueryableNoSkip(GridOperationsModel filterParams);
        Task<ViewGaContactCenterTickets> GetViewGaContactCenterTicketById(long id);
        #endregion

        #endregion
    }
}

