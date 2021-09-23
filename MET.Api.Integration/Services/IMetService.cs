using MET.Api.Integration.Models;
using System.Threading.Tasks;

namespace MET.Api.Integration.Services
{
    public interface IMetService
    {
        Task<ForecastResponseModel> GetLocationForecast(string latitude, string longitude);
    }
}