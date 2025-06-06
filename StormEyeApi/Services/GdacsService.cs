using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StormEyeApi.Services
{
    /// <summary>
    /// Implementa a chamada HTTP ao GDACS e retorna o JSON bruto.
    /// </summary>
    public class GdacsService : IGdacsService
    {
        private readonly HttpClient _httpClient;

        public GdacsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetActiveEventsJsonAsync()
        {
            // Chama: https://www.gdacs.org/gdacsapi/api/events/getactivesearch?format=json
            var response = await _httpClient.GetAsync("events/getactivesearch?format=json");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
