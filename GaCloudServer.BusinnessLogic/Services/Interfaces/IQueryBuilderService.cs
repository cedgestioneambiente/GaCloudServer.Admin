using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.QueryBuilder.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.QueryBuilder;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IQueryBuilderService
    {
        Task<List<object>> GetFromQueryAsync(string query);

        #region QueryBuilderParamTypes
        Task<QueryBuilderParamTypesDto> GetQueryBuilderParamTypesAsync(int page = 1, int pageSize = 0);
        Task<QueryBuilderParamTypeDto> GetQueryBuilderParamTypeByIdAsync(long id);

        Task<long> AddQueryBuilderParamTypeAsync(QueryBuilderParamTypeDto dto);
        Task<long> UpdateQueryBuilderParamTypeAsync(QueryBuilderParamTypeDto dto);

        Task<bool> DeleteQueryBuilderParamTypeAsync(long id);

        #region Functions
        Task<bool> ValidateQueryBuilderParamTypeAsync(long id, string descrizione);
        Task<bool> ChangeStatusQueryBuilderParamTypeAsync(long id);
        #endregion

        #endregion

        #region QueryBuilderSections
        Task<QueryBuilderSectionsDto> GetQueryBuilderSectionsAsync(int page = 1, int pageSize = 0);
        Task<QueryBuilderSectionDto> GetQueryBuilderSectionByIdAsync(long id);

        Task<long> AddQueryBuilderSectionAsync(QueryBuilderSectionDto dto);
        Task<long> UpdateQueryBuilderSectionAsync(QueryBuilderSectionDto dto);

        Task<bool> DeleteQueryBuilderSectionAsync(long id);

        #region Functions
        Task<bool> ValidateQueryBuilderSectionAsync(long id, string descrizione);
        Task<bool> ChangeStatusQueryBuilderSectionAsync(long id);
        #endregion

        #endregion

        #region QueryBuilderScripts
        Task<QueryBuilderScriptsDto> GetQueryBuilderScriptsAsync(int page = 1, int pageSize = 0);
        Task<QueryBuilderScriptDto> GetQueryBuilderScriptByIdAsync(long id);

        Task<long> AddQueryBuilderScriptAsync(QueryBuilderScriptDto dto);
        Task<long> UpdateQueryBuilderScriptAsync(QueryBuilderScriptDto dto);

        Task<bool> DeleteQueryBuilderScriptAsync(long id);

        #region Functions
        Task<bool> ValidateQueryBuilderScriptAsync(long id, string descrizione);
        Task<bool> ChangeStatusQueryBuilderScriptAsync(long id);
        #endregion

        #endregion

        #region QueryBuilderParamOnScripts
        Task<QueryBuilderParamOnScriptsDto> GetQueryBuilderParamOnScriptsAsync(int page = 1, int pageSize = 0);
        Task<QueryBuilderParamOnScriptsDto> GetQueryBuilderParamOnScriptsByScriptIdAsync(long scriptId);
        Task<QueryBuilderParamOnScriptDto> GetQueryBuilderParamOnScriptByIdAsync(long id);

        Task<long> AddQueryBuilderParamOnScriptAsync(QueryBuilderParamOnScriptDto dto);
        Task<long> UpdateQueryBuilderParamOnScriptAsync(QueryBuilderParamOnScriptDto dto);

        Task<bool> DeleteQueryBuilderParamOnScriptAsync(long id);

        #region Functions
        Task<bool> ValidateQueryBuilderParamOnScriptAsync(long id,long scriptId, string descrizione);
        Task<bool> ChangeStatusQueryBuilderParamOnScriptAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewQueryBuilderParamOnScripts>> GetViewQueryBuilderParamOnScriptsByScriptIdAsync(long scriptId);
        Task<PagedList<ViewQueryBuilderScripts>> GetViewQueryBuilderScriptsAsync();
        Task<PagedList<ViewQueryBuilderScripts>> GetViewQueryBuilderScriptsByRolesAsync(string roles);
        #endregion
        #endregion



    }
}
