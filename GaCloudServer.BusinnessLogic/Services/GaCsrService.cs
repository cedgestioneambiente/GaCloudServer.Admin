using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Csr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Csr;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System.Globalization;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaCsrService : IGaCsrService
    {
        protected readonly IGenericRepository<CsrCodiceCer> gaCsrCodiciCersRepo;
        protected readonly IGenericRepository<CsrComune> gaCsrComuniRepo;
        protected readonly IGenericRepository<CsrDestinatario> gaCsrDestinatariRepo;
        protected readonly IGenericRepository<CsrProduttore> gaCsrProduttoriRepo;
        protected readonly IGenericRepository<CsrRegistrazione> gaCsrRegistrazioniRepo;
        protected readonly IGenericRepository<CsrRegistrazionePeso> gaCsrRegistrazioniPesiRepo;
        protected readonly IGenericRepository<CsrRipartizionePercentuale> gaCsrRipartizioniPercentualiRepo;
        protected readonly IGenericRepository<CsrTrasportatore> gaCsrTrasportatoriRepo;

        protected readonly IGenericRepository<ViewGaCsrCodiciCers> viewGaCsrCodiciCersRepo;
        protected readonly IGenericRepository<ViewGaCsrRipartizioniPercentuali> viewGaCsrRipartizioniPercentualiRepo;
        protected readonly IGenericRepository<ViewGaCsrProduttori> viewGaCsrProduttoriRepo;
        protected readonly IGenericRepository<ViewGaCsrDestinatari> viewGaCsrDestinatariRepo;
        protected readonly IGenericRepository<ViewGaCsrTrasportatori> viewGaCsrTrasportatoriRepo;
        protected readonly IGenericRepository<ViewGaCsrRegistrazioni> viewGaCsrRegistrazioniRepo;
        protected readonly IGenericRepository<ViewGaCsrRegistrazioniPesi> viewGaCsrRegistrazioniPesiRepo;
        protected readonly IGenericRepository<ViewGaCsrExports> viewGaCsrExportsRepo;

        protected readonly IUnitOfWork unitOfWork;

        private readonly CultureInfo itIT = new CultureInfo("it-IT");

        public GaCsrService(
            IGenericRepository<CsrCodiceCer> gaCsrCodiciCersRepo,
            IGenericRepository<CsrComune> gaCsrComuniRepo,
            IGenericRepository<CsrDestinatario> gaCsrDestinatariRepo,
            IGenericRepository<CsrProduttore> gaCsrProduttoriRepo,
            IGenericRepository<CsrRegistrazione> gaCsrRegistrazioniRepo,
            IGenericRepository<CsrRegistrazionePeso> gaCsrRegistrazioniPesiRepo,
            IGenericRepository<CsrRipartizionePercentuale> gaCsrRipartizioniPercentualiRepo,
            IGenericRepository<CsrTrasportatore> gaCsrTrasportatoriRepo,

            IGenericRepository<ViewGaCsrCodiciCers> viewGaCsrCodiciCersRepo,
            IGenericRepository<ViewGaCsrRipartizioniPercentuali> viewGaCsrRipartizioniPercentualiRepo,
            IGenericRepository<ViewGaCsrProduttori> viewGaCsrProduttoriRepo,
            IGenericRepository<ViewGaCsrDestinatari> viewGaCsrDestinatariRepo,
            IGenericRepository<ViewGaCsrTrasportatori> viewGaCsrTrasportatoriRepo,
            IGenericRepository<ViewGaCsrRegistrazioni> viewGaCsrRegistrazioniRepo,
            IGenericRepository<ViewGaCsrRegistrazioniPesi> viewGaCsrRegistrazioniPesiRepo,
            IGenericRepository<ViewGaCsrExports> viewGaCsrExportsRepo,

            IUnitOfWork unitOfWork)
        {
            this.gaCsrCodiciCersRepo = gaCsrCodiciCersRepo;
            this.gaCsrComuniRepo = gaCsrComuniRepo;
            this.gaCsrDestinatariRepo = gaCsrDestinatariRepo;
            this.gaCsrProduttoriRepo = gaCsrProduttoriRepo;
            this.gaCsrRegistrazioniRepo = gaCsrRegistrazioniRepo;
            this.gaCsrRegistrazioniPesiRepo = gaCsrRegistrazioniPesiRepo;
            this.gaCsrRipartizioniPercentualiRepo = gaCsrRipartizioniPercentualiRepo;
            this.gaCsrTrasportatoriRepo = gaCsrTrasportatoriRepo;

            this.viewGaCsrCodiciCersRepo = viewGaCsrCodiciCersRepo;
            this.viewGaCsrRipartizioniPercentualiRepo = viewGaCsrRipartizioniPercentualiRepo;
            this.viewGaCsrProduttoriRepo = viewGaCsrProduttoriRepo;
            this.viewGaCsrDestinatariRepo = viewGaCsrDestinatariRepo;
            this.viewGaCsrTrasportatoriRepo = viewGaCsrTrasportatoriRepo;
            this.viewGaCsrRegistrazioniRepo = viewGaCsrRegistrazioniRepo;
            this.viewGaCsrRegistrazioniPesiRepo = viewGaCsrRegistrazioniPesiRepo;
            this.viewGaCsrExportsRepo = viewGaCsrExportsRepo;

            this.unitOfWork = unitOfWork;
        }

        #region CsrCodiciCers
        public async Task<CsrCodiciCersDto> GetGaCsrCodiciCersAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCsrCodiciCersRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CsrCodiciCersDto, PagedList<CsrCodiceCer>>();
            return dtos;
        }

        public async Task<CsrCodiceCerDto> GetGaCsrCodiceCerByIdAsync(long id)
        {
            var entity = await gaCsrCodiciCersRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CsrCodiceCerDto, CsrCodiceCer>();
            return dto;
        }

        public async Task<long> AddGaCsrCodiceCerAsync(CsrCodiceCerDto dto)
        {
            var entity = dto.ToEntity<CsrCodiceCer, CsrCodiceCerDto>();
            await gaCsrCodiciCersRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCsrCodiceCerAsync(CsrCodiceCerDto dto)
        {
            var entity = dto.ToEntity<CsrCodiceCer, CsrCodiceCerDto>();
            gaCsrCodiciCersRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCsrCodiceCerAsync(long id)
        {
            var entity = await gaCsrCodiciCersRepo.GetByIdAsync(id);
            gaCsrCodiciCersRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCsrCodiceCerAsync(long id, string descrizione)
        {
            var entity = await gaCsrCodiciCersRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCsrCodiceCerAsync(long id)
        {
            var entity = await gaCsrCodiciCersRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCsrCodiciCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCsrCodiciCersRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaCsrCodiciCers>> GetViewGaCsrCodiciCersAsync()
        {
            try
            {
                return await viewGaCsrCodiciCersRepo.GetAllAsync(1, 0);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region CsrComuni
        public async Task<CsrComuniDto> GetGaCsrComuniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCsrComuniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CsrComuniDto, PagedList<CsrComune>>();
            return dtos;
        }

        public async Task<CsrComuneDto> GetGaCsrComuneByIdAsync(long id)
        {
            var entity = await gaCsrComuniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CsrComuneDto, CsrComune>();
            return dto;
        }

        public async Task<long> AddGaCsrComuneAsync(CsrComuneDto dto)
        {
            var entity = dto.ToEntity<CsrComune, CsrComuneDto>();
            await gaCsrComuniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCsrComuneAsync(CsrComuneDto dto)
        {
            var entity = dto.ToEntity<CsrComune, CsrComuneDto>();
            gaCsrComuniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCsrComuneAsync(long id)
        {
            var entity = await gaCsrComuniRepo.GetByIdAsync(id);
            gaCsrComuniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCsrComuneAsync(long id, string descrizione)
        {
            var entity = await gaCsrComuniRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCsrComuneAsync(long id)
        {
            var entity = await gaCsrComuniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCsrComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCsrComuniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region CsrDestinatari
        public async Task<CsrDestinatariDto> GetGaCsrDestinatariAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCsrDestinatariRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CsrDestinatariDto, PagedList<CsrDestinatario>>();
            return dtos;
        }

        public async Task<CsrDestinatarioDto> GetGaCsrDestinatarioByIdAsync(long id)
        {
            var entity = await gaCsrDestinatariRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CsrDestinatarioDto, CsrDestinatario>();
            return dto;
        }

        public async Task<long> AddGaCsrDestinatarioAsync(CsrDestinatarioDto dto)
        {
            var entity = dto.ToEntity<CsrDestinatario, CsrDestinatarioDto>();
            await gaCsrDestinatariRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCsrDestinatarioAsync(CsrDestinatarioDto dto)
        {
            var entity = dto.ToEntity<CsrDestinatario, CsrDestinatarioDto>();
            gaCsrDestinatariRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCsrDestinatarioAsync(long id)
        {
            var entity = await gaCsrDestinatariRepo.GetByIdAsync(id);
            gaCsrDestinatariRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCsrDestinatarioAsync(long id, string ragioneSociale)
        {
            var entity = await gaCsrDestinatariRepo.GetWithFilterAsync(x => x.RagioneSociale == ragioneSociale && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCsrDestinatarioAsync(long id)
        {
            var entity = await gaCsrDestinatariRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCsrDestinatariRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCsrDestinatariRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaCsrDestinatari>> GetViewGaCsrDestinatariAsync()
        {
            try
            {
                return await viewGaCsrDestinatariRepo.GetAllAsync(1, 0);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region CsrProduttori
        public async Task<CsrProduttoriDto> GetGaCsrProduttoriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCsrProduttoriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CsrProduttoriDto, PagedList<CsrProduttore>>();
            return dtos;
        }

        public async Task<CsrProduttoreDto> GetGaCsrProduttoreByIdAsync(long id)
        {
            var entity = await gaCsrProduttoriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CsrProduttoreDto, CsrProduttore>();
            return dto;
        }

        public async Task<long> AddGaCsrProduttoreAsync(CsrProduttoreDto dto)
        {
            var entity = dto.ToEntity<CsrProduttore, CsrProduttoreDto>();
            await gaCsrProduttoriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCsrProduttoreAsync(CsrProduttoreDto dto)
        {
            var entity = dto.ToEntity<CsrProduttore, CsrProduttoreDto>();
            gaCsrProduttoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCsrProduttoreAsync(long id)
        {
            var entity = await gaCsrProduttoriRepo.GetByIdAsync(id);
            gaCsrProduttoriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCsrProduttoreAsync(long id, string ragioneSociale)
        {
            var entity = await gaCsrProduttoriRepo.GetWithFilterAsync(x => x.RagioneSociale == ragioneSociale && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCsrProduttoreAsync(long id)
        {
            var entity = await gaCsrProduttoriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCsrProduttoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCsrProduttoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaCsrProduttori>> GetViewGaCsrProduttoriAsync()
        {
            try
            {
                return await viewGaCsrProduttoriRepo.GetAllAsync(1, 0);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region CsrTrasportatori
        public async Task<CsrTrasportatoriDto> GetGaCsrTrasportatoriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCsrTrasportatoriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CsrTrasportatoriDto, PagedList<CsrTrasportatore>>();
            return dtos;
        }

        public async Task<CsrTrasportatoreDto> GetGaCsrTrasportatoreByIdAsync(long id)
        {
            var entity = await gaCsrTrasportatoriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CsrTrasportatoreDto, CsrTrasportatore>();
            return dto;
        }

        public async Task<long> AddGaCsrTrasportatoreAsync(CsrTrasportatoreDto dto)
        {
            var entity = dto.ToEntity<CsrTrasportatore, CsrTrasportatoreDto>();
            await gaCsrTrasportatoriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCsrTrasportatoreAsync(CsrTrasportatoreDto dto)
        {
            var entity = dto.ToEntity<CsrTrasportatore, CsrTrasportatoreDto>();
            gaCsrTrasportatoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCsrTrasportatoreAsync(long id)
        {
            var entity = await gaCsrTrasportatoriRepo.GetByIdAsync(id);
            gaCsrTrasportatoriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCsrTrasportatoreAsync(long id, string ragioneSociale)
        {
            var entity = await gaCsrTrasportatoriRepo.GetWithFilterAsync(x => x.RagioneSociale == ragioneSociale && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCsrTrasportatoreAsync(long id)
        {
            var entity = await gaCsrTrasportatoriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCsrTrasportatoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCsrTrasportatoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaCsrTrasportatori>> GetViewGaCsrTrasportatoriAsync()
        {
            try
            {
                return await viewGaCsrTrasportatoriRepo.GetAllAsync(1, 0);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region CsrRegistrazioni
        public async Task<CsrRegistrazioniDto> GetGaCsrRegistrazioniAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCsrRegistrazioniRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CsrRegistrazioniDto, PagedList<CsrRegistrazione>>();
            return dtos;
        }

        public async Task<CsrRegistrazioneDto> GetGaCsrRegistrazioneByIdAsync(long id)
        {
            var entity = await gaCsrRegistrazioniRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CsrRegistrazioneDto, CsrRegistrazione>();
            return dto;
        }

        public async Task<long> AddGaCsrRegistrazioneAsync(CsrRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<CsrRegistrazione, CsrRegistrazioneDto>();
            await gaCsrRegistrazioniRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCsrRegistrazioneAsync(CsrRegistrazioneDto dto)
        {
            var entity = dto.ToEntity<CsrRegistrazione, CsrRegistrazioneDto>();
            gaCsrRegistrazioniRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCsrRegistrazioneAsync(long id)
        {
            var entity = await gaCsrRegistrazioniRepo.GetByIdAsync(id);
            gaCsrRegistrazioniRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<List<ViewGaCsrExports>> GetGaCsrExport(int anno, List<int> comuni)
        {
            try
            {
                var export = viewGaCsrExportsRepo.GetWithFilterAsync(x => x.AnnoId == anno && comuni.Contains(Convert.ToInt32(x.ComuneId)), 1, 0, "ComuneId").Result.Data.OrderBy(x => x.MeseId).ThenBy(x => x.Cer);
                return export.GroupBy(x => new {
                    x.AnnoId,
                    x.MeseId,
                    x.Data,
                    x.Cdr,
                    x.Cer,
                    x.Modalita,
                    x.Produttore,
                    x.Destinatario,
                    x.DestinatarioIndirizzo,
                    x.Trasportatore,
                    x.TrasportatoreIndirizzo
                })
                .Select(x => new ViewGaCsrExports
                {
                    AnnoId = x.Key.AnnoId,
                    MeseId = x.Key.MeseId,
                    Mese = new DateTime(2020, x.Key.MeseId, 1).ToString("MMMM", itIT),
                    Data = x.Key.Data,
                    Cdr = x.Key.Cdr,
                    Cer = x.Key.Cer,
                    Modalita = x.Key.Modalita,
                    Produttore = x.Key.Produttore,
                    Destinatario = x.Key.Destinatario,
                    DestinatarioIndirizzo = x.Key.DestinatarioIndirizzo,
                    Trasportatore = x.Key.Trasportatore,
                    TrasportatoreIndirizzo = x.Key.TrasportatoreIndirizzo,
                    PesoTotale = x.Sum(p => p.PesoTotale)

                }).ToList();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<List<int>> GetGaCsrRegistrazioniAnniAsync()
        {
            try
            {
                return viewGaCsrRegistrazioniRepo.GetAllAsync(1, 0).Result.Data.Select(x => x.Data.Year).Distinct().ToList();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<bool> ChangeStatusGaCsrRegistrazioneAsync(long id)
        {
            var entity = await gaCsrRegistrazioniRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCsrRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCsrRegistrazioniRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaCsrRegistrazioni>> GetViewGaCsrRegistrazioniAsync(bool all = true)
        {
            try
            {
                return await viewGaCsrRegistrazioniRepo.GetAllAsync(1, 0);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<List<ViewGaCsrExports>> GetGaCsrExports(int anno, List<int> comuni)
        {
            try
            {
                var export = viewGaCsrExportsRepo.GetWithFilterAsync(x => x.AnnoId == anno && comuni.Contains(Convert.ToInt32(x.ComuneId)), 1, 0, "ComuneId").Result.Data.OrderBy(x => x.MeseId).ThenBy(x => x.Cer);
                return export.GroupBy(x => new {
                    x.AnnoId,
                    x.MeseId,
                    x.Data,
                    x.Cdr,
                    x.Cer,
                    x.Modalita,
                    x.Produttore,
                    x.Destinatario,
                    x.DestinatarioIndirizzo,
                    x.Trasportatore,
                    x.TrasportatoreIndirizzo
                })
                .Select(x => new ViewGaCsrExports
                {
                    AnnoId = x.Key.AnnoId,
                    MeseId = x.Key.MeseId,
                    Mese = new DateTime(2020, x.Key.MeseId, 1).ToString("MMMM", itIT),
                    Data = x.Key.Data,
                    Cdr = x.Key.Cdr,
                    Cer = x.Key.Cer,
                    Modalita = x.Key.Modalita,
                    Produttore = x.Key.Produttore,
                    Destinatario = x.Key.Destinatario,
                    DestinatarioIndirizzo = x.Key.DestinatarioIndirizzo,
                    Trasportatore = x.Key.Trasportatore,
                    TrasportatoreIndirizzo = x.Key.TrasportatoreIndirizzo,
                    PesoTotale = x.Sum(p => p.PesoTotale)

                }).ToList();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        #endregion

        #endregion

        #region CsrRegistrazioniPesi
        public async Task<CsrRegistrazioniPesiDto> GetGaCsrRegistrazioniPesiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCsrRegistrazioniPesiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CsrRegistrazioniPesiDto, PagedList<CsrRegistrazionePeso>>();
            return dtos;
        }

        public async Task<CsrRegistrazionePesoDto> GetGaCsrRegistrazionePesoByIdAsync(long id)
        {
            var entity = await gaCsrRegistrazioniPesiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CsrRegistrazionePesoDto, CsrRegistrazionePeso>();
            return dto;
        }

        //public async Task<long> AddGaCsrRegistrazionePesoAsync(CsrRegistrazionePesoDto dto)
        //{
        //    var entity = dto.ToEntity<CsrRegistrazionePeso, CsrRegistrazionePesoDto>();
        //    await gaCsrRegistrazioniPesiRepo.AddAsync(entity);
        //    await SaveChanges();
        //    return entity.Id;
        //}

        //public async Task<long> UpdateGaCsrRegistrazionePesoAsync(CsrRegistrazionePesoDto dto)
        //{
        //    var entity = dto.ToEntity<CsrRegistrazionePeso, CsrRegistrazionePesoDto>();
        //    gaCsrRegistrazioniPesiRepo.Update(entity);
        //    await SaveChanges();

        //    return entity.Id;

        //}

        //public async Task<bool> DeleteGaCsrRegistrazionePesoAsync(long id)
        //{
        //    var entity = await gaCsrRegistrazioniPesiRepo.GetByIdAsync(id);
        //    gaCsrRegistrazioniPesiRepo.Remove(entity);
        //    await SaveChanges();

        //    return true;
        //}

        #region Functions



        //public async Task<bool> ValidateGaCsrRegistrazionePesoAsync(long id, string descrizione)
        //{
        //    var entity = await gaCsrRegistrazioniPesiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

        //    if (entity.Data.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public async Task<bool> ChangeStatusGaCsrRegistrazionePesoAsync(long id)
        //{
        //    var entity = await gaCsrRegistrazioniPesiRepo.GetByIdAsync(id);
        //    if (entity.Disabled)
        //    {
        //        entity.Disabled = false;
        //        gaCsrRegistrazioniPesiRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        entity.Disabled = true;
        //        gaCsrRegistrazioniPesiRepo.Update(entity);
        //        await SaveChanges();
        //        return true;
        //    }

        //}
        #endregion

        #region Views
        public async Task<PagedList<ViewGaCsrRegistrazioniPesi>> GetViewGaCsrRegistrazioniPesiByRegistrazioneIdAsync(long registrazioneId)
        {
            try
            {
                return await viewGaCsrRegistrazioniPesiRepo.GetWithFilterAsync(x => x.RegistrazioneId == registrazioneId);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #endregion

        #region CsrRipartizioniPercentuali
        public async Task<CsrRipartizioniPercentualiDto> GetGaCsrRipartizioniPercentualiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaCsrRipartizioniPercentualiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<CsrRipartizioniPercentualiDto, PagedList<CsrRipartizionePercentuale>>();
            return dtos;
        }

        public async Task<CsrRipartizionePercentualeDto> GetGaCsrRipartizionePercentualeByIdAsync(long id)
        {
            var entity = await gaCsrRipartizioniPercentualiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<CsrRipartizionePercentualeDto, CsrRipartizionePercentuale>();
            return dto;
        }

        public async Task<CsrRipartizioniPercentualiDto> GetGaCsrRipartizioniPercentualiByComuneIdAsync(long comuneId)
        {
            var entity = await gaCsrRipartizioniPercentualiRepo.GetWithFilterAsync(x => x.CsrComuneId == comuneId);
            var dto = entity.ToDto<CsrRipartizioniPercentualiDto, PagedList<CsrRipartizionePercentuale>>();
            return dto;
        }

        public async Task<long> AddGaCsrRipartizionePercentualeAsync(CsrRipartizionePercentualeDto dto)
        {
            var entity = dto.ToEntity<CsrRipartizionePercentuale, CsrRipartizionePercentualeDto>();
            await gaCsrRipartizioniPercentualiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaCsrRipartizionePercentualeAsync(CsrRipartizionePercentualeDto dto)
        {
            var entity = dto.ToEntity<CsrRipartizionePercentuale, CsrRipartizionePercentualeDto>();
            gaCsrRipartizioniPercentualiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaCsrRipartizionePercentualeAsync(long id)
        {
            var entity = await gaCsrRipartizioniPercentualiRepo.GetByIdAsync(id);
            gaCsrRipartizioniPercentualiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaCsrRipartizionePercentualeAsync(long id, long comuneId, long produttoreId)
        {
            var entity = await gaCsrRipartizioniPercentualiRepo.GetWithFilterAsync(x => x.CsrComuneId == comuneId && x.CsrProduttoreId == produttoreId && x.Id != id, 1, 0);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaCsrRipartizionePercentualeAsync(long id)
        {
            var entity = await gaCsrRipartizioniPercentualiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaCsrRipartizioniPercentualiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaCsrRipartizioniPercentualiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaCsrRipartizioniPercentuali>> GetViewGaCsrRipartizioniPercentualiByComuneIdAsync(long comuneId)
        {
            try
            {
                return await viewGaCsrRipartizioniPercentualiRepo.GetWithFilterAsync(x => x.ComuneId == comuneId);
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
        #endregion
    }
}
