using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Consorzio;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using sh = GaCloudServer.BusinnessLogic.Helpers.StringHelper;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class ConsorzioService : IConsorzioService
    {
        protected readonly IGenericRepository<ConsorzioCer> consorzioCersRepo;
        protected readonly IGenericRepository<ConsorzioSmaltimento> consorzioSmaltimentiRepo;
        protected readonly IGenericRepository<ConsorzioComune> consorzioComuniRepo;
        protected readonly IGenericRepository<ConsorzioProduttore> consorzioProduttoriRepo;
        protected readonly IGenericRepository<ConsorzioDestinatario> consorzioDestinatariRepo;
        protected readonly IGenericRepository<ConsorzioTrasportatore> consorzioTrasportatoriRepo;
        protected readonly IGenericRepository<ConsorzioRegistrazione> consorzioRegistrazioniRepo;
        protected readonly IGenericRepository<ConsorzioRegistrazioneAllegato> consorzioRegistrazioniAllegatiRepo;
        protected readonly IGenericRepository<ConsorzioOperazione> consorzioOperazioniRepo;
        protected readonly IGenericRepository<ConsorzioPeriodo> consorzioPeriodiRepo;
        protected readonly IGenericRepository<ConsorzioImportTask> consorzioImportsTasksRepo;

        protected readonly IGenericRepository<ViewConsorzioCers> viewConsorzioCersRepo;
        protected readonly IGenericRepository<ViewConsorzioProduttori> viewConsorzioProduttoriRepo;
        protected readonly IGenericRepository<ViewConsorzioDestinatari> viewConsorzioDestinatariRepo;
        protected readonly IGenericRepository<ViewConsorzioTrasportatori> viewConsorzioTrasportatoriRepo;
        protected readonly IGenericRepository<ViewConsorzioRegistrazioni> viewConsorzioRegistrazioniRepo;
        protected readonly IGenericRepository<ViewConsorzioComuni> viewConsorzioComuniRepo;
        protected readonly IGenericRepository<ViewConsorzioImportsTasks> viewConsorzioImportsTasksRepo;

        protected readonly IUnitOfWork unitOfWork;

        public ConsorzioService(

            IGenericRepository<ConsorzioCer> consorzioCersRepo,
            IGenericRepository<ConsorzioSmaltimento> consorzioSmaltimentiRepo,
            IGenericRepository<ConsorzioComune> consorzioComuniRepo,
            IGenericRepository<ConsorzioProduttore> consorzioProduttoriRepo,
            IGenericRepository<ConsorzioDestinatario> consorzioDestinatariRepo,
            IGenericRepository<ConsorzioTrasportatore> consorzioTrasportatoriRepo,
            IGenericRepository<ConsorzioRegistrazione> consorzioRegistrazioniRepo,
            IGenericRepository<ConsorzioRegistrazioneAllegato> consorzioRegistrazioniAllegatiRepo,
            IGenericRepository<ConsorzioOperazione> consorzioOperazioniRepo,
            IGenericRepository<ConsorzioPeriodo> consorzioPeriodiRepo,
            IGenericRepository<ConsorzioImportTask> consorzioImportsTasksRepo,

            IGenericRepository<ViewConsorzioCers> viewConsorzioCersRepo,
            IGenericRepository<ViewConsorzioProduttori> viewConsorzioProduttoriRepo,
            IGenericRepository<ViewConsorzioDestinatari> viewConsorzioDestinatariRepo,
            IGenericRepository<ViewConsorzioTrasportatori> viewConsorzioTrasportatoriRepo,
            IGenericRepository<ViewConsorzioRegistrazioni> viewConsorzioRegistrazioniRepo,
            IGenericRepository<ViewConsorzioComuni> viewConsorzioComuniRepo,
            IGenericRepository<ViewConsorzioImportsTasks> viewConsorzioImportsTasksRepo,

            IUnitOfWork unitOfWork)
        {
            this.consorzioCersRepo = consorzioCersRepo;
            this.consorzioSmaltimentiRepo = consorzioSmaltimentiRepo;
            this.consorzioComuniRepo = consorzioComuniRepo;
            this.consorzioProduttoriRepo = consorzioProduttoriRepo;
            this.consorzioDestinatariRepo = consorzioDestinatariRepo;
            this.consorzioTrasportatoriRepo = consorzioTrasportatoriRepo;
            this.consorzioRegistrazioniRepo = consorzioRegistrazioniRepo;
            this.consorzioRegistrazioniAllegatiRepo = consorzioRegistrazioniAllegatiRepo;
            this.consorzioOperazioniRepo = consorzioOperazioniRepo;
            this.consorzioPeriodiRepo = consorzioPeriodiRepo;
            this.consorzioImportsTasksRepo = consorzioImportsTasksRepo;

            this.viewConsorzioCersRepo = viewConsorzioCersRepo;
            this.viewConsorzioProduttoriRepo = viewConsorzioProduttoriRepo;
            this.viewConsorzioDestinatariRepo = viewConsorzioDestinatariRepo;
            this.viewConsorzioTrasportatoriRepo = viewConsorzioTrasportatoriRepo;
            this.viewConsorzioComuniRepo = viewConsorzioComuniRepo;
            this.viewConsorzioRegistrazioniRepo = viewConsorzioRegistrazioniRepo;
            this.viewConsorzioImportsTasksRepo = viewConsorzioImportsTasksRepo;


            this.unitOfWork = unitOfWork;

        }

        #region ConsorzioCers
        public async Task<ConsorzioCersDto> GetConsorzioCersAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioCersRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioCersDto, PagedList<ConsorzioCer>>();
            return dtos;
        }

        public async Task<ConsorzioCerDto> GetConsorzioCerByIdAsync(long id)
        {
            var entity = await consorzioCersRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioCerDto, ConsorzioCer>();
            return dto;
        }

        public async Task<long> AddConsorzioCerAsync(ConsorzioCerDto dto)
        {
            var entity = dto.ToEntity<ConsorzioCer, ConsorzioCerDto>();
            await consorzioCersRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioCerAsync(ConsorzioCerDto dto)
        {
            var entity = dto.ToEntity<ConsorzioCer, ConsorzioCerDto>();
            consorzioCersRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioCerAsync(long id)
        {
            var entity = await consorzioCersRepo.GetByIdAsync(id);
            consorzioCersRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioCerAsync(long id, string codice, string codiceRaggruppamento)
        {
            var entity = await consorzioCersRepo.GetWithFilterAsync(x => x.Codice == codice && x.CodiceRaggruppamento == codiceRaggruppamento && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioCerAsync(long id)
        {
            var entity = await consorzioCersRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        public async Task<bool> DuplicateConsorzioCerAsync(long id)
        {
            try
            {
                var original = consorzioCersRepo.GetByIdAsNoTraking(x => x.Id == id);
                var entity = original;
                entity.Id = 0;
                entity.CodiceRaggruppamento = "Cer Duplicato";


                await consorzioCersRepo.AddAsync(entity);
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

        #region Views
        public async Task<PagedList<ViewConsorzioCers>> GetViewConsorzioCersAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioCersRepo.GetAllAsync(1, 0) : await viewConsorzioCersRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioSmaltimenti
        public async Task<ConsorzioSmaltimentiDto> GetConsorzioSmaltimentiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioSmaltimentiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioSmaltimentiDto, PagedList<ConsorzioSmaltimento>>();
            return dtos;
        }

        public async Task<ConsorzioSmaltimentoDto> GetConsorzioSmaltimentoByIdAsync(long id)
        {
            var entity = await consorzioSmaltimentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioSmaltimentoDto, ConsorzioSmaltimento>();
            return dto;
        }

        public async Task<long> AddConsorzioSmaltimentoAsync(ConsorzioSmaltimentoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioSmaltimento, ConsorzioSmaltimentoDto>();
            await consorzioSmaltimentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioSmaltimentoAsync(ConsorzioSmaltimentoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioSmaltimento, ConsorzioSmaltimentoDto>();
            consorzioSmaltimentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioSmaltimentoAsync(long id)
        {
            var entity = await consorzioSmaltimentiRepo.GetByIdAsync(id);
            consorzioSmaltimentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioSmaltimentoAsync(long id, string descrizione)
        {
            var entity = await consorzioSmaltimentiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioSmaltimentoAsync(long id)
        {
            var entity = await consorzioSmaltimentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioSmaltimentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioSmaltimentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ConsorzioComuni
        public async Task<ConsorzioComuniDto> GetConsorzioComuniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioComuniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioComuniDto, PagedList<ConsorzioComune>>();
            return dtos;
        }

        public async Task<ConsorzioComuneDto> GetConsorzioComuneByIdAsync(long id)
        {
            var entity = await consorzioComuniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioComuneDto, ConsorzioComune>();
            return dto;
        }

        public async Task<long> AddConsorzioComuneAsync(ConsorzioComuneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioComune, ConsorzioComuneDto>();
            await consorzioComuniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioComuneAsync(ConsorzioComuneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioComune, ConsorzioComuneDto>();
            consorzioComuniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioComuneAsync(long id)
        {
            var entity = await consorzioComuniRepo.GetByIdAsync(id);
            consorzioComuniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioComuneAsync(long id, string descrizione)
        {
            var entity = await consorzioComuniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioComuneAsync(long id)
        {
            var entity = await consorzioComuniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioComuni>> GetViewConsorzioComuniAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioComuniRepo.GetAllAsync(1, 0) : await viewConsorzioComuniRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioProduttori
        public async Task<ConsorzioProduttoriDto> GetConsorzioProduttoriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioProduttoriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioProduttoriDto, PagedList<ConsorzioProduttore>>();
            return dtos;
        }

        public async Task<ConsorzioProduttoreDto> GetConsorzioProduttoreByIdAsync(long id)
        {
            var entity = await consorzioProduttoriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioProduttoreDto, ConsorzioProduttore>();
            return dto;
        }

        public async Task<long> AddConsorzioProduttoreAsync(ConsorzioProduttoreDto dto)
        {
            var entity = dto.ToEntity<ConsorzioProduttore, ConsorzioProduttoreDto>();
            await consorzioProduttoriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioProduttoreAsync(ConsorzioProduttoreDto dto)
        {
            var entity = dto.ToEntity<ConsorzioProduttore, ConsorzioProduttoreDto>();
            consorzioProduttoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioProduttoreAsync(long id)
        {
            var entity = await consorzioProduttoriRepo.GetByIdAsync(id);
            consorzioProduttoriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioProduttoreAsync(long id, string cfPiva, string indirizzo)
        {
            var entity = await consorzioProduttoriRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva && x.Indirizzo == indirizzo && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<PercentValidateDto> ValidatePercentConsorzioProduttoreAsync(long id, string cfPiva, string indirizzo,string ragSo,long comuneId)
        {
            var entity = await consorzioProduttoriRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva && x.Indirizzo == indirizzo && x.ConsorzioComuneId==comuneId && x.Descrizione==ragSo && x.Id != id && x.Disabled==false);

            if (entity.Data.Count > 0)
            {
                return new PercentValidateDto() { foundId=entity.Data.FirstOrDefault().Id,percent=1,obj=entity.Data.FirstOrDefault()};
            }
            else
            {
                var entityCf = await consorzioProduttoriRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva && x.ConsorzioComuneId==comuneId && x.Disabled==false);
                if (entityCf.Data.Count > 0)
                {
                    List<long> foundId = new List<long>();
                    List<long> foundCompleteId = new List<long>();
                    List<(long, double)> listRagsoPrc= new List<(long,double)>();
                    List<(long, double)> listIndPrc= new List<(long,double)>();

                    double ragSoPrc = 0;
                    double indPrc = 0;

                    foreach (var itm in entityCf.Data)
                    {
                        ragSoPrc = sh.CalculateSimilarity(itm.Descrizione, ragSo);
                        if (ragSoPrc > 0.8)
                        {
                            listRagsoPrc.Add((itm.Id, ragSoPrc));

                            foundId.Add(itm.Id);
                        }
                    }

                    if (foundId.Count > 0)
                    {
                        foreach (var itm in entityCf.Data.Where(x => foundId.Contains(x.Id)))
                        {

                            indPrc = sh.CalculateSimilarity(itm.Indirizzo, indirizzo);

                            listIndPrc.Add((itm.Id, indPrc));
                            foundCompleteId.Add(itm.Id);
                            
                        }

                        var resultPrc = listRagsoPrc.Concat(listIndPrc)
                            .GroupBy(item => item.Item1)
                            .Select(group => (group.Key, group.Sum(item => item.Item2)/2))
                            .ToList();
                        

                        if (foundCompleteId.Count > 0)
                        {
                            return new PercentValidateDto() { foundId = foundCompleteId.FirstOrDefault(), percent = resultPrc.OrderByDescending(x=>x.Item2).Select(x=>x.Item2).FirstOrDefault(), obj = entityCf.Data.Where(x=>x.Id==foundCompleteId.FirstOrDefault()).FirstOrDefault() };
                        }
                        else
                        {
                            return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                        }
                    }
                    else
                    {
                        return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                    }


                }
                else
                {
                    return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                }
                
            }
        }

        public async Task<bool> ChangeStatusConsorzioProduttoreAsync(long id)
        {
            var entity = await consorzioProduttoriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioProduttoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioProduttoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioProduttori>> GetViewConsorzioProduttoriAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioProduttoriRepo.GetAllAsync(1, 0) : await viewConsorzioProduttoriRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioDestinatari
        public async Task<ConsorzioDestinatariDto> GetConsorzioDestinatariAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioDestinatariRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioDestinatariDto, PagedList<ConsorzioDestinatario>>();
            return dtos;
        }

        public async Task<ConsorzioDestinatarioDto> GetConsorzioDestinatarioByIdAsync(long id)
        {
            var entity = await consorzioDestinatariRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioDestinatarioDto, ConsorzioDestinatario>();
            return dto;
        }

        public async Task<long> AddConsorzioDestinatarioAsync(ConsorzioDestinatarioDto dto)
        {
            var entity = dto.ToEntity<ConsorzioDestinatario, ConsorzioDestinatarioDto>();
            await consorzioDestinatariRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioDestinatarioAsync(ConsorzioDestinatarioDto dto)
        {
            var entity = dto.ToEntity<ConsorzioDestinatario, ConsorzioDestinatarioDto>();
            consorzioDestinatariRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioDestinatarioAsync(long id)
        {
            var entity = await consorzioDestinatariRepo.GetByIdAsync(id);
            consorzioDestinatariRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioDestinatarioAsync(long id, string cfPiva, string indirizzo)
        {
            var entity = await consorzioDestinatariRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva  && x.Indirizzo == indirizzo && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<PercentValidateDto> ValidatePercentConsorzioDestinatarioAsync(long id, string cfPiva, string indirizzo, string ragSo, long comuneId)
        {
            var entity = await consorzioDestinatariRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva && x.Indirizzo == indirizzo && x.ConsorzioComuneId == comuneId && x.Descrizione == ragSo && x.Id != id && x.Disabled == false);

            if (entity.Data.Count > 0)
            {
                return new PercentValidateDto() { foundId = entity.Data.FirstOrDefault().Id, percent = 1, obj = entity.Data.FirstOrDefault() };
            }
            else
            {
                var entityCf = await consorzioDestinatariRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva && x.ConsorzioComuneId == comuneId && x.Disabled == false);
                if (entityCf.Data.Count > 0)
                {
                    List<long> foundId = new List<long>();
                    List<long> foundCompleteId = new List<long>();
                    List<(long, double)> listRagsoPrc = new List<(long, double)>();
                    List<(long, double)> listIndPrc = new List<(long, double)>();

                    double ragSoPrc = 0;
                    double indPrc = 0;

                    foreach (var itm in entityCf.Data)
                    {
                        ragSoPrc = sh.CalculateSimilarity(itm.Descrizione, ragSo);
                        if (ragSoPrc > 0.8)
                        {
                            listRagsoPrc.Add((itm.Id, ragSoPrc));

                            foundId.Add(itm.Id);
                        }
                    }

                    if (foundId.Count > 0)
                    {
                        foreach (var itm in entityCf.Data.Where(x => foundId.Contains(x.Id)))
                        {

                            indPrc = sh.CalculateSimilarity(itm.Indirizzo, indirizzo);

                            listIndPrc.Add((itm.Id, indPrc));
                            foundCompleteId.Add(itm.Id);

                        }

                        var resultPrc = listRagsoPrc.Concat(listIndPrc)
                            .GroupBy(item => item.Item1)
                            .Select(group => (group.Key, group.Sum(item => item.Item2) / 2))
                            .ToList();


                        if (foundCompleteId.Count > 0)
                        {
                            return new PercentValidateDto() { foundId = foundCompleteId.FirstOrDefault(), percent = resultPrc.OrderByDescending(x => x.Item2).Select(x => x.Item2).FirstOrDefault(), obj = entityCf.Data.Where(x => x.Id == foundCompleteId.FirstOrDefault()).FirstOrDefault() };
                        }
                        else
                        {
                            return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                        }
                    }
                    else
                    {
                        return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                    }


                }
                else
                {
                    return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                }

            }
        }

        public async Task<bool> ChangeStatusConsorzioDestinatarioAsync(long id)
        {
            var entity = await consorzioDestinatariRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioDestinatariRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioDestinatariRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioDestinatari>> GetViewConsorzioDestinatariAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioDestinatariRepo.GetAllAsync(1, 0) : await viewConsorzioDestinatariRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioTrasportatori
        public async Task<ConsorzioTrasportatoriDto> GetConsorzioTrasportatoriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioTrasportatoriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioTrasportatoriDto, PagedList<ConsorzioTrasportatore>>();
            return dtos;
        }

        public async Task<ConsorzioTrasportatoreDto> GetConsorzioTrasportatoreByIdAsync(long id)
        {
            var entity = await consorzioTrasportatoriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioTrasportatoreDto, ConsorzioTrasportatore>();
            return dto;
        }

        public async Task<long> AddConsorzioTrasportatoreAsync(ConsorzioTrasportatoreDto dto)
        {
            var entity = dto.ToEntity<ConsorzioTrasportatore, ConsorzioTrasportatoreDto>();
            await consorzioTrasportatoriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioTrasportatoreAsync(ConsorzioTrasportatoreDto dto)
        {
            var entity = dto.ToEntity<ConsorzioTrasportatore, ConsorzioTrasportatoreDto>();
            consorzioTrasportatoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioTrasportatoreAsync(long id)
        {
            var entity = await consorzioTrasportatoriRepo.GetByIdAsync(id);
            consorzioTrasportatoriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioTrasportatoreAsync(long id, string cfPiva, string indirizzo)
        {
            var entity = await consorzioTrasportatoriRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva && x.Indirizzo == indirizzo && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<PercentValidateDto> ValidatePercentConsorzioTrasportatoreAsync(long id, string cfPiva, string indirizzo, string ragSo, long comuneId)
        {
            var entity = await consorzioTrasportatoriRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva && x.Indirizzo == indirizzo && x.ConsorzioComuneId == comuneId && x.Descrizione == ragSo && x.Id != id && x.Disabled == false);

            if (entity.Data.Count > 0)
            {
                return new PercentValidateDto() { foundId = entity.Data.FirstOrDefault().Id, percent = 1, obj = entity.Data.FirstOrDefault() };
            }
            else
            {
                var entityCf = await consorzioTrasportatoriRepo.GetWithFilterAsync(x => x.CfPiva == cfPiva && x.ConsorzioComuneId == comuneId && x.Disabled == false);
                if (entityCf.Data.Count > 0)
                {
                    List<long> foundId = new List<long>();
                    List<long> foundCompleteId = new List<long>();
                    List<(long, double)> listRagsoPrc = new List<(long, double)>();
                    List<(long, double)> listIndPrc = new List<(long, double)>();

                    double ragSoPrc = 0;
                    double indPrc = 0;

                    foreach (var itm in entityCf.Data)
                    {
                        ragSoPrc = sh.CalculateSimilarity(itm.Descrizione, ragSo);
                        if (ragSoPrc > 0.8)
                        {
                            listRagsoPrc.Add((itm.Id, ragSoPrc));

                            foundId.Add(itm.Id);
                        }
                    }

                    if (foundId.Count > 0)
                    {
                        foreach (var itm in entityCf.Data.Where(x => foundId.Contains(x.Id)))
                        {

                            indPrc = sh.CalculateSimilarity(itm.Indirizzo, indirizzo);

                            listIndPrc.Add((itm.Id, indPrc));
                            foundCompleteId.Add(itm.Id);

                        }

                        var resultPrc = listRagsoPrc.Concat(listIndPrc)
                            .GroupBy(item => item.Item1)
                            .Select(group => (group.Key, group.Sum(item => item.Item2) / 2))
                            .ToList();


                        if (foundCompleteId.Count > 0)
                        {
                            return new PercentValidateDto() { foundId = foundCompleteId.FirstOrDefault(), percent = resultPrc.OrderByDescending(x => x.Item2).Select(x => x.Item2).FirstOrDefault(), obj = entityCf.Data.Where(x => x.Id == foundCompleteId.FirstOrDefault()).FirstOrDefault() };
                        }
                        else
                        {
                            return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                        }
                    }
                    else
                    {
                        return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                    }


                }
                else
                {
                    return new PercentValidateDto() { foundId = -1, percent = 0, obj = null };
                }

            }
        }

        public async Task<bool> ChangeStatusConsorzioTrasportatoreAsync(long id)
        {
            var entity = await consorzioTrasportatoriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioTrasportatoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioTrasportatoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioTrasportatori>> GetViewConsorzioTrasportatoriAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioTrasportatoriRepo.GetAllAsync(1, 0) : await viewConsorzioTrasportatoriRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }
        #endregion

        #endregion

        #region ConsorzioRegistrazioni
        public async Task<ConsorzioRegistrazioniDto> GetConsorzioRegistrazioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioRegistrazioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioRegistrazioniDto, PagedList<ConsorzioRegistrazione>>();
            return dtos;
        }

        public async Task<ConsorzioRegistrazioneDto> GetConsorzioRegistrazioneByIdAsync(long id)
        {
            var entity = await consorzioRegistrazioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioRegistrazioneDto, ConsorzioRegistrazione>();
            return dto;
        }

        public async Task<long> AddConsorzioRegistrazioneAsync(ConsorzioRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioRegistrazione, ConsorzioRegistrazioneDto>();
            await consorzioRegistrazioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<ConsorzioRegistrazioniDto> AddRangeConsorzioRegistrazioneAsync(ConsorzioRegistrazioniDto dto)
        {
            var entities = dto.ToEntity<PagedList<ConsorzioRegistrazione>, ConsorzioRegistrazioniDto>();
            consorzioRegistrazioniRepo.AddRange(entities.Data.AsEnumerable());
            await SaveChanges();

            var response = entities.ToDto<ConsorzioRegistrazioniDto, PagedList<ConsorzioRegistrazione>>();
            return response;
        }

        public async Task<long> UpdateConsorzioRegistrazioneAsync(ConsorzioRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioRegistrazione, ConsorzioRegistrazioneDto>();
            consorzioRegistrazioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioRegistrazioneAsync(long id)
        {
            var entity = await consorzioRegistrazioniRepo.GetByIdAsync(id);
            consorzioRegistrazioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioRegistrazioneAsync(long id, string userId)
        {
            var entity = await consorzioRegistrazioniRepo.GetWithFilterAsync(x => x.UserId == userId && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioRegistrazioneAsync(long id)
        {
            var entity = await consorzioRegistrazioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioniAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioRegistrazioniRepo.GetAllAsync(1, 0) : await viewConsorzioRegistrazioniRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
        }

        public async Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioneByRolesAsync(string roles)
        {
            var entities = await viewConsorzioRegistrazioniRepo.GetWithFilterAsync(x => x.Roles == roles);
            return entities;
        }

        public async Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioniByFilterAsync(long id, string roles)
        {
            try
            {
                PagedList<ViewConsorzioRegistrazioni> entities = new PagedList<ViewConsorzioRegistrazioni>();

                string[] rolesToCheck = roles.Split(',');

                if (roles.Contains("Administrator") || roles.Contains("ExtConsorzioAdmin"))
                {
                    return await viewConsorzioRegistrazioniRepo.GetWithFilterAsync(x => x.Id == id);
                }
                else
                {
                    var data = viewConsorzioRegistrazioniRepo.GetWithFilterAsync(x => x.Id == id)
                        .Result
                        .Data
                        .AsEnumerable()
                        .Where(t => rolesToCheck.Any(p => t.Roles.Contains(p)));

                    entities.Data.AddRange(data);
                    entities.TotalCount = data.Count();
                    entities.PageSize = 0;

                    return entities;

                }


                return entities;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public PagedList<ViewConsorzioRegistrazioni> GetViewConsorzioRegistrazioniQueryable(GridOperationsModel filterParams)
        {
            if (!string.IsNullOrWhiteSpace(filterParams.quickFilter))
            {
                var filterResult = viewConsorzioRegistrazioniRepo.GetAllQueryableV2WithQuickFilter(filterParams, filterParams.quickFilter);
                return filterResult;
            }
            else
            {
                var filterResult = viewConsorzioRegistrazioniRepo.GetAllQueryableV2(filterParams);
                return filterResult;
            }
        }

        //public PagedList<ViewConsorzioRegistrazioni> GetViewConsorzioRegistrazioniByProduttoreQueryable(GridOperationsModel filterParams, long[]? produttoriId)
        //{

        //    if (!string.IsNullOrWhiteSpace(filterParams.quickFilter))
        //    {
        //        if (produttoriId == null || produttoriId.Count() == 0)
        //        {
        //            var filterResult = viewConsorzioRegistrazioniRepo.GetAllQueryableV2WithQuickFilter(filterParams, filterParams.quickFilter);
        //            return filterResult;
        //        }
        //        else
        //        {
        //            var filterResult = viewConsorzioRegistrazioniRepo.GetWithFilterQueryableV2WithQuickFilter(x => produttoriId.Contains(x.ProduttoreId), filterParams, filterParams.quickFilter);
        //            return filterResult;
        //        }
        //    }
        //    else
        //    {
        //        if (produttoriId == null || produttoriId.Count() == 0)
        //        {
        //            var filterResult = viewConsorzioRegistrazioniRepo.GetAllQueryableV2(filterParams);
        //            return filterResult;
        //        }
        //        else
        //        {
        //            var filterResult = viewConsorzioRegistrazioniRepo.GetWithFilterQueryableV2(x => produttoriId.Contains(x.ProduttoreId), filterParams);
        //            return filterResult;
        //        }
        //    }

        //}

        public PagedList<ViewConsorzioRegistrazioni> GetViewConsorzioRegistrazioniByRolesQueryable(GridOperationsModel filterParams, string[]? roles)
        {
            //Aggiungere controllo ruolo admin o extconsorzioadmin

            if (!string.IsNullOrWhiteSpace(filterParams.quickFilter))
            {
                if (roles == null || roles.Count() == 0)
                {
                    var filterResult = viewConsorzioRegistrazioniRepo.GetAllQueryableV2WithQuickFilter(filterParams, filterParams.quickFilter);
                    return filterResult;
                }
                else
                {
                    var filterResult = viewConsorzioRegistrazioniRepo.GetWithFilterQueryableV2WithQuickFilter(x => x.Id>0, filterParams, filterParams.quickFilter)
                        .Data
                        .AsEnumerable()
                        .Where(t=>roles.Any(p=>t.Roles.Contains(p)));

                    var result = new PagedList<ViewConsorzioRegistrazioni>();
                    result.TotalCount=filterResult.Count();
                    result.PageSize = 0;
                    result.Data.AddRange(filterResult);
                    return result;
                }
            }
            else
            {
                if (roles == null || roles.Count() == 0)
                {
                    var filterResult = viewConsorzioRegistrazioniRepo.GetAllQueryableV2(filterParams);
                    return filterResult;
                }
                else
                {
                    var filterResult = viewConsorzioRegistrazioniRepo.GetWithFilterQueryableV2(x => x.Id>0, filterParams)
                        .Data
                        .AsEnumerable()
                        .Where(t => roles.Any(p => t.Roles.Contains(p)));

                    var result = new PagedList<ViewConsorzioRegistrazioni>();
                    result.TotalCount = filterResult.Count();
                    result.PageSize = 0;
                    result.Data.AddRange(filterResult);
                    return result;
                }
            }

        }

        public async Task<PagedList<ViewConsorzioRegistrazioni>> GetViewConsorzioRegistrazioniQueryableByDateAsync(DateTime dateStart, DateTime dateEnd)
        {
            var view = await viewConsorzioRegistrazioniRepo
            .GetWithFilterAsync(x => x.DataRegistrazione >= dateStart && x.DataRegistrazione <= dateEnd, 1, 0, "DataRegistrazione", "OrderByDescending");
            return view;
        }
        #endregion

        #endregion

        #region ConsorzioRegistrazioniAllegati
        public async Task<ConsorzioRegistrazioniAllegatiDto> GetConsorzioRegistrazioniAllegatiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioRegistrazioniAllegatiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioRegistrazioniAllegatiDto, PagedList<ConsorzioRegistrazioneAllegato>>();
            return dtos;
        }

        public async Task<ConsorzioRegistrazioneAllegatoDto> GetConsorzioRegistrazioneAllegatoByIdAsync(long id)
        {
            var entity = await consorzioRegistrazioniAllegatiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioRegistrazioneAllegatoDto, ConsorzioRegistrazioneAllegato>();
            return dto;
        }

        public async Task<ConsorzioRegistrazioniAllegatiDto> GetConsorzioRegistrazioniAllegatiByRegistrazioneIdAsync(long consorzioRegistrazioneId)
        {
            var entities = await consorzioRegistrazioniAllegatiRepo.GetWithFilterAsync(x => x.ConsorzioRegistrazioneId == consorzioRegistrazioneId);
            var dtos = entities.ToDto<ConsorzioRegistrazioniAllegatiDto, PagedList<ConsorzioRegistrazioneAllegato>>();
            return dtos;
        }

        public async Task<long> AddConsorzioRegistrazioneAllegatoAsync(ConsorzioRegistrazioneAllegatoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioRegistrazioneAllegato, ConsorzioRegistrazioneAllegatoDto>();
            await consorzioRegistrazioniAllegatiRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioRegistrazioneAllegatoAsync(ConsorzioRegistrazioneAllegatoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioRegistrazioneAllegato, ConsorzioRegistrazioneAllegatoDto>();
            consorzioRegistrazioniAllegatiRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioRegistrazioneAllegatoAsync(long id)
        {
            var entity = await consorzioRegistrazioniAllegatiRepo.GetByIdAsync(id);
            consorzioRegistrazioniAllegatiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioRegistrazioneAllegatoAsync(long id, string descrizione)
        {
            var entity = await consorzioRegistrazioniAllegatiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioRegistrazioneAllegatoAsync(long id)
        {
            var entity = await consorzioRegistrazioniAllegatiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioRegistrazioniAllegatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioRegistrazioniAllegatiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ConsorzioOperazioni
        public async Task<ConsorzioOperazioniDto> GetConsorzioOperazioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioOperazioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioOperazioniDto, PagedList<ConsorzioOperazione>>();
            return dtos;
        }

        public async Task<ConsorzioOperazioneDto> GetConsorzioOperazioneByIdAsync(long id)
        {
            var entity = await consorzioOperazioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioOperazioneDto, ConsorzioOperazione>();
            return dto;
        }

        public async Task<long> AddConsorzioOperazioneAsync(ConsorzioOperazioneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioOperazione, ConsorzioOperazioneDto>();
            await consorzioOperazioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioOperazioneAsync(ConsorzioOperazioneDto dto)
        {
            var entity = dto.ToEntity<ConsorzioOperazione, ConsorzioOperazioneDto>();
             consorzioOperazioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioOperazioneAsync(long id)
        {
            var entity = await consorzioOperazioniRepo.GetByIdAsync(id);
            consorzioOperazioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioOperazioneAsync(long id, string descrizione)
        {
            var entity = await consorzioOperazioniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioOperazioneAsync(long id)
        {
            var entity = await consorzioOperazioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioOperazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioOperazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ConsorzioPeriodi
        public async Task<ConsorzioPeriodiDto> GetConsorzioPeriodiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioPeriodiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioPeriodiDto, PagedList<ConsorzioPeriodo>>();
            return dtos;
        }

        public async Task<ConsorzioPeriodoDto> GetConsorzioPeriodoByIdAsync(long id)
        {
            var entity = await consorzioPeriodiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioPeriodoDto, ConsorzioPeriodo>();
            return dto;
        }

        public async Task<long> AddConsorzioPeriodoAsync(ConsorzioPeriodoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioPeriodo, ConsorzioPeriodoDto>();
            await consorzioPeriodiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioPeriodoAsync(ConsorzioPeriodoDto dto)
        {
            var entity = dto.ToEntity<ConsorzioPeriodo, ConsorzioPeriodoDto>();
            consorzioPeriodiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteConsorzioPeriodoAsync(long id)
        {
            var entity = await consorzioPeriodiRepo.GetByIdAsync(id);
            consorzioPeriodiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateConsorzioPeriodoAsync(long id, string descrizione)
        {
            var entity = await consorzioPeriodiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusConsorzioPeriodoAsync(long id)
        {
            var entity = await consorzioPeriodiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                consorzioPeriodiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                consorzioPeriodiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region ConsorzioImportsTasks
        public async Task<ConsorzioImportsTasksDto> GetConsorzioImportsTasksAsync(int page = 1, int pageSize = 0)
        {
            var entities = await consorzioImportsTasksRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ConsorzioImportsTasksDto, PagedList<ConsorzioImportTask>>();
            return dtos;
        }

        public async Task<ConsorzioImportTaskDto> GetConsorzioImportTaskByIdAsync(long id)
        {
            var entity = await consorzioImportsTasksRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ConsorzioImportTaskDto, ConsorzioImportTask>();
            return dto;
        }

        public async Task<ConsorzioImportTaskDto> GetConsorzioImportTaskByTaskIdAsync(string taskId)
        {
            var entity = await consorzioImportsTasksRepo.GetSingleWithFilter(x=>x.TaskId==taskId);
            var dto = entity.ToDto<ConsorzioImportTaskDto, ConsorzioImportTask>();
            DetachEntity(entity);
            return dto;
        }

        public async Task<long> AddConsorzioImportTaskAsync(ConsorzioImportTaskDto dto)
        {
            var entity = dto.ToEntity<ConsorzioImportTask, ConsorzioImportTaskDto>();
            await consorzioImportsTasksRepo.AddAsync(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;
        }

        public async Task<long> UpdateConsorzioImportTaskAsync(ConsorzioImportTaskDto dto)
        {
            var entity = dto.ToEntity<ConsorzioImportTask, ConsorzioImportTaskDto>();
            consorzioImportsTasksRepo.Update(entity);
            await SaveChanges();
            DetachEntity(entity);
            return entity.Id;

           
        }

        public async Task<bool> DeleteConsorzioImportTaskByTaskIdAsync(string taskId)
        {
            var entities = await consorzioRegistrazioniRepo.GetWithFilterAsync(x => x.ConsorzioImportTaskId == taskId);
            consorzioRegistrazioniRepo.RemoveRange(entities.Data);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<string> GetConsorzioImportTaskLogByTaskId(long id)
        {
            var entity = await consorzioImportsTasksRepo.GetByIdAsync(id);
            var log = entity.Log;
            return log;
        }

        public async Task<bool> SetConsorzioImportTaskDeletedAsync(string taskId)
        {
            try
            {
                
                var entity = await consorzioImportsTasksRepo.GetSingleWithFilter(x=>x.TaskId==taskId);
                entity.Deleted = true;

                consorzioImportsTasksRepo.Update(entity);
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

        #region Views
        public async Task<PagedList<ViewConsorzioImportsTasks>> GetViewConsorzioImportsTasksAsync(bool all = true)
        {
            var entities = all ? await viewConsorzioImportsTasksRepo.GetAllAsync(1, 0) : await viewConsorzioImportsTasksRepo.GetWithFilterAsync(x => x.Disabled == false);
            return entities;
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
        #endregion

    }
}
