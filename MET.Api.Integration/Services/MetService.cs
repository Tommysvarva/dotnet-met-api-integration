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
            try
            {
                var client = _client.CreateClient();

                var productValue = new ProductInfoHeaderValue("dotnet-met-api", "1.0");
                var commentValue = new ProductInfoHeaderValue("(+tase.contact@gmail.com)");
                client.DefaultRequestHeaders.UserAgent.Add(productValue);
                client.DefaultRequestHeaders.UserAgent.Add(commentValue);

                var url = $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={latitude}&lon={longitude}";
                var response = await client.GetStringAsync(url);
                var forecastResponse = JsonConvert.DeserializeObject<ForecastResponseModel>(response);
                if (forecastResponse != null)
                {
                    return forecastResponse;
                }
            }
            catch (Exception e)
            {
                //TODO: Log and handle exception
            }

            return null;
        }
    }
}