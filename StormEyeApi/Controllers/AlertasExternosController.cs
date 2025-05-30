using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StormEyeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasExternosController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AlertasExternosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("ultimos")]
        public async Task<IActionResult> GetUltimosAlertas()
        {
            var client = _httpClientFactory.CreateClient();

            var url = "https://www.gdacs.org/xml/rss.xml";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Erro ao acessar GDACS.");

            var xmlString = await response.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(xmlString);

            var alertas = xml.Descendants("item")
                .Take(5)
                .Select(item => new
                {
                    Titulo = item.Element("title")?.Value,
                    Descricao = item.Element("description")?.Value,
                    Link = item.Element("link")?.Value,
                    DataPublicacao = item.Element("pubDate")?.Value
                });

            return Ok(alertas);
        }
    }
}
