using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Services
{
    public class SpaceXService
    {
        private readonly HttpClient _httpClient;

        public SpaceXService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Launch>> GetLaunchesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.spacexdata.com/v4/launches");
            return JsonConvert.DeserializeObject<List<Launch>>(response);
        }
    }
}
