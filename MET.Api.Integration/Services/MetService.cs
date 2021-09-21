using System.Threading.Tasks;

namespace MET.Api.Integration.Services
{
    public class MetService : IMetService
    {
        public Task<string> GetLocationForecast(string lat, string lon)
        {
            throw new System.NotImplementedException();
        }
    }
}