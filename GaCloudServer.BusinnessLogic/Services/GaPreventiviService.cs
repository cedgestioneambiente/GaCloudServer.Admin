using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPreventiviService : IGaPreventiviService
    {
        #region OLD
        protected readonly IGenericRepository<PreventiviAnticipoTipologia> gaPreventiviAnticipiTipologieRepo;
        protected readonly IGenericRepository<PreventiviAnticipo> gaPreventiviAnticipiRepo;
        protected readonly IGenericRepository<PreventiviAnticipoAllegato> gaPreventiviAnticipiAllegatiRepo;
        protected readonly IGenericRepository<PreventiviAnticipoPagamento> gaPreventiviAnticipiPagamentiRepo;
        #endregion

        protected readonly IQueryManager queryManager;

        protected readonly IGenericRepository<PreventiviObject> gaPreventiviObjectsRepo;
        protected readonly IGenericRepository<PreventiviObjectType> gaPreventiviObjectTypesRepo;
        protected readonly IGenericRepository<PreventiviObjectStatus> gaPreventiviObjectStatusesRepo;
        protected readonly IGenericRepository<PreventiviObjectInspectionMode> gaPreventiviObjectInspectionModesRepo;
        protected readonly IGenericRepository<PreventiviObjectInspection> gaPreventiviObjectInspectionsRepo;
        protected readonly IGenericRepository<PreventiviAction> gaPreventiviActionsRepo;
        protected readonly IGenericRepository<PreventiviObjectAttachment> gaPreventiviObjectAttachmentsRepo;
        protected readonly IGenericRepository<PreventiviObjectInspectionAttachment> gaPreventiviObjectInspectionAttachmentsRepo;
        protected readonly IGenericRepository<PreventiviObjectInspectionImage> gaPreventiviObjectInspectionImagesRepo;
        protected readonly IGenericRepository<PreventiviObjectServiceType> gaPreventiviObjectServiceTypesRepo;
        protected readonly IGenericRepository<PreventiviObjectServiceTypeDetail> gaPreventiviObjectServiceTypeDetailsRepo;
        protected readonly IGenericRepository<PreventiviObjectService> gaPreventiviObjectServicesRepo;
        protected readonly IGenericRepository<PreventiviObjectSection> gaPreventiviObjectSectionsRepo;
        protected readonly IGenericRepository<PreventiviGarbage> gaPreventiviGarbagesRepo;
        protected readonly IGenericRepository<PreventiviServiceNoteTemplate> gaPreventiviServiceNoteTemplatesRepo;
        protected readonly IGenericRepository<PreventiviConditionTemplate> gaPreventiviConditionTemplatesRepo;
        protected readonly IGenericRepository<PreventiviObjectPeriod> gaPreventiviObjectPeriodsRepo;
        protected readonly IGenericRepository<PreventiviObjectPayout> gaPreventiviObjectPayoutsRepo;
        protected readonly IGenericRepository<PreventiviObjectCondition> gaPreventiviObjectConditionsRepo;
        protected readonly IGenericRepository<PreventiviProducer> gaPreventiviProducersRepo;
        protected readonly IGenericRepository<PreventiviDestination> gaPreventiviDestinationsRepo;
        protected readonly IGenericRepository<PreventiviObjectHistory> gaPreventiviObjectHistoriesRepo;


        protected readonly IGenericRepository<CrmTicketAllegato> gaCrmTicketAttachmentsRepo;
        protected readonly IGenericRepository<CrmEventComune> gaCrmEventComuniRepo;

        protected readonly IGenericRepository<ViewGaPreventiviCrmTickets> viewGaPreventiviCrmTicketsRepo;

        protected readonly IGenericRepository<ViewGaPreventiviAnticipi> viewGaPreventiviAnticipiRepo;
        protected readonly IGenericRepository<ViewGaPreventiviIsmartDocumenti> viewGaPreventiviIsmartDocumentiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaPreventiviService(
            IQueryManager queryManager,

            IGenericRepository<PreventiviAnticipoTipologia> gaPreventiviAnticipiTipologieRepo,
            IGenericRepository<PreventiviAnticipo> gaPreventiviAnticipiRepo,
            IGenericRepository<PreventiviAnticipoAllegato> gaPreventiviAnticipiAllegatiRepo,
            IGenericRepository<PreventiviAnticipoPagamento> gaPreventiviAnticipiPagamentiRepo,

            IGenericRepository<PreventiviObject> gaPreventiviObjectsRepo,
            IGenericRepository<PreventiviObjectType> gaPreventiviObjectTypesRepo,
            IGenericRepository<PreventiviObjectStatus> gaPreventiviObjectStatusesRepo,
            IGenericRepository<PreventiviAction> gaPreventiviActionsRepo,
            IGenericRepository<PreventiviObjectInspectionMode> gaPreventiviObjectInspectionModesRepo,
            IGenericRepository<PreventiviObjectInspection> gaPreventiviObjectInspectionsRepo,
            IGenericRepository<PreventiviObjectAttachment> gaPreventiviObjectAttachmentsRepo,
            IGenericRepository<PreventiviObjectInspectionAttachment> gaPreventiviObjectInspectionAttachmentsRepo,
            IGenericRepository<PreventiviObjectInspectionImage> gaPreventiviObjectInspectionImagesRepo,

            IGenericRepository<PreventiviObjectServiceType> gaPreventiviObjectServiceTypesRepo,
            IGenericRepository<PreventiviObjectServiceTypeDetail> gaPreventiviObjectServiceTypeDetailsRepo,
            IGenericRepository<PreventiviObjectService> gaPreventiviObjectServicesRepo,
            IGenericRepository<PreventiviObjectSection> gaPreventiviObjectSectionsRepo,
            IGenericRepository<PreventiviGarbage> gaPreventiviGarbagesRepo,

            IGenericRepository<PreventiviServiceNoteTemplate> gaPreventiviServiceNoteTemplatesRepo,
            IGenericRepository<PreventiviConditionTemplate> gaPreventiviConditionTemplatesRepo,
            IGenericRepository<PreventiviObjectPeriod> gaPreventiviObjectPeriodsRepo,
            IGenericRepository<PreventiviObjectPayout> gaPreventiviObjectPayoutsRepo,
            IGenericRepository<PreventiviObjectCondition> gaPreventiviObjectConditionsRepo,
            IGenericRepository<PreventiviProducer> gaPreventiviProducersRepo,
            IGenericRepository<PreventiviDestination> gaPreventiviDestinationsRepo,

            IGenericRepository<CrmTicketAllegato> gaCrmTicketAttachmentsRepo,
            IGenericRepository<CrmEventComune> gaCrmEventComuniRepo,

            IGenericRepository<PreventiviObjectHistory> gaPreventiviObjectHistoriesRepo,

            IGenericRepository<ViewGaPreventiviCrmTickets> viewGaPreventiviCrmTicketsRepo,

            IGenericRepository<ViewGaPreventiviAnticipi> viewGaPreventiviAnticipiRepo,
            IGenericRepository<ViewGaPreventiviIsmartDocumenti> viewGaPreventiviIsmartDocumentiRepo,




            IUnitOfWork unitOfWork)
        {
            #region OLD
            this.gaPreventiviAnticipiTipologieRepo = gaPreventiviAnticipiTipologieRepo;
            this.gaPreventiviAnticipiRepo = gaPreventiviAnticipiRepo;
            this.gaPreventiviAnticipiAllegatiRepo = gaPreventiviAnticipiAllegatiRepo;
            this.gaPreventiviAnticipiPagamentiRepo = gaPreventiviAnticipiPagamentiRepo;

            this.viewGaPreventiviAnticipiRepo = viewGaPreventiviAnticipiRepo;
            #endregion

            this.queryManager = queryManager;

            this.gaPreventiviObjectsRepo = gaPreventiviObjectsRepo;
            this.gaPreventiviObjectStatusesRepo= gaPreventiviObjectStatusesRepo;
            this.gaPreventiviObjectTypesRepo= gaPreventiviObjectTypesRepo;
            this.gaPreventiviActionsRepo = gaPreventiviActionsRepo;
            this.gaPreventiviObjectInspectionModesRepo = gaPreventiviObjectInspectionModesRepo;
            this.gaPreventiviObjectInspectionsRepo = gaPreventiviObjectInspectionsRepo;
            this.gaPreventiviObjectAttachmentsRepo = gaPreventiviObjectAttachmentsRepo;
            this.gaPreventiviObjectInspectionAttachmentsRepo = gaPreventiviObjectInspectionAttachmentsRepo;
            this.gaPreventiviObjectInspectionImagesRepo = gaPreventiviObjectInspectionImagesRepo;
            this.gaPreventiviObjectServiceTypesRepo = gaPreventiviObjectServiceTypesRepo;
            this.gaPreventiviObjectServiceTypeDetailsRepo = gaPreventiviObjectServiceTypeDetailsRepo;
            this.gaPreventiviObjectServicesRepo= gaPreventiviObjectServicesRepo;
            this.gaPreventiviObjectSectionsRepo= gaPreventiviObjectSectionsRepo;
            this.gaPreventiviGarbagesRepo = gaPreventiviGarbagesRepo;
            this.gaPreventiviServiceNoteTemplatesRepo= gaPreventiviServiceNoteTemplatesRepo;
            this.gaPreventiviConditionTemplatesRepo= gaPreventiviConditionTemplatesRepo;
            this.gaPreventiviObjectPeriodsRepo= gaPreventiviObjectPeriodsRepo;
            this.gaPreventiviObjectPayoutsRepo = gaPreventiviObjectPayoutsRepo;
            this.gaPreventiviObjectConditionsRepo= gaPreventiviObjectConditionsRepo;
            this.gaPreventiviProducersRepo = gaPreventiviProducersRepo;
            this.gaPreventiviDestinationsRepo = gaPreventiviDestinationsRepo;

            this.gaCrmTicketAttachmentsRepo= gaCrmTicketAttachmentsRepo;
            this.gaCrmEventComuniRepo = gaCrmEventComuniRepo;

            this.gaPreventiviObjectHistoriesRepo= gaPreventiviObjectHistoriesRepo;

            this.viewGaPreventiviCrmTicketsRepo = viewGaPreventiviCrmTicketsRepo;
            this.viewGaPreventiviIsmartDocumentiRepo = viewGaPreventiviIsmartDocumentiRepo;

            this.unitOfWork = unitOfWork;
        }

        #region OLD

        #region PreventiviAnticipiTipologie
        public async Task<PreventiviAnticipiTipologieDto> GetGaPreventiviAnticipiTipologieAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPreventiviAnticipiTipologieRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PreventiviAnticipiTipologieDto, PagedList<PreventiviAnticipoTipologia>>();
            return dtos;
        }

        public async Task<PreventiviAnticipoTipologiaDto> GetGaPreventiviAnticipoTipologiaByIdAsync(long id)
        {
            var entity = await gaPreventiviAnticipiTipologieRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PreventiviAnticipoTipologiaDto, PreventiviAnticipoTipologia>();
            return dto;
        }

        public async Task<long> AddGaPreventiviAnticipoTipologiaAsync(PreventiviAnticipoTipologiaDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoTipologia, PreventiviAnticipoTipologiaDto>();
            await gaPreventiviAnticipiTipologieRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPreventiviAnticipoTipologiaAsync(PreventiviAnticipoTipologiaDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoTipologia, PreventiviAnticipoTipologiaDto>();
            gaPreventiviAnticipiTipologieRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPreventiviAnticipoTipologiaAsync(long id)
        {
            var entity = await gaPreventiviAnticipiTipologieRepo.GetByIdAsync(id);
            gaPreventiviAnticipiTipologieRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPreventiviAnticipoTipologiaAsync(long id, string descrizione)
        {
            var entity = await gaPreventiviAnticipiTipologieRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPreventiviAnticipoTipologiaAsync(long id)
        {
            var entity = await gaPreventiviAnticipiTipologieRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPreventiviAnticipiTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPreventiviAnticipiTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PreventiviAnticipiPagamenti
        public async Task<PreventiviAnticipiPagamentiDto> GetGaPreventiviAnticipiPagamentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPreventiviAnticipiPagamentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PreventiviAnticipiPagamentiDto, PagedList<PreventiviAnticipoPagamento>>();
            return dtos;
        }

        public async Task<PreventiviAnticipoPagamentoDto> GetGaPreventiviAnticipoPagamentoByIdAsync(long id)
        {
            var entity = await gaPreventiviAnticipiPagamentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PreventiviAnticipoPagamentoDto, PreventiviAnticipoPagamento>();
            return dto;
        }

        public async Task<long> AddGaPreventiviAnticipoPagamentoAsync(PreventiviAnticipoPagamentoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoPagamento, PreventiviAnticipoPagamentoDto>();
            await gaPreventiviAnticipiPagamentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPreventiviAnticipoPagamentoAsync(PreventiviAnticipoPagamentoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoPagamento, PreventiviAnticipoPagamentoDto>();
            gaPreventiviAnticipiPagamentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPreventiviAnticipoPagamentoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiPagamentiRepo.GetByIdAsync(id);
            gaPreventiviAnticipiPagamentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPreventiviAnticipoPagamentoAsync(long id, string descrizione)
        {
            var entity = await gaPreventiviAnticipiPagamentiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPreventiviAnticipoPagamentoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiPagamentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPreventiviAnticipiPagamentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPreventiviAnticipiPagamentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region PreventiviAnticipi
        public async Task<PreventiviAnticipiDto> GetGaPreventiviAnticipiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPreventiviAnticipiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PreventiviAnticipiDto, PagedList<PreventiviAnticipo>>();
            return dtos;
        }

        public async Task<PreventiviAnticipoDto> GetGaPreventiviAnticipoByIdAsync(long id)
        {
            var entity = await gaPreventiviAnticipiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PreventiviAnticipoDto, PreventiviAnticipo>();
            return dto;
        }

        public async Task<long> AddGaPreventiviAnticipoAsync(PreventiviAnticipoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipo, PreventiviAnticipoDto>();
            await gaPreventiviAnticipiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaPreventiviAnticipoAsync(PreventiviAnticipoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipo, PreventiviAnticipoDto>();
            gaPreventiviAnticipiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPreventiviAnticipoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiRepo.GetByIdAsync(id);
            gaPreventiviAnticipiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPreventiviAnticipoAsync(long id, string numero)
        {
            var entity = await gaPreventiviAnticipiRepo.GetWithFilterAsync(x => x.Numero == numero && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPreventiviAnticipoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPreventiviAnticipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPreventiviAnticipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<bool> SetGaPreventiviAnticipoPagatoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiRepo.GetByIdAsync(id);
            if (entity.Pagato)
            {
                entity.Pagato = false;
                gaPreventiviAnticipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Pagato = true;
                gaPreventiviAnticipiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaPreventiviAnticipi>> GetViewGaPreventiviAnticipiAsync()
        {
            try
            {
                return await viewGaPreventiviAnticipiRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        #endregion

        #endregion

        #region PreventiviAnticipiAllegati
        public async Task<PreventiviAnticipiAllegatiDto> GetGaPreventiviAnticipiAllegatiByAnticipoAsync(long preventiviAnticipoId)
        {
            var entities = await gaPreventiviAnticipiAllegatiRepo.GetWithFilterAsync(x => x.PreventiviAnticipoId == preventiviAnticipoId);
            var dtos = entities.ToDto<PreventiviAnticipiAllegatiDto, PagedList<PreventiviAnticipoAllegato>>();
            return dtos;
        }


        public async Task<PreventiviAnticipoAllegatoDto> GetGaPreventiviAnticipoAllegatoByIdAsync(long id)
        {
            var entity = await gaPreventiviAnticipiAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PreventiviAnticipoAllegatoDto, PreventiviAnticipoAllegato>();
            return dto;
        }

        public async Task<long> AddGaPreventiviAnticipoAllegatoAsync(PreventiviAnticipoAllegatoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoAllegato, PreventiviAnticipoAllegatoDto>();
            await gaPreventiviAnticipiAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;
        }

        public async Task<long> UpdateGaPreventiviAnticipoAllegatoAsync(PreventiviAnticipoAllegatoDto dto)
        {
            var entity = dto.ToEntity<PreventiviAnticipoAllegato, PreventiviAnticipoAllegatoDto>();
            gaPreventiviAnticipiAllegatiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;

        }

        public async Task<bool> DeleteGaPreventiviAnticipoAllegatoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiAllegatiRepo.GetByIdAsync(id);
            gaPreventiviAnticipiAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPreventiviAnticipoAllegatoAsync(long id, string descrizione)
        {
            var entity = await gaPreventiviAnticipiAllegatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaPreventiviAnticipoAllegatoAsync(long id)
        {
            var entity = await gaPreventiviAnticipiAllegatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaPreventiviAnticipiAllegatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaPreventiviAnticipiAllegatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #endregion

        #region Crm Tickets
        public async Task<PageResponse<ViewGaPreventiviCrmTickets>> GetViewPreventiviCrmTicketsAsync(PageRequest request)
        {
            var view = await viewGaPreventiviCrmTicketsRepo.GetAsync(request);
            return view;
        }

        public async Task<PageResponse<CrmEventComuneDto>> GetPreventiviCrmComuniAsync(PageRequest request)
        {
            var entities = await gaCrmEventComuniRepo.GetAsync(request);
            return entities.ToModel<PageResponse<CrmEventComuneDto>>();
        }


        public async Task<PreventiviObjectDto> CreatePreventiviObjectFromCrmTicketAsync(PreventiviObjectAssignementDto dto,double saldo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PreventiviObjectAssignementDto, PreventiviObject>(MemberList.Destination);
            });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<PreventiviObject>(dto);

            entity.ObjectNumber = await GetObjectNumberAsync();
            entity.DataInserimento = DateTime.Now;
            entity.FinancialLock = saldo > 0 ? true : false;
            entity.StatusId = 1;

            var reponse = await gaPreventiviObjectsRepo.CreateAsync(entity);

            #region Inspection
            var inspection = new PreventiviObjectInspection();
            inspection.Id = 0;
            inspection.Disabled = false;
            inspection.StatusId = 1;
            inspection.AssigneeId = dto.InspectionAssigneeId;
            inspection.ModeId = dto.Inspection;
            inspection.ObjectId = entity.Id;
            inspection.NoteInspection = dto.InspectionNotes;
            await gaPreventiviObjectInspectionsRepo.CreateAsync(inspection);
            #endregion

            #region Attachments
            if (dto.Attachments.GetValueOrDefault()==true)
            {
                var listAttachments = await gaCrmTicketAttachmentsRepo.GetAsync(new PageRequest() { Filter = $"CrmTicketId eq {dto.CrmTicketId}" });
                if (listAttachments.Count > 0)
                {
                    foreach (var attach in listAttachments.Items)
                    {
                        var attachment = new PreventiviObjectAttachment();
                        attachment.Id = 0;
                        attachment.Disabled = false;
                        attachment.Descrizione = attach.Descrizione;
                        attachment.ObjectId = entity.Id;
                        attachment.FileId = attach.FileId;
                        attachment.FileFolder = attach.FileFolder;
                        attachment.FileName = attach.FileName;
                        attachment.FileSize = attach.FileSize;
                        attachment.FileType = attach.FileType;

                        await gaPreventiviObjectAttachmentsRepo.CreateAsync(attachment);
                    }
                }
            
            }
            #endregion


            return entity.ToModel<PreventiviObjectDto>();

        }
        #endregion

        #region Objects
        public async Task<PageResponse<PreventiviObjectDto>> GetPreventiviObjectsAsync(PageRequest request )
        {
            var entities = await gaPreventiviObjectsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectDto> GetPreventiviObjectByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectsRepo.GetAsync(id,new GetRequest() { Expand="Status,Type"});
            var dto = entity.ToModel<PreventiviObjectDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectAsync(PreventiviObjectDto dto)
        {
            var entity = dto.ToEntity<PreventiviObject>();
            var reponse = await gaPreventiviObjectsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectAsync(long id,PreventiviObjectDto dto)
        {
            var entity = dto.ToEntity<PreventiviObject>();
            var response = await gaPreventiviObjectsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectAsync(long id)
        {
            await gaPreventiviObjectsRepo.DeleteAsync(id);

            return true;
        }

        #region Functions
        public async Task<bool> UpdatePreventiviObjectAssigneeAsync(long id, PreventiviObjectDto dto)
        {
            var entity = await  gaPreventiviObjectsRepo.GetAsync(id, new GetRequest());
            entity.AssigneeId= dto.AssigneeId;
            entity.StatusId = dto.StatusId;
            var response = await gaPreventiviObjectsRepo.UpdateAsync(entity);
            return true;

        }

        public async Task<bool> UpdatePreventiviObjectContactDetailsAsync(long id, PreventiviObjectDto dto)
        {
            var entity = await gaPreventiviObjectsRepo.GetAsync(id, new GetRequest());
            entity.Telefono = dto.Telefono;
            entity.Cellulare = dto.Cellulare;
            entity.Email = dto.Email;
            entity.EmailPec = dto.EmailPec;
            entity.IndirizzoFattura = dto.IndirizzoFattura;
            entity.IndirizzoSede = dto.IndirizzoSede;
            entity.ClienteCodSdi=dto.ClienteCodSdi;
            entity.Intestatario = dto.Intestatario;
            entity.IntestatarioCfPiva = dto.IntestatarioCfPiva;
            entity.IntestatarioPiva = dto.IntestatarioPiva;
            entity.IntestatarioComune = dto.IntestatarioComune;
            entity.IntestatarioIndirizzo = dto.IntestatarioIndirizzo;
            entity.IntestatarioIndirizzoOperativo = dto.IntestatarioIndirizzoOperativo;

            var response = await gaPreventiviObjectsRepo.UpdateAsync(entity);
            return true;

        }

        public async Task<bool> UpdatePreventiviObjectOperativeDetailsAsync(long id, PreventiviObjectDto dto)
        {
            var entity = await gaPreventiviObjectsRepo.GetAsync(id, new GetRequest());
            entity.NoteOperative = dto.NoteOperative;
            entity.CausalePag770s = dto.CausalePag770s;
            var response = await gaPreventiviObjectsRepo.UpdateAsync(entity);
            return true;

        }

        public async Task<bool> UpdatePreventiviObjectTypeDetailsAsync(long id, PreventiviObjectDto dto)
        {
            var entity = await gaPreventiviObjectsRepo.GetAsync(id, new GetRequest());
            entity.TypeId = dto.TypeId;
            entity.TypeDesc = dto.TypeDesc;
            var response = await gaPreventiviObjectsRepo.UpdateAsync(entity);
            return true;

        }
        #endregion

        #endregion

        #region ObjectAttachments
        public async Task<PageResponse<PreventiviObjectAttachmentDto>> GetPreventiviObjectAttachmentsAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectAttachmentsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectAttachmentDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectAttachmentDto> GetPreventiviObjectAttachmentByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectAttachmentsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectAttachmentDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectAttachmentAsync(PreventiviObjectAttachmentDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectAttachment>();
            var reponse = await gaPreventiviObjectAttachmentsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectAttachmentAsync(long id, PreventiviObjectAttachmentDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectAttachment>();
            var response = await gaPreventiviObjectAttachmentsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectAttachmentAsync(long id)
        {
            await gaPreventiviObjectAttachmentsRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectStatuses
        public async Task<PageResponse<PreventiviObjectStatusDto>> GetPreventiviObjectStatusesAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectStatusesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectStatusDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectStatusDto> GetPreventiviObjectStatusByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectStatusesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectStatusDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectStatusAsync(PreventiviObjectStatusDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectStatus>();
            var reponse = await gaPreventiviObjectStatusesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectStatusAsync(long id,PreventiviObjectStatusDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectStatus>();
            var response = await gaPreventiviObjectStatusesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectStatusAsync(long id)
        {
            await gaPreventiviObjectStatusesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectTypes
        public async Task<PageResponse<PreventiviObjectTypeDto>> GetPreventiviObjectTypesAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectTypesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectTypeDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectTypeDto> GetPreventiviObjectTypeByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectTypesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectTypeDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectTypeAsync(PreventiviObjectTypeDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectType>();
            var reponse = await gaPreventiviObjectTypesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectTypeAsync(long id,PreventiviObjectTypeDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectType>();
            var response = await gaPreventiviObjectTypesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectTypeAsync(long id)
        {
            await gaPreventiviObjectTypesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectInspectionModes
        public async Task<PageResponse<PreventiviObjectInspectionModeDto>> GetPreventiviObjectInspectionModesAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectInspectionModesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectInspectionModeDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectInspectionModeDto> GetPreventiviObjectInspectionModeByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectInspectionModesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectInspectionModeDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectInspectionModeAsync(PreventiviObjectInspectionModeDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectInspectionMode>();
            var reponse = await gaPreventiviObjectInspectionModesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectInspectionModeAsync(long id, PreventiviObjectInspectionModeDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectInspectionMode>();
            var response = await gaPreventiviObjectInspectionModesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectInspectionModeAsync(long id)
        {
            await gaPreventiviObjectInspectionModesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectInspections
        public async Task<PageResponse<PreventiviObjectInspectionDto>> GetPreventiviObjectInspectionsAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectInspectionsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectInspectionDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectInspectionDto> GetPreventiviObjectInspectionByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectInspectionsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectInspectionDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectInspectionAsync(PreventiviObjectInspectionDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectInspection>();
            var reponse = await gaPreventiviObjectInspectionsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectInspectionAsync(long id, PreventiviObjectInspectionDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectInspection>();
            var response = await gaPreventiviObjectInspectionsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectInspectionAsync(long id)
        {
            await gaPreventiviObjectInspectionsRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectInspectionAttachments
        public async Task<PageResponse<PreventiviObjectInspectionAttachmentDto>> GetPreventiviObjectInspectionAttachmentsAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectInspectionAttachmentsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectInspectionAttachmentDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectInspectionAttachmentDto> GetPreventiviObjectInspectionAttachmentByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectInspectionAttachmentsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectInspectionAttachmentDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectInspectionAttachmentAsync(PreventiviObjectInspectionAttachmentDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectInspectionAttachment>();
            var reponse = await gaPreventiviObjectInspectionAttachmentsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectInspectionAttachmentAsync(long id, PreventiviObjectInspectionAttachmentDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectInspectionAttachment>();
            var response = await gaPreventiviObjectInspectionAttachmentsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectInspectionAttachmentAsync(long id)
        {
            await gaPreventiviObjectInspectionAttachmentsRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectInspectionImages
        public async Task<PageResponse<PreventiviObjectInspectionImageDto>> GetPreventiviObjectInspectionImagesAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectInspectionImagesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectInspectionImageDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectInspectionImageDto> GetPreventiviObjectInspectionImageByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectInspectionImagesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectInspectionImageDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectInspectionImageAsync(PreventiviObjectInspectionImageDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectInspectionImage>();
            var reponse = await gaPreventiviObjectInspectionImagesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectInspectionImageAsync(long id, PreventiviObjectInspectionImageDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectInspectionImage>();
            var response = await gaPreventiviObjectInspectionImagesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectInspectionImageAsync(long id)
        {
            await gaPreventiviObjectInspectionImagesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region Actions
        public async Task<PageResponse<PreventiviActionDto>> GetPreventiviActionsAsync(PageRequest request)
        {
            var entities = await gaPreventiviActionsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviActionDto>>();
            return dtos;
        }

        public async Task<PreventiviActionDto> GetPreventiviActionByIdAsync(long id)
        {
            var entity = await gaPreventiviActionsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviActionDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviActionAsync(PreventiviActionDto dto)
        {
            var entity = dto.ToEntity<PreventiviAction>();
            var reponse = await gaPreventiviActionsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviActionAsync(long id, PreventiviActionDto dto)
        {
            var entity = dto.ToEntity<PreventiviAction>();
            var response = await gaPreventiviActionsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviActionAsync(long id)
        {
            await gaPreventiviActionsRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectSections
        public async Task<PageResponse<PreventiviObjectSectionDto>> GetPreventiviObjectSectionsAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectSectionsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectSectionDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectSectionDto> GetPreventiviObjectSectionByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectSectionsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectSectionDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectSectionAsync(PreventiviObjectSectionDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectSection>();
            var reponse = await gaPreventiviObjectSectionsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectSectionAsync(long id, PreventiviObjectSectionDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectSection>();
            var response = await gaPreventiviObjectSectionsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectSectionAsync(long id)
        {
            await gaPreventiviObjectSectionsRepo.DeleteAsync(id);

            return true;
        }

        #region Functions
        public async Task<bool> ChangeOrderPreventiviObjectSectionAsync(List<PreventiviObjectSectionDto> model)
        {
            if (model.Count > 0)
            {
                int index = 0;
                foreach (var item in model)
                {
                    var entity = await gaPreventiviObjectSectionsRepo.GetAsync(item.Id, new GetRequest());
                    entity.Order = index;
                    await gaPreventiviObjectSectionsRepo.UpdateAsync(entity);
                    index++;
                }

                return true;

            }
            else
            {
                return true;
            }


        }
        #endregion

        #endregion

        #region ObjectServiceTypes
        public async Task<PageResponse<PreventiviObjectServiceTypeDto>> GetPreventiviObjectServiceTypesAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectServiceTypesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectServiceTypeDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectServiceTypeDto> GetPreventiviObjectServiceTypeByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectServiceTypesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectServiceTypeDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectServiceTypeAsync(PreventiviObjectServiceTypeDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectServiceType>();
            var reponse = await gaPreventiviObjectServiceTypesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectServiceTypeAsync(long id, PreventiviObjectServiceTypeDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectServiceType>();
            var response = await gaPreventiviObjectServiceTypesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectServiceTypeAsync(long id)
        {
            await gaPreventiviObjectServiceTypesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectServiceTypeDetails
        public async Task<PageResponse<PreventiviObjectServiceTypeDetailDto>> GetPreventiviObjectServiceTypeDetailsAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectServiceTypeDetailsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectServiceTypeDetailDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectServiceTypeDetailDto> GetPreventiviObjectServiceTypeDetailByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectServiceTypeDetailsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectServiceTypeDetailDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectServiceTypeDetailAsync(PreventiviObjectServiceTypeDetailDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectServiceTypeDetail>();
            var reponse = await gaPreventiviObjectServiceTypeDetailsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectServiceTypeDetailAsync(long id, PreventiviObjectServiceTypeDetailDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectServiceTypeDetail>();
            var response = await gaPreventiviObjectServiceTypeDetailsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectServiceTypeDetailAsync(long id)
        {
            await gaPreventiviObjectServiceTypeDetailsRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectServices
        public async Task<PageResponse<PreventiviObjectServiceDto>> GetPreventiviObjectServicesAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectServicesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectServiceDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectServiceDto> GetPreventiviObjectServiceByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectServicesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectServiceDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectServiceAsync(PreventiviObjectServiceDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectService>();
            var reponse = await gaPreventiviObjectServicesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectServiceAsync(long id, PreventiviObjectServiceDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectService>();
            var response = await gaPreventiviObjectServicesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectServiceAsync(long id)
        {
            await gaPreventiviObjectServicesRepo.DeleteAsync(id);

            return true;
        }

        #region Functions
        public async Task<bool> ChangeOrderPreventiviObjectServiceAsync(List<PreventiviObjectServiceDto> model)
        {
            if (model.Count > 0)
            {
                int index = 0;
                foreach (var item in model)
                {
                    var entity = await gaPreventiviObjectServicesRepo.GetAsync(item.Id,new GetRequest());
                    entity.Order = index;
                    await gaPreventiviObjectServicesRepo.UpdateAsync(entity);
                    index++;
                }

                return true;

            }
            else
            {
                return true;
            }


        }
        #endregion

        #endregion

        #region Garbages
        public async Task<PageResponse<PreventiviGarbageDto>> GetPreventiviGarbagesAsync(PageRequest request)
        {
            var entities = await gaPreventiviGarbagesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviGarbageDto>>();
            return dtos;
        }

        public async Task<PreventiviGarbageDto> GetPreventiviGarbageByIdAsync(long id)
        {
            var entity = await gaPreventiviGarbagesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviGarbageDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviGarbageAsync(PreventiviGarbageDto dto)
        {
            var entity = dto.ToEntity<PreventiviGarbage>();
            var reponse = await gaPreventiviGarbagesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviGarbageAsync(long id, PreventiviGarbageDto dto)
        {
            var entity = dto.ToEntity<PreventiviGarbage>();
            var response = await gaPreventiviGarbagesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviGarbageAsync(long id)
        {
            await gaPreventiviGarbagesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ServiceNoteTemplates
        public async Task<PageResponse<PreventiviServiceNoteTemplateDto>> GetPreventiviServiceNoteTemplatesAsync(PageRequest request)
        {
            var entities = await gaPreventiviServiceNoteTemplatesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviServiceNoteTemplateDto>>();
            return dtos;
        }

        public async Task<PreventiviServiceNoteTemplateDto> GetPreventiviServiceNoteTemplateByIdAsync(long id)
        {
            var entity = await gaPreventiviServiceNoteTemplatesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviServiceNoteTemplateDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviServiceNoteTemplateAsync(PreventiviServiceNoteTemplateDto dto)
        {
            var entity = dto.ToEntity<PreventiviServiceNoteTemplate>();
            var reponse = await gaPreventiviServiceNoteTemplatesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviServiceNoteTemplateAsync(long id, PreventiviServiceNoteTemplateDto dto)
        {
            var entity = dto.ToEntity<PreventiviServiceNoteTemplate>();
            var response = await gaPreventiviServiceNoteTemplatesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviServiceNoteTemplateAsync(long id)
        {
            await gaPreventiviServiceNoteTemplatesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ConditionTemplates
        public async Task<PageResponse<PreventiviConditionTemplateDto>> GetPreventiviConditionTemplatesAsync(PageRequest request)
        {
            var entities = await gaPreventiviConditionTemplatesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviConditionTemplateDto>>();
            return dtos;
        }

        public async Task<PreventiviConditionTemplateDto> GetPreventiviConditionTemplateByIdAsync(long id)
        {
            var entity = await gaPreventiviConditionTemplatesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviConditionTemplateDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviConditionTemplateAsync(PreventiviConditionTemplateDto dto)
        {
            var entity = dto.ToEntity<PreventiviConditionTemplate>();
            var reponse = await gaPreventiviConditionTemplatesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviConditionTemplateAsync(long id, PreventiviConditionTemplateDto dto)
        {
            var entity = dto.ToEntity<PreventiviConditionTemplate>();
            var response = await gaPreventiviConditionTemplatesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviConditionTemplateAsync(long id)
        {
            await gaPreventiviConditionTemplatesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectPeriods
        public async Task<PageResponse<PreventiviObjectPeriodDto>> GetPreventiviObjectPeriodsAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectPeriodsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectPeriodDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectPeriodDto> GetPreventiviObjectPeriodByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectPeriodsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectPeriodDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectPeriodAsync(PreventiviObjectPeriodDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectPeriod>();
            var reponse = await gaPreventiviObjectPeriodsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectPeriodAsync(long id, PreventiviObjectPeriodDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectPeriod>();
            var response = await gaPreventiviObjectPeriodsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectPeriodAsync(long id)
        {
            await gaPreventiviObjectPeriodsRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectPayouts
        public async Task<PageResponse<PreventiviObjectPayoutDto>> GetPreventiviObjectPayoutsAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectPayoutsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectPayoutDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectPayoutDto> GetPreventiviObjectPayoutByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectPayoutsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectPayoutDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectPayoutAsync(PreventiviObjectPayoutDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectPayout>();
            var reponse = await gaPreventiviObjectPayoutsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectPayoutAsync(long id, PreventiviObjectPayoutDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectPayout>();
            var response = await gaPreventiviObjectPayoutsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectPayoutAsync(long id)
        {
            await gaPreventiviObjectPayoutsRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region Producers
        public async Task<PageResponse<PreventiviProducerDto>> GetPreventiviProducersAsync(PageRequest request)
        {
            var entities = await gaPreventiviProducersRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviProducerDto>>();
            return dtos;
        }

        public async Task<PreventiviProducerDto> GetPreventiviProducerByIdAsync(long id)
        {
            var entity = await gaPreventiviProducersRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviProducerDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviProducerAsync(PreventiviProducerDto dto)
        {
            var entity = dto.ToEntity<PreventiviProducer>();
            var reponse = await gaPreventiviProducersRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviProducerAsync(long id, PreventiviProducerDto dto)
        {
            var entity = dto.ToEntity<PreventiviProducer>();
            var response = await gaPreventiviProducersRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviProducerAsync(long id)
        {
            await gaPreventiviProducersRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region Destinations
        public async Task<PageResponse<PreventiviDestinationDto>> GetPreventiviDestinationsAsync(PageRequest request)
        {
            var entities = await gaPreventiviDestinationsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviDestinationDto>>();
            return dtos;
        }

        public async Task<PreventiviDestinationDto> GetPreventiviDestinationByIdAsync(long id)
        {
            var entity = await gaPreventiviDestinationsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviDestinationDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviDestinationAsync(PreventiviDestinationDto dto)
        {
            var entity = dto.ToEntity<PreventiviDestination>();
            var reponse = await gaPreventiviDestinationsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviDestinationAsync(long id, PreventiviDestinationDto dto)
        {
            var entity = dto.ToEntity<PreventiviDestination>();
            var response = await gaPreventiviDestinationsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviDestinationAsync(long id)
        {
            await gaPreventiviDestinationsRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region ObjectConditions
        public async Task<PageResponse<PreventiviObjectConditionDto>> GetPreventiviObjectConditionsAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectConditionsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<PreventiviObjectConditionDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectConditionDto> GetPreventiviObjectConditionByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectConditionsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectConditionDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectConditionAsync(PreventiviObjectConditionDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectCondition>();
            var reponse = await gaPreventiviObjectConditionsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectConditionAsync(long id, PreventiviObjectConditionDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectCondition>();
            var response = await gaPreventiviObjectConditionsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectConditionAsync(long id)
        {
            await gaPreventiviObjectConditionsRepo.DeleteAsync(id);

            return true;
        }

        #region Functions
        public async Task<bool> ChangeOrderPreventiviObjectConditionAsync(List<PreventiviObjectConditionDto> model)
        {
            if (model.Count > 0)
            {
                int index = 0;
                foreach (var item in model)
                {
                    var entity = await gaPreventiviObjectConditionsRepo.GetAsync(item.Id, new GetRequest());
                    entity.Order = index;
                    await gaPreventiviObjectConditionsRepo.UpdateAsync(entity);
                    index++;
                }

                return true;

            }
            else
            {
                return true;
            }


        }
        #endregion

        #endregion

        #region Financial
        public async Task<double> CheckPreventiviFinancialPositionAsync(string query)
        {
            var entities = await queryManager.ExecQueryAsync(query);
            var saldo = entities
                .Where(x=> ((IDictionary<string, object>)x).ContainsKey("DatSca1") &&
                (((IDictionary<string, object>)x)["DatSca1"].ToString() == "" || (DateTime?)((IDictionary<string, object>)x)["DatSca1"] < DateTime.Now))
                .Sum(x => (double)((IDictionary<string, object>)x)["Saldo"]);
            return saldo;
        }

        public async Task<bool> RequestPreventiviSubjectFinancialUnlockAsync(PreventiviSubjectFinancialDto model)
        {
            var entity = await gaPreventiviObjectsRepo.GetAsync(model.Id,new GetRequest());
            entity.FinancialUnlockRequestDate = DateTime.Now;
            entity.FinancialUnlockRequestUserId = model.CreatorId;
            entity.FinancialUnlockRequestUserName = model.CreatorName;

            var response = await gaPreventiviObjectsRepo.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> ExecPreventiviSubjectFinancialUnlockAsync(PreventiviSubjectFinancialDto model)
        {
            var entity = await gaPreventiviObjectsRepo.GetAsync(model.Id, new GetRequest());
            entity.FinancialUnlockDate = DateTime.Now;
            entity.FinancialUnlockUserId = model.CreatorId;
            entity.FinancialUnlockUserName = model.CreatorName;
            entity.FinancialLockDetail = model.Note;
            entity.FinancialLock = false;
            entity.FinancialForcedLock = false;

            var response = await gaPreventiviObjectsRepo.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> ExecPreventiviSubjectFinancialLockAsync(PreventiviSubjectFinancialDto model)
        {
            var entity = await gaPreventiviObjectsRepo.GetAsync(model.Id, new GetRequest());
            entity.FinancialUnlockDate = DateTime.Now;
            entity.FinancialUnlockUserId = model.CreatorId;
            entity.FinancialUnlockUserName = model.CreatorName;
            entity.FinancialLockDetail = model.Note;
            entity.FinancialLock = true;
            entity.FinancialForcedLock = true;

            var response = await gaPreventiviObjectsRepo.UpdateAsync(entity);
            return true;
        }
        #endregion

        #region ObjectHistory
        public async Task<PageResponse<PreventiviObjectHistoryDto>> GetPreventiviObjectHistoriesAsync(PageRequest request)
        {
            var entities = await gaPreventiviObjectHistoriesRepo.GetAsync(request);
            var dtos= entities.ToModel<PageResponse<PreventiviObjectHistoryDto>>();
            return dtos;
        }

        public async Task<PreventiviObjectHistoryDto> GetPreventiviObjectHistoryByIdAsync(long id)
        {
            var entity = await gaPreventiviObjectHistoriesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<PreventiviObjectHistoryDto>();
            return dto;
        }

        public async Task<long> CreatePreventiviObjectHistoryAsync(PreventiviObjectHistoryDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectHistory>();
            var reponse = await gaPreventiviObjectHistoriesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdatePreventiviObjectHistoryAsync(long id, PreventiviObjectHistoryDto dto)
        {
            var entity = dto.ToEntity<PreventiviObjectHistory>();
            var response = await gaPreventiviObjectHistoriesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeletePreventiviObjectHistoryAsync(long id)
        {
            await gaPreventiviObjectHistoriesRepo.DeleteAsync(id);

            return true;
        }
        #endregion

        #region Ismart Documenti
        public async Task<PageResponse<ViewGaPreventiviIsmartDocumenti>> GetViewPreventiviIsmartDocumentiAsync(PageRequest request)
        {
            var view = await viewGaPreventiviIsmartDocumentiRepo.GetAsync(request);
            return view;
        }

        #endregion

        #region Functions
        private async Task<string> GetObjectNumberAsync()
        { 
            var now=DateTime.Now;
            var objects = await gaPreventiviObjectsRepo.GetAsync(new PageRequest() { Filter = $"contains(ObjectNumber,'{now.Year}') " });
            if (objects == null || objects.Count==0)
            {
                return $"1/{now.Year}";
            }
            else
            {
                var listNumbers = from x in objects.Items
                                select int.Parse(x.ObjectNumber.Split("/")[0]);
                              
                return $"{listNumbers.Max()+1}/{now.Year}";
            }

        }
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
        #endregion
    }
}
