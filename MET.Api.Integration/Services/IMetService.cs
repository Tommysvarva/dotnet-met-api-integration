using System.Threading.Tasks;

namespace MET.Api.Integration.Services
{
    public interface IMetService
    {
        Task<string> GetLocationForecast(string lat, string lon);
    }
}