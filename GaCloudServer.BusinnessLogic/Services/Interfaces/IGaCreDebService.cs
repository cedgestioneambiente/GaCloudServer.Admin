using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.Shared;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaCreDebService
    {
        // CreDeb

        #region Conti
        public Task<PageResponse<CreDebContoDto>> GetCreDebContiAsync(PageRequest request);
        public Task<CreDebContoDto> GetCreDebContoByIdAsync(long id);
        public Task<long> CreateCreDebContoAsync(CreDebContoDto model);
        public Task<long> UpdateCreDebContoAsync(long id, CreDebContoDto model);
        public Task<bool> DeleteCreDebContoAsync(long id);
        #endregion

        #region Canali
        public Task<PageResponse<CreDebCanaleDto>> GetCreDebCanaliAsync(PageRequest request);
        public Task<CreDebCanaleDto> GetCreDebCanaleByIdAsync(long id);
        public Task<long> CreateCreDebCanaleAsync(CreDebCanaleDto model);
        public Task<long> UpdateCreDebCanaleAsync(long id, CreDebCanaleDto model);
        public Task<bool> DeleteCreDebCanaleAsync(long id);
        #endregion

        #region IncassiInObject
        public Task<PageResponse<CreDebIncassiInObjectDto>> GetCreDebIncassiInObjectsAsync(PageRequest request);
        public Task<CreDebIncassiInObjectDto> GetCreDebIncassiInObjectByIdAsync(long id);
        public Task<long> CreateCreDebIncassiInObjectAsync(CreDebIncassiInObjectDto model);
        public Task<long> UpdateCreDebIncassiInObjectAsync(long id, CreDebIncassiInObjectDto model);
        public Task<bool> DeleteCreDebIncassiInObjectAsync(long id);

        #region Functions
        public Task<bool> UpdateCreDebIncassiInObjectContabAsync(long id);
        #endregion

        #endregion

        #region IncassiInObjectDetails
        public Task<PageResponse<CreDebIncassiInObjectDetailDto>> GetCreDebIncassiInObjectDetailsAsync(PageRequest request);
        public Task<CreDebIncassiInObjectDetailDto> GetCreDebIncassiInObjectDetailByIdAsync(long id);
        public Task<long> CreateCreDebIncassiInObjectDetailAsync(CreDebIncassiInObjectDetailDto model);
        public Task<long> UpdateCreDebIncassiInObjectDetailAsync(long id, CreDebIncassiInObjectDetailDto model);
        public Task<bool> DeleteCreDebIncassiInObjectDetailAsync(long id);
        public Task<bool> DeleteCreDebIncassiInObjectDetailByObjectIdAsync(long id);
        #endregion

        #region Export
        public Task<string> GenerateCreDebRecordTextFileAsync(long id, List<CreDebIncassiExportResponseApiDto> defaultRecord, List<CreDebIncassiExportResponseApiDto> ritenuteRecord, bool newProcedure=false);
        #endregion
    }
}