using Microsoft.AspNetCore.Mvc.RazorPages;
using StormEye.Web.Models;       
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.RazorPages;
using StormEye.Web.Models;         

namespace StormEye.Web.Pages       
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
            var response = await client.GetFromJsonAsync<List<CatastrofeViewModel>>("api/Catastrofes");
            if (response != null)
                Catastrofes = response;
        }
    }
}
