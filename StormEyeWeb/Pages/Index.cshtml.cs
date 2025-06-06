using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using StormEyeWeb;
using StormEyeWeb.Models;

namespace StormEyeWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public List<CatastrofeViewModel> Catastrofes { get; set; } = new();

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("StormEyeAPI");

            // Chama GET https://localhost:7137/api/Catastrofes
            var response = await client.GetFromJsonAsync<List<CatastrofeViewModel>>("api/Catastrofes");

            if (response != null)
            {
                Catastrofes = response;
            }
        }
    }
}
