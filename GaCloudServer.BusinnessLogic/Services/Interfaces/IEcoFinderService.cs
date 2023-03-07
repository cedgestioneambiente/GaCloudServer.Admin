using GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IEcoFinderService
    {
        Task<AuthenticationResponse> GetTokenAsync();
        Task<List<DevicesResponse>> GetDevices(string token);
        Task<DeviceDataResponse> GetDeviceData(string token, string deviceId, string dateStart, string dateEnd);
    }
}
