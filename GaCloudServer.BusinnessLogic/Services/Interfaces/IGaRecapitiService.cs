using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Recapiti.Views;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaRecapitiService
    {
        #region GaRecapitiContatti

        #region Views
        Task<PagedList<ViewGaRecapitiContatti>> GetViewGaRecapitiContattiAsync();
        #endregion
        #endregion
    }
}

