using MET.Api.Integration.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MET.Api.Integration.Services
{
    public class MetService : IMetService
    {
        public IHttpClientFactory _client { get; set; }
        public MetService(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<ForecastResponseModel> GetLocationForecast(string latitude, string longitude)
        {
            var forecast = new ForecastResponseModel();
            try
            {
                var client = _client.CreateClient("met-api");
                var url = $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={latitude}&lon={longitude}";
                var response = await client.GetStringAsync(url);
                var forecastResponse = JsonConvert.DeserializeObject<ForecastResponseModel>(response);
                if(forecastResponse!= null)
                { 
                    forecast = forecastResponse;
                }
            }
            catch (Exception e)
            {
                //TODO: Log and handle exception
            }
            return forecast;
        }
    }
}