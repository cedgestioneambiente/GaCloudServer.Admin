
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Recapiti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaRecapitiService:IGaRecapitiService
    {
        protected readonly IGenericRepository<ViewGaRecapitiContatti> viewGaRecapitiContattiRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaRecapitiService(

            IGenericRepository<ViewGaRecapitiContatti> viewGaRecapitiContattiRepo,

            IUnitOfWork unitOfWork)
        {


            this.viewGaRecapitiContattiRepo = viewGaRecapitiContattiRepo;


            this.unitOfWork = unitOfWork;

        }

        #region RecapitiContatti

        #region Views
        public async Task<PagedList<ViewGaRecapitiContatti>> GetViewGaRecapitiContattiAsync()
        {
            var view = await viewGaRecapitiContattiRepo.GetWithFilterAsync(x => x.ShowInContacts == true);
            return view;
        }

        public async Task<PagedList<ViewGaRecapitiContatti>> GetViewGaRecapitiContattiByFilterAsync(string filter)
        {
            var view = await viewGaRecapitiContattiRepo.GetWithFilterAsync(x => x.ShowInContacts == true && 
            (EF.Functions.Like(x.Nome,filter.toWildcardString()) ||
            EF.Functions.Like(x.Cognome,filter.toWildcardString()) ||
            EF.Functions.Like(x.Interno,filter.toWildcardString())||
            EF.Functions.Like(x.Cellulare,filter.toWildcardString()) ||
            EF.Functions.Like(x.Email,filter.toWildcardString())));
            return view;
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
