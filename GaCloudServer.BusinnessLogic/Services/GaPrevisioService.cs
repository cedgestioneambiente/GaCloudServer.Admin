using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views;
using GaCloudServer.BusinnessLogic.Constants;
using GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder;
using GaCloudServer.BusinnessLogic.Hub.Interfaces;
using GaCloudServer.BusinnessLogic.Hub;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using static GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder.CustomEcoFinderDto;
using Microsoft.Extensions.Logging;
using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Previsio;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPrevisioService:IGaPrevisioService
    {
        protected readonly IQueryManager _queryManager;

        protected readonly IGenericRepository<PrevisioOdsLettura> gaPrevisioOdsLettureRepo;
        protected readonly IGenericRepository<PrevisioAnomaliaLettura> gaPrevisioAnomalieLettureRepo;

        protected readonly IGenericRepository<ViewGaPrevisioOdsReport> viewPrevisioOdsReportRepo;
        protected readonly IGenericRepository<ViewGaPrevisioOdsServiziReport> viewPrevisioOdsServiziReportRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewBackOfficeUtenzeDispositiviRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzePartite> viewBackOfficeUtenzePartiteRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenze> viewBackOfficeUtenzeRepo;
        protected readonly IGenericRepository<ViewGaPrevisioOdsLetture> viewPrevisioOdsLettureRepo;


        protected readonly IUnitOfWork unitOfWork;
        private readonly IHubContext<BackgroundServicesHub, IBackgroundServicesHub> hub;

        private readonly ILogger<GaPrevisioService> logger;

        public GaPrevisioService(
            IQueryManager queryManager,

            IGenericRepository<PrevisioOdsLettura> gaPrevisioOdsLettureRepo,
            IGenericRepository<PrevisioAnomaliaLettura> gaPrevisioAnomalieLettureRepo,

            IGenericRepository<ViewGaPrevisioOdsReport> viewPrevisioOdsReportRepo,
            IGenericRepository<ViewGaPrevisioOdsServiziReport> viewPrevisioOdsServiziReportRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewBackOfficeUtenzeDispositiviRepo,
            IGenericRepository<ViewGaBackOfficeUtenzePartite> viewBackOfficeUtenzePartiteRepo,
            IGenericRepository<ViewGaBackOfficeUtenze> viewBackOfficeUtenzeRepo,
            IGenericRepository<ViewGaPrevisioOdsLetture> viewPrevisioOdsLettureRepo,

            IUnitOfWork unitOfWork,
            IHubContext<BackgroundServicesHub, IBackgroundServicesHub> hub,
            ILogger<GaPrevisioService> logger)
        {
            this._queryManager = queryManager;

            this.gaPrevisioOdsLettureRepo = gaPrevisioOdsLettureRepo;
            this.gaPrevisioAnomalieLettureRepo = gaPrevisioAnomalieLettureRepo;

            this.viewPrevisioOdsReportRepo = viewPrevisioOdsReportRepo;
            this.viewPrevisioOdsServiziReportRepo = viewPrevisioOdsServiziReportRepo;
            this.viewBackOfficeUtenzeDispositiviRepo = viewBackOfficeUtenzeDispositiviRepo;
            this.viewBackOfficeUtenzePartiteRepo = viewBackOfficeUtenzePartiteRepo;
            this.viewBackOfficeUtenzeRepo = viewBackOfficeUtenzeRepo;
            this.viewPrevisioOdsLettureRepo = viewPrevisioOdsLettureRepo;

            this.unitOfWork = unitOfWork;

            this.hub = hub;
            this.logger = logger;

        }

        #region PrevisioOdsLetture
        public async Task<PrevisioOdsLettureDto> GetGaPrevisioOdsLettureAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPrevisioOdsLettureRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PrevisioOdsLettureDto, PagedList<PrevisioOdsLettura>>();
            return dtos;
        }

        public async Task<PrevisioOdsLetturaDto> GetGaPrevisioOdsLetturaByIdAsync(long id)
        {
            var entity = await gaPrevisioOdsLettureRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PrevisioOdsLetturaDto, PrevisioOdsLettura>();
            return dto;
        }

        public async Task<long> AddGaPrevisioOdsLetturaAsync(PrevisioOdsLetturaDto dto)
        {
            var entity = dto.ToEntity<PrevisioOdsLettura, PrevisioOdsLetturaDto>();
            await gaPrevisioOdsLettureRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> AddOrUpdateGaPrevisioOdsLetturaAsync(PrevisioOdsLetturaDto dto)
        {
            var entity = await gaPrevisioOdsLettureRepo.GetSingleWithFilter(x=>x.FileName==dto.FileName);
            if (entity != null)
            {
                entity.ProcDescription = string.Concat(entity.ProcDescription, " | ", dto.ProcDescription);
                entity.ErrDescription = string.Concat(entity.ErrDescription, " | ", dto.ErrDescription);
                entity.DateUpdated = DateTime.Now;
                entity.Retry += 1;
                gaPrevisioOdsLettureRepo.Update(entity);
                await SaveChanges();
                return entity.Id;
            }
            else
            { 
                entity= dto.ToEntity<PrevisioOdsLettura, PrevisioOdsLetturaDto>();
                entity.DateCreated = DateTime.Now;
                await gaPrevisioOdsLettureRepo.AddAsync(entity);
                await SaveChanges();
                return entity.Id;
            }
        }

        public async Task<long> UpdateGaPrevisioOdsLetturaAsync(PrevisioOdsLetturaDto dto)
        {
            var entity = dto.ToEntity<PrevisioOdsLettura, PrevisioOdsLetturaDto>();
            gaPrevisioOdsLettureRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPrevisioOdsLetturaAsync(long id)
        {
            var entity = await gaPrevisioOdsLettureRepo.GetByIdAsync(id);
            gaPrevisioOdsLettureRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPrevisioOdsLetturaAsync(long id, string descrizione)
        {
            var entity = await gaPrevisioOdsLettureRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusElaboratoGaPrevisioOdsLetturaAsync(long id)
        {
            var entity = await gaPrevisioOdsLettureRepo.GetByIdAsync(id);
            if (entity.Elaborato)
            {
                entity.Elaborato = false;
                gaPrevisioOdsLettureRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Elaborato = true;
                gaPrevisioOdsLettureRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        #endregion

        #region Views
        public async Task<PagedList<ViewGaPrevisioOdsLetture>> GetViewGaPrevisioOdsLettureAsync()
        {
            var view = await viewPrevisioOdsLettureRepo.GetAllAsync();
            return view;
        }

        public async Task<ViewGaPrevisioOdsLetture> GetViewGaPrevisioOdsLettureByFileNameAsync(string fileName)
        {
            var entityView = await viewPrevisioOdsLettureRepo.GetWithFilterAsync(x => x.FileName == fileName);
            return entityView.Data.FirstOrDefault();
        }
        #endregion

        #endregion

        #region Views
        public async Task<PagedList<ViewGaPrevisioOdsReport>> GetViewGaPrevisioOdsReportByDateAsync(DateTime dateStart, DateTime dateEnd)
        {
            var view = await viewPrevisioOdsReportRepo
            .GetWithFilterAsync(x => x.DataOraIniMezzo >= dateStart && x.DataOraFineMezzo <= dateEnd, 1, 0, "DataOraIniMezzo", "OrderByDescending");
            return view;
        }

        public async Task<PagedList<ViewGaPrevisioOdsServiziReport>> GetViewGaPrevisioOdsServiziReportByDateAsync(DateTime dateStart, DateTime dateEnd)
        {
            var view = await viewPrevisioOdsServiziReportRepo
            .GetWithFilterAsync(x => x.DataOraIniMezzo >= dateStart && x.DataOraFineMezzo <= dateEnd, 1, 0, "DataOraIniMezzo","OrderByDescending");
            return view;
        }


        #endregion

        #region DetailedEventReport
        public async Task<PagedList<DetailedEventsType>> GetDetailedEventsTypeAsync(string userId, List<EventsType> events)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventsType, DetailedEventsType>());
            var mapper = new Mapper(config);

            var list = new List<DetailedEventsType>();
            var returnList= new PagedList<DetailedEventsType>();

            int index = 0;
            DownloadProgressDto progress = new DownloadProgressDto();


            foreach (var item in events)
            {
                index++;
                progress.message = string.Format("Elaborazione Eventi {0}/{1}", index, events.Count());
                progress.progress = (Int32)(((Double)index / (Double)events.Count()) * 100);

                await hub.Clients.Groups(userId).DownloadProgress(progress);
                if (item.description == "Lettura UHF EPC" && item.info.Contains("Code:3"))
                {
                    var listItem = mapper.Map<DetailedEventsType>(item);
                    var cpAzi = "";
                    
                    var script = SqlContants.scriptGetDevice.Replace("@DTEVENT", item.dateTime.ToString("yyyyMMdd"));
                    script=script.Replace("@IDENTI1", item.info.Replace("Code:", ""));

                    var device = await _queryManager.ExecCSQueryAsync(script);

                    if (device != null && device.Count() > 0)
                    {
                        dynamic objProp = device[0];
                        foreach (KeyValuePair<string, object> property in objProp)
                        {
                            if (property.Key == "AZIENDA") { cpAzi = property.Value.ToString(); }
                        }
                        var utenza = await _queryManager.ExecCSQueryAsync("" +
                            "SELECT TOP 1 '"+cpAzi+"' AS AZIENDA, RTRIM(C.IDENTI1) AS IDENTI1, " +
                            "RTRIM(T.INDENTI1) AS ID1, RTRIM(T.INDENTI2) AS ID2, RTRIM(T.STATO) AS STATO, RTRIM(T.TIPCON) AS TIPCON, TIP.DESCON," +
                            "C.DTRIT,C.DTCON," +
                            "CONCAT(TRIM(F.RAGSO1),' ',TRIM(F.RAGSO2)) RAGSO," +
                            "A.COMUNE," +
                            "CONCAT(TRIM(A.DESVIA),' - ',TRIM(A.NUMCIV)) INDIRIZZO," +
                            "A.PARTITA,A.NUMCON " +
                            "FROM (SELECT TOP 1 * FROM "+cpAzi+"M_DTTIC WHERE TRIM(IDENTI1)='"+ item.info.Replace("Code:", "") + "') C " +
                            "LEFT JOIN FCTABARCCONT T ON C.IDENTI1 = T.INDENTI1 " +
                            "INNER JOIN " + cpAzi + "M_DTTIA A ON A.NUMCON=C.NUMCON AND C.PRGCON=A.CPROWNUM " +
                            "INNER JOIN FCTIPCOT TIP ON TIP.TIPCON=T.TIPCON " +
                            "INNER JOIN " + cpAzi + "M_TSCON CON ON CON.NUMCON=A.NUMCON " +
                            "INNER JOIN " + cpAzi + "FCCLIFAT F ON F.CODCLI=CON.CODCOM");
                        if (utenza != null && utenza.Count() > 0)
                        {
                            dynamic objProp2 = utenza[0];
                            foreach (KeyValuePair<string, object> property in objProp2)
                            {

                                switch (property.Key)
                                {
                                    case "IDENTI1":
                                        listItem.tag = property.Value.ToString();
                                        break;
                                    case "ID2":
                                        listItem.matricola = property.Value.ToString();
                                        break;
                                    case "RAGSO":
                                        listItem.utenza = property.Value.ToString();
                                        break;
                                    case "COMUNE":
                                        listItem.comune = property.Value.ToString();
                                        break;
                                    case "INDIRIZZO":
                                        listItem.indirizzo = property.Value.ToString();
                                        break;
                                    case "NUMCON":
                                        listItem.numCon = property.Value.ToString();
                                        break;
                                    case "PARTITA":
                                        listItem.partita = property.Value.ToString();
                                        break;
                                    case "DESCON":
                                        listItem.tipoContenitore = property.Value.ToString();
                                        break;
                                    case "TAG":
                                        listItem.tag = property.Value.ToString();
                                        break;
                                    case "MATRICOLA":
                                        listItem.matricola = property.Value.ToString();
                                        break;
                                }

                            }

                            returnList.Data.Add(listItem);
                        }
                        else
                        {
                            listItem.tag = "Nessuna utenza associata";
                            returnList.Data.Add(listItem);
                        }

                    }
                    else
                    {
                        listItem.tag = "Non esiste nessun contenitore con questo TAG.";
                        returnList.Data.Add(listItem);
                    }


                    //var entities=await _queryManager.ExecCSQueryAsync(string.Format("SELECT TOP 1 * FROM ViewBackOfficeLetture WHERE TRIM(Identi1)='{0}' AND '{1}' BETWEEN DTCON AND DTRIT", item.info.Replace("Code:", ""), item.dateTime.ToString("yyyyMMdd")));

                    //if (entities != null && entities.Count > 0)
                    //{
                    //    dynamic objProp = entities[0];
                    //    foreach (KeyValuePair<string, object> property in objProp)
                    //    {

                    //        switch (property.Key)
                    //        {
                    //            case "IDENTI1":
                    //                listItem.tag = property.Value.ToString();
                    //                break;
                    //            case "ID2":
                    //                listItem.matricola = property.Value.ToString();
                    //                break;
                    //            case "RAGSO":
                    //                listItem.utenza = property.Value.ToString();
                    //                break;
                    //            case "COMUNE":
                    //                listItem.comune = property.Value.ToString();
                    //                break;
                    //            case "INDIRIZZO":
                    //                listItem.indirizzo = property.Value.ToString();
                    //                break;
                    //            case "NUMCON":
                    //                listItem.numCon = property.Value.ToString();
                    //                break;
                    //            case "PARTITA":
                    //                listItem.partita = property.Value.ToString();
                    //                break;
                    //            case "DESCON":
                    //                listItem.tipoContenitore = property.Value.ToString();
                    //                break;
                    //        }

                    //    }

                    //    returnList.Data.Add(listItem);
                    //}
                    //else
                    //{
                    //    listItem.tag = "Nessuna utenza associata";
                    //    returnList.Data.Add(listItem);
                    //}
                    



                    //var dispositivo = await viewBackOfficeUtenzeDispositiviRepo.GetSingleWithFilter(x => x.Identi1.Trim() == item.info.Replace("Code:", "").Trim());
                    //if (dispositivo != null)
                    //{
                    //    var partita = await viewBackOfficeUtenzePartiteRepo.GetSingleWithFilter(x => x.NumCon == dispositivo.NumCon && x.Partita == dispositivo.Partita && x.CpAzi == dispositivo.CpAzi);
                    //    if (partita != null)
                    //    {
                    //        var utenza = await viewBackOfficeUtenzeRepo.GetSingleWithFilter(x => x.NumCon == partita.NumCon && x.CpAzi == partita.CpAzi);

                    //        listItem.utenza = utenza.RagSo;
                    //        listItem.numCon = partita.NumCon;
                    //        listItem.partita = partita.Partita;
                    //        listItem.indirizzo = string.Concat(partita.DesVia, "-", partita.NumCiv);
                    //        listItem.comune = partita.Comune;

                    //        returnList.Data.Add(listItem);
                    //    }
                    //    else
                    //    {
                    //        listItem.partita = "Nessuna partita trovata.";
                    //        returnList.Data.Add(listItem);

                    //    }
                    //}
                    //else
                    //{
                    //    listItem.tipoContenitore = "Nessun conenitore trovato.";
                    //    returnList.Data.Add(listItem);
                    //}

                }
            }

            returnList.PageSize = 0;
            returnList.TotalCount = returnList.Data.Count();

            return returnList;
        }

        #endregion

        #region PrevisioAnomalieLetture
        public async Task<PrevisioAnomalieLettureDto> GetGaPrevisioAnomalieLettureAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaPrevisioAnomalieLettureRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<PrevisioAnomalieLettureDto, PagedList<PrevisioAnomaliaLettura>>();
            return dtos;
        }

        public async Task<PrevisioAnomaliaLetturaDto> GetGaPrevisioAnomaliaLetturaByIdAsync(long id)
        {
            var entity = await gaPrevisioAnomalieLettureRepo.GetByIdAsync(id);
            var dto = entity.ToDto<PrevisioAnomaliaLetturaDto, PrevisioAnomaliaLettura>();
            return dto;
        }

        public async Task<long> AddGaPrevisioAnomaliaLetturaAsync(PrevisioAnomaliaLetturaDto dto)
        {
            var entity = dto.ToEntity<PrevisioAnomaliaLettura, PrevisioAnomaliaLetturaDto>();
            await gaPrevisioAnomalieLettureRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> AddOrUpdateGaPrevisioAnomaliaLetturaAsync(DetailedEventsType dto)
        {
            var entity = await gaPrevisioAnomalieLettureRepo.GetSingleWithFilter(x => x.Id == dto.id);
            if (entity != null)
            {
                entity.Tag = dto.tag;
                entity.Matricola = dto.matricola;
                entity.DataEvento = dto.dateTime;
                entity.TipoCont = dto.tipoContenitore;
                entity.Partita = dto.partita;
                entity.Contratto = dto.numCon;
                entity.Comune = dto.comune;
                entity.Latitudine = dto.xcoord;
                entity.Longitudine = dto.ycoord;
                entity.Indirizzo = dto.indirizzo;
                entity.Utenza = dto.utenza;
                gaPrevisioAnomalieLettureRepo.Update(entity);
                await SaveChanges();
                return entity.Id;
            }
            else
            {
                entity = dto.ToEntity<PrevisioAnomaliaLettura, DetailedEventsType>();
                await gaPrevisioAnomalieLettureRepo.AddAsync(entity);
                await SaveChanges();
                return entity.Id;
            }
        }

        public async Task<long> UpdateGaPrevisioAnomaliaLetturaAsync(PrevisioAnomaliaLetturaDto dto)
        {
            var entity = dto.ToEntity<PrevisioAnomaliaLettura, PrevisioAnomaliaLetturaDto>();
            gaPrevisioAnomalieLettureRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaPrevisioAnomaliaLetturaAsync(long id)
        {
            var entity = await gaPrevisioAnomalieLettureRepo.GetByIdAsync(id);
            gaPrevisioAnomalieLettureRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaPrevisioAnomaliaLetturaAsync(long id, string descrizione)
        {
            var entity = await gaPrevisioAnomalieLettureRepo.GetWithFilterAsync(x => x.Evento == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGestitoGaPrevisioAnomaliaLetturaAsync(long id)
        {
            var entity = await gaPrevisioAnomalieLettureRepo.GetByIdAsync(id);
            if (entity.Gestito)
            {
                entity.Gestito = false;
                gaPrevisioAnomalieLettureRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Gestito = true;
                gaPrevisioAnomalieLettureRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }

        //public async Task<bool> AddOrUpdateGaPrevisioAnomaliaLetturaAsync(DetailedEventsType model)
        //{

        //    try
        //    {
        //        var entities = await gaPrevisioAnomalieLettureRepo.GetWithFilterAsync(x => x.Id == model.id);
        //        if (entities.Data.Count > 0)
        //        {
        //            foreach (var itm in entities.Data)
        //            {
        //                gaPrevisioAnomalieLettureRepo.Remove(itm);
        //            }
        //            await SaveChanges();
        //        }

        //        var ripartizioni = await gaPrevisioAnomalieLettureRepo.GetWithFilterAsync(x => x.Id == model.id);

        //        foreach (var itm in ripartizioni.Data)
        //        {
        //            PrevisioAnomaliaLettura entity = new PrevisioAnomaliaLettura();
        //            entity.Id = 0;
        //            entity.Tag = model.tag;
        //            entity.DataEvento = model.dateTime;
        //            entity.Matricola = model.matricola;
        //            //entity.Percentuale = itm.Percentuale;
        //            //entity.Peso = (Convert.ToDouble(model.PesoTotale) / 100.00) * Convert.ToDouble(itm.Percentuale);
        //            //entity.CsrProduttoreId = itm.CsrProduttoreId;
        //            //entity.CsrRegistrazioneId = model.Id;
        //            //entity.CsrTrasportatoreId = model.CsrTrasportatoreId;

        //            await gaPrevisioAnomalieLettureRepo.AddAsync(entity);
        //        }

        //        await SaveChanges();


        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        await SaveChanges();
        //        throw;
        //    }
        //}

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
