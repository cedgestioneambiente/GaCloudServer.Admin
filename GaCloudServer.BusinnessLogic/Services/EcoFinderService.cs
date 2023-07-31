using GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class EcoFinderService:IEcoFinderService
    {
        private readonly string username="ExtGestAmb";
        private readonly string password= "Ext01?GestAmb!";
        private readonly string EcoFinderBaseUri = "https://tellus.consorziocfa.it/ecofinder/services/extern/";

        public EcoFinderService()
        { }

        public async Task<AuthenticationResponse> GetTokenAsync()
        {
            string queryParams = "authentication?username="+username+"&password="+password+"";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(EcoFinderBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(queryParams);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsAsync<AuthenticationResponse>();
                    return token;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<DevicesResponse>> GetDevices(string token)
        {
            string queryParams = "devices?token=" + token;
            using (var client = new HttpClient())
            {
                var param = new List<string>() { "274", "275" };
                var json = JsonConvert.SerializeObject(param);
                var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


                client.BaseAddress = new Uri(EcoFinderBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync(queryParams, data);
                if (response.IsSuccessStatusCode)
                {
                    var devices = await response.Content.ReadAsAsync<List<DevicesResponse>>();
                    return devices;
                }
                else
                {
                    return null;
                }
            }

        }

        public async Task<DeviceDataResponse> GetDeviceData(string token, string deviceId, string dateStart, string dateEnd)
        {
            string queryParams = String.Format("devicedata?token={0}&deviceId={1}&dateStart={2}&dateEnd={3}", token, deviceId, dateStart, dateEnd);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(EcoFinderBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(queryParams);
                if (response.IsSuccessStatusCode)
                {
                    var deviceData = await response.Content.ReadAsAsync<DeviceDataResponse>();
                    return deviceData;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}
