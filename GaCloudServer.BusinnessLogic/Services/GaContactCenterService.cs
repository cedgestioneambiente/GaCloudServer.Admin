using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaContactCenterService : IGaContactCenterService
    {
        protected readonly IGenericRepository<ContactCenterComune> gaContactCenterComuniRepo;
        protected readonly IGenericRepository<ContactCenterProvenienza> gaContactCenterProvenienzeRepo;
        protected readonly IGenericRepository<ContactCenterStatoRichiesta> gaContactCenterStatiRichiesteRepo;
        protected readonly IGenericRepository<ContactCenterTipoRichiesta> gaContactCenterTipiRichiesteRepo;
        protected readonly IGenericRepository<ContactCenterMail> gaContactCenterMailsRepo;
        protected readonly IGenericRepository<ContactCenterAllegato> gaContactCenterAllegatiRepo;
        protected readonly IGenericRepository<ContactCenterMailOnTicket> gaContactCenterMailsOnTicketsRepo;
        protected readonly IGenericRepository<ContactCenterTicket> gaContactCenterTicketsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaContactCenterService(

            IGenericRepository<ContactCenterComune> gaContactCenterComuniRepo,
            IGenericRepository<ContactCenterProvenienza> gaContactCenterProvenienzeRepo,
            IGenericRepository<ContactCenterStatoRichiesta> gaContactCenterStatiRichiesteRepo,
            IGenericRepository<ContactCenterTipoRichiesta> gaContactCenterTipiRichiesteRepo,
            IGenericRepository<ContactCenterMail> gaContactCenterMailsRepo,
            IGenericRepository<ContactCenterAllegato> gaContactCenterAllegatiRepo,
            IGenericRepository<ContactCenterMailOnTicket> gaContactCenterMailsOnTicketsRepo,
            IGenericRepository<ContactCenterTicket> gaContactCenterTicketsRepo,

        IUnitOfWork unitOfWork)
        {
            this.gaContactCenterComuniRepo = gaContactCenterComuniRepo;
            this.gaContactCenterProvenienzeRepo = gaContactCenterProvenienzeRepo;
            this.gaContactCenterStatiRichiesteRepo = gaContactCenterStatiRichiesteRepo;
            this.gaContactCenterTipiRichiesteRepo = gaContactCenterTipiRichiesteRepo;
            this.gaContactCenterMailsRepo = gaContactCenterMailsRepo;
            this.gaContactCenterAllegatiRepo = gaContactCenterAllegatiRepo;
            this.gaContactCenterMailsOnTicketsRepo = gaContactCenterMailsOnTicketsRepo;
            this.gaContactCenterTicketsRepo = gaContactCenterTicketsRepo;

            this.unitOfWork = unitOfWork;

        }

        #region ContactCenterComuni
        public async Task<ContactCenterComuniDto> GetGaContactCenterComuniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContactCenterComuniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterComuniDto, PagedList<ContactCenterComune>>();
            return dtos;
        }

        public async Task<ContactCenterComuneDto> GetGaContactCenterComuneByIdAsync(long id)
        {
            var entity = await gaContactCenterComuniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContactCenterComuneDto, ContactCenterComune>();
            return dto;
        }

        public async Task<long> AddGaContactCenterComuneAsync(ContactCenterComuneDto dto)
        {
            var entity = dto.ToEntity<ContactCenterComune, ContactCenterComuneDto>();
            await gaContactCenterComuniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContactCenterComuneAsync(ContactCenterComuneDto dto)
        {
            var entity = dto.ToEntity<ContactCenterComune, ContactCenterComuneDto>();
            gaContactCenterComuniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContactCenterComuneAsync(long id)
        {
            var entity = await gaContactCenterComuniRepo.GetByIdAsync(id);
            gaContactCenterComuniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContactCenterComuneAsync(long id, string descrizione)
        {
            var entity = await gaContactCenterComuniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContactCenterComuneAsync(long id)
        {
            var entity = await gaContactCenterComuniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContactCenterComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContactCenterComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ContactCenterProvenienze
        public async Task<ContactCenterProvenienzeDto> GetGaContactCenterProvenienzeAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContactCenterProvenienzeRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterProvenienzeDto, PagedList<ContactCenterProvenienza>>();
            return dtos;
        }

        public async Task<ContactCenterProvenienzaDto> GetGaContactCenterProvenienzaByIdAsync(long id)
        {
            var entity = await gaContactCenterProvenienzeRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContactCenterProvenienzaDto, ContactCenterProvenienza>();
            return dto;
        }

        public async Task<long> AddGaContactCenterProvenienzaAsync(ContactCenterProvenienzaDto dto)
        {
            var entity = dto.ToEntity<ContactCenterProvenienza, ContactCenterProvenienzaDto>();
            await gaContactCenterProvenienzeRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContactCenterProvenienzaAsync(ContactCenterProvenienzaDto dto)
        {
            var entity = dto.ToEntity<ContactCenterProvenienza, ContactCenterProvenienzaDto>();
            gaContactCenterProvenienzeRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContactCenterProvenienzaAsync(long id)
        {
            var entity = await gaContactCenterProvenienzeRepo.GetByIdAsync(id);
            gaContactCenterProvenienzeRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContactCenterProvenienzaAsync(long id, string descrizione)
        {
            var entity = await gaContactCenterProvenienzeRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContactCenterProvenienzaAsync(long id)
        {
            var entity = await gaContactCenterProvenienzeRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContactCenterProvenienzeRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContactCenterProvenienzeRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ContactCenterStatiRichieste
        public async Task<ContactCenterStatiRichiesteDto> GetGaContactCenterStatiRichiesteAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContactCenterStatiRichiesteRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterStatiRichiesteDto, PagedList<ContactCenterStatoRichiesta>>();
            return dtos;
        }

        public async Task<ContactCenterStatoRichiestaDto> GetGaContactCenterStatoRichiestaByIdAsync(long id)
        {
            var entity = await gaContactCenterStatiRichiesteRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContactCenterStatoRichiestaDto, ContactCenterStatoRichiesta>();
            return dto;
        }

        public async Task<long> AddGaContactCenterStatoRichiestaAsync(ContactCenterStatoRichiestaDto dto)
        {
            var entity = dto.ToEntity<ContactCenterStatoRichiesta, ContactCenterStatoRichiestaDto>();
            await gaContactCenterStatiRichiesteRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContactCenterStatoRichiestaAsync(ContactCenterStatoRichiestaDto dto)
        {
            var entity = dto.ToEntity<ContactCenterStatoRichiesta, ContactCenterStatoRichiestaDto>();
            gaContactCenterStatiRichiesteRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContactCenterStatoRichiestaAsync(long id)
        {
            var entity = await gaContactCenterStatiRichiesteRepo.GetByIdAsync(id);
            gaContactCenterStatiRichiesteRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContactCenterStatoRichiestaAsync(long id, string descrizione)
        {
            var entity = await gaContactCenterStatiRichiesteRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContactCenterStatoRichiestaAsync(long id)
        {
            var entity = await gaContactCenterStatiRichiesteRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContactCenterStatiRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContactCenterStatiRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ContactCenterTipiRichieste
        public async Task<ContactCenterTipiRichiesteDto> GetGaContactCenterTipiRichiesteAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContactCenterTipiRichiesteRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterTipiRichiesteDto, PagedList<ContactCenterTipoRichiesta>>();
            return dtos;
        }

        public async Task<ContactCenterTipoRichiestaDto> GetGaContactCenterTipoRichiestaByIdAsync(long id)
        {
            var entity = await gaContactCenterTipiRichiesteRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContactCenterTipoRichiestaDto, ContactCenterTipoRichiesta>();
            return dto;
        }

        public async Task<long> AddGaContactCenterTipoRichiestaAsync(ContactCenterTipoRichiestaDto dto)
        {
            var entity = dto.ToEntity<ContactCenterTipoRichiesta, ContactCenterTipoRichiestaDto>();
            await gaContactCenterTipiRichiesteRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContactCenterTipoRichiestaAsync(ContactCenterTipoRichiestaDto dto)
        {
            var entity = dto.ToEntity<ContactCenterTipoRichiesta, ContactCenterTipoRichiestaDto>();
            gaContactCenterTipiRichiesteRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContactCenterTipoRichiestaAsync(long id)
        {
            var entity = await gaContactCenterTipiRichiesteRepo.GetByIdAsync(id);
            gaContactCenterTipiRichiesteRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContactCenterTipoRichiestaAsync(long id, string descrizione)
        {
            var entity = await gaContactCenterTipiRichiesteRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContactCenterTipoRichiestaAsync(long id)
        {
            var entity = await gaContactCenterTipiRichiesteRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContactCenterTipiRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContactCenterTipiRichiesteRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ContactCenterMails
        public async Task<ContactCenterMailsDto> GetGaContactCenterMailsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContactCenterMailsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterMailsDto, PagedList<ContactCenterMail>>();
            return dtos;
        }

        public async Task<ContactCenterMailDto> GetGaContactCenterMailByIdAsync(long id)
        {
            var entity = await gaContactCenterMailsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContactCenterMailDto, ContactCenterMail>();
            return dto;
        }

        public async Task<long> AddGaContactCenterMailAsync(ContactCenterMailDto dto)
        {
            var entity = dto.ToEntity<ContactCenterMail, ContactCenterMailDto>();
            await gaContactCenterMailsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContactCenterMailAsync(ContactCenterMailDto dto)
        {
            var entity = dto.ToEntity<ContactCenterMail, ContactCenterMailDto>();
            gaContactCenterMailsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContactCenterMailAsync(long id)
        {
            var entity = await gaContactCenterMailsRepo.GetByIdAsync(id);
            gaContactCenterMailsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContactCenterMailAsync(long id, string mail)
        {
            var entity = await gaContactCenterMailsRepo.GetWithFilterAsync(x => x.Mail == mail && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContactCenterMailAsync(long id)
        {
            var entity = await gaContactCenterMailsRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContactCenterMailsRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContactCenterMailsRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ContactCenterAllegati
        public async Task<ContactCenterAllegatiDto> GetGaContactCenterAllegatiAsync(long id)
        {
            var entities = await gaContactCenterAllegatiRepo.GetWithFilterAsync(x => x.ContactCenterTicketId == id);
            var dtos = entities.ToDto<ContactCenterAllegatiDto, PagedList<ContactCenterAllegato>>();

            await SaveChanges();
            return dtos;
        }

        public async Task<ContactCenterAllegatoDto> GetGaContactCenterAllegatoByIdAsync(long id)
        {
            var entity = await gaContactCenterAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContactCenterAllegatoDto, ContactCenterAllegato>();
            return dto;
        }

        public async Task<long> AddGaContactCenterAllegatoAsync(ContactCenterAllegatoDto dto)
        {
            var entity = dto.ToEntity<ContactCenterAllegato, ContactCenterAllegatoDto>();
            await gaContactCenterAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContactCenterAllegatoAsync(ContactCenterAllegatoDto dto)
        {
            var entity = dto.ToEntity<ContactCenterAllegato, ContactCenterAllegatoDto>();
            gaContactCenterAllegatiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContactCenterAllegatoAsync(long id)
        {
            var entity = await gaContactCenterAllegatiRepo.GetByIdAsync(id);
            gaContactCenterAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        //public async Task<bool> ValidateGaContactCenterAllegatoAsync(long id, string descrizione)
        //{
        //    var entity = await gaContactCenterAllegatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public async Task<bool> ChangeStatusGaContactCenterAllegatoAsync(long id)
        //{
        //    var entity = await gaContactCenterAllegatiRepo.GetByIdAsync(id);
        //    if (entity.Disabled)
        //    {
        //        entity.Disabled = false;
        //        gaContactCenterAllegatiRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        entity.Disabled = true;
        //        gaContactCenterAllegatiRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }

        //}
        #endregion

        #endregion

        #region ContactCenterMailsOnTickets
        public async Task<ContactCenterMailsOnTicketsDto> GetGaContactCenterMailsOnTicketsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContactCenterMailsOnTicketsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterMailsOnTicketsDto, PagedList<ContactCenterMailOnTicket>>();
            return dtos;
        }

        public async Task<ContactCenterMailsOnTicketsDto> GetGaContactCenterMailsOnTicketsByTicketIdAsync(long ticketId)
        {
                var entities = await gaContactCenterMailsOnTicketsRepo.GetWithFilterAsync(x => x.ContactCenterTicketId == ticketId);
                var dtos = entities.ToDto<ContactCenterMailsOnTicketsDto, PagedList<ContactCenterMailOnTicket>>();

                await SaveChanges();
                return dtos;
        }

        public async Task<ContactCenterMailOnTicketDto> GetGaContactCenterMailOnTicketByIdAsync(long id)
        {
            var entity = await gaContactCenterMailsOnTicketsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContactCenterMailOnTicketDto, ContactCenterMailOnTicket>();
            return dto;
        }

        //public async Task<long> AddGaContactCenterMailOnTicketAsync(ContactCenterMailOnTicketDto dto)
        //{
        //    try
        //    {
        //        foreach (var itm in dto.Data)
        //        {
        //            var entity = new ContactCenterMailOnTicket();
        //            entity.Id = 0;
        //            entity.ContactCenterMailId = itm.ContactCenterMailId;
        //            entity.MailAddress = itm.MailAddress;
        //            entity.ContactCenterTicketId = id;
        //            entity.Disabled = false;
        //            entity.Data = itm.Data;
        //            await gaContactCenterMailsOnTicketsRepo.AddAsync(entity);
        //            await SaveChanges();
        //        }
        //        var ticket = gaContactCenterTicketsRepo.GetById(id);
        //        ticket.Inviato = true;
        //        gaContactCenterTicketsRepo.Update(ticket);
        //        await SaveChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        await SaveChanges();
        //        throw;
        //    }
        //}

        public async Task<long> UpdateGaContactCenterMailOnTicketAsync(ContactCenterMailOnTicketDto dto)
        {
            var entity = dto.ToEntity<ContactCenterMailOnTicket, ContactCenterMailOnTicketDto>();
            gaContactCenterMailsOnTicketsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContactCenterMailOnTicketAsync(long id)
        {
            var entity = await gaContactCenterMailsOnTicketsRepo.GetByIdAsync(id);
            gaContactCenterMailsOnTicketsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        //public async Task<bool> ValidateGaContactCenterMailOnTicketAsync(long id, string descrizione)
        //{
        //    var entity = await gaContactCenterMailsOnTicketsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public async Task<bool> ChangeStatusGaContactCenterMailOnTicketAsync(long id)
        //{
        //    var entity = await gaContactCenterMailsOnTicketsRepo.GetByIdAsync(id);
        //    if (entity.Disabled)
        //    {
        //        entity.Disabled = false;
        //        gaContactCenterMailsOnTicketsRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        entity.Disabled = true;
        //        gaContactCenterMailsOnTicketsRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }

        //}
        #endregion

        #endregion

        #region ContactCenterTickets
        public async Task<ContactCenterTicketsDto> GetGaContactCenterTicketsAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContactCenterTicketsRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContactCenterTicketsDto, PagedList<ContactCenterTicket>>();
            return dtos;
        }

        public async Task<ContactCenterTicketDto> GetGaContactCenterTicketByIdAsync(long id)
        {
            var entity = await gaContactCenterTicketsRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContactCenterTicketDto, ContactCenterTicket>();
            return dto;
        }

        public async Task<long> AddGaContactCenterTicketAsync(ContactCenterTicketDto dto)
        {
            var entity = dto.ToEntity<ContactCenterTicket, ContactCenterTicketDto>();
            await gaContactCenterTicketsRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContactCenterTicketAsync(ContactCenterTicketDto dto)
        {
            var entity = dto.ToEntity<ContactCenterTicket, ContactCenterTicketDto>();
            gaContactCenterTicketsRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContactCenterTicketAsync(long id)
        {
            var entity = await gaContactCenterTicketsRepo.GetByIdAsync(id);
            gaContactCenterTicketsRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        //public async Task<bool> ValidateGaContactCenterTicketAsync(long id, string descrizione)
        //{
        //    var entity = await gaContactCenterTicketsRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public async Task<bool> ChangeStatusGaContactCenterTicketAsync(long id)
        //{
        //    var entity = await gaContactCenterTicketsRepo.GetByIdAsync(id);
        //    if (entity.Disabled)
        //    {
        //        entity.Disabled = false;
        //        gaContactCenterTicketsRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        entity.Disabled = true;
        //        gaContactCenterTicketsRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }

        //}
        

        public async Task<bool> DuplicateGaContactCenterTicketAsync(long[] ticketsId, string userId, bool stampato)
        {
            try
            {
                foreach (var itm in ticketsId)
                {
                    var entity = gaContactCenterTicketsRepo.GetByIdAsNoTraking(x => x.Id == itm);
                    entity.Id = 0;
                    entity.RichiedenteId = userId;
                    entity.Stampato = false;
                    gaContactCenterTicketsRepo.Add(entity);

                }

                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<bool> SetDoneGaContactCenterTicketAsync(long[] ticketsId)
        {

            try
            {
                foreach (var itm in ticketsId)
                {
                    var entity = gaContactCenterTicketsRepo.GetByIdAsNoTraking(x => x.Id == itm);
                    entity.ContactCenterStatoRichiestaId = 2;
                    gaContactCenterTicketsRepo.Update(entity);

                }

                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<bool> SetUndoneGaContactCenterTicketAsync(long[] ticketsId)
        {
            try
            {
                foreach (var itm in ticketsId)
                {
                    var entity = gaContactCenterTicketsRepo.GetByIdAsNoTraking(x => x.Id == itm);
                    entity.ContactCenterStatoRichiestaId = 1;
                    gaContactCenterTicketsRepo.Update(entity);

                }

                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<bool> SetPrintedGaContactCenterTicketAsync(long[] ticketsId)
        {
            try
            {
                foreach (var itm in ticketsId)
                {
                    var entity = gaContactCenterTicketsRepo.GetByIdAsNoTraking(x => x.Id == itm);
                    entity.Stampato = true;
                    gaContactCenterTicketsRepo.Update(entity);

                }

                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion
       
        #endregion

        #region Common
        private async Task<long> SaveChanges()
        {
            return await unitOfWork.SaveChangesAsync();
        }

        private void DetachEntity<T>(T entity)
        {
            unitOfWork.DetachEntity(entity);
        }

        public Task<long> AddGaContactCenterMailOnTicketAsync(long id, ContactCenterMailOnTicketDto dto)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}