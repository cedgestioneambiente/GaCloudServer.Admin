using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Constants;
using GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using static GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder.CustomEcoFinderDto;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaPrevisioService:IGaPrevisioService
    {
        protected readonly IQueryManager _queryManager;

        protected readonly IGenericRepository<ViewGaPrevisioOdsReport> viewPrevisioOdsReportRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewBackOfficeUtenzeDispositiviRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenzePartite> viewBackOfficeUtenzePartiteRepo;
        protected readonly IGenericRepository<ViewGaBackOfficeUtenze> viewBackOfficeUtenzeRepo;


        protected readonly IUnitOfWork unitOfWork;

        public GaPrevisioService(
            IQueryManager queryManager,

            IGenericRepository<ViewGaPrevisioOdsReport> viewPrevisioOdsReportRepo,
            IGenericRepository<ViewGaBackOfficeUtenzeDispositivi> viewBackOfficeUtenzeDispositiviRepo,
            IGenericRepository<ViewGaBackOfficeUtenzePartite> viewBackOfficeUtenzePartiteRepo,
            IGenericRepository<ViewGaBackOfficeUtenze> viewBackOfficeUtenzeRepo,

        IUnitOfWork unitOfWork)
        {
            this._queryManager = queryManager;

            this.viewPrevisioOdsReportRepo = viewPrevisioOdsReportRepo;
            this.viewBackOfficeUtenzeDispositiviRepo = viewBackOfficeUtenzeDispositiviRepo;
            this.viewBackOfficeUtenzePartiteRepo = viewBackOfficeUtenzePartiteRepo;
            this.viewBackOfficeUtenzeRepo = viewBackOfficeUtenzeRepo;

            this.unitOfWork = unitOfWork;

        }

        #region Previsio

        #region Views
        public async Task<PagedList<ViewGaPrevisioOdsReport>> GetViewGaPrevisioOdsReportByDateAsync(DateTime dateStart,DateTime dateEnd)
        {
            var view = await viewPrevisioOdsReportRepo
            .GetWithFilterAsync(x=>x.DataOraIniMezzo>=dateStart && x.DataOraFineMezzo<=dateEnd,1,0,"IDServizio");
            return view;
        }


        #endregion

        #region DetailedEventReport
        public async Task<PagedList<DetailedEventsType>> GetDetailedEventsTypeAsync(List<EventsType> events)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventsType, DetailedEventsType>());
            var mapper = new Mapper(config);

            var list = new List<DetailedEventsType>();
            var returnList= new PagedList<DetailedEventsType>();

            foreach (var item in events)
            {
                if (item.description == "Lettura UHF EPC" && item.info.Contains("Code:3"))
                {
                    var listItem = mapper.Map<DetailedEventsType>(item);
                    var script = SqlContants.scriptDecodeEvent.Replace("@dtEvent", item.dateTime.ToString("yyyyMMdd"));
                    script=script.Replace("@identi1", item.info.Replace("Code:", ""));


                    var entities=await _queryManager.ExecCSQueryAsync(string.Format("SELECT * FROM ViewBackOfficeLetture WHERE TRIM(Identi1)='{0}' AND '{1}' BETWEEN DTCON AND DTRIT", item.info.Replace("Code:", ""), item.dateTime.ToString("yyyyMMdd")));

                    if (entities != null && entities.Count > 0)
                    {
                        dynamic objProp = entities[0];
                        foreach (KeyValuePair<string, object> property in objProp)
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
                            }

                        }

                        returnList.Data.Add(listItem);
                    }
                    else
                    {
                        listItem.tag = "Nessuna utenza associata";
                        returnList.Data.Add(listItem);
                    }
                    



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
