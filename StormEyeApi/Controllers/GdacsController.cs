using Microsoft.AspNetCore.Mvc;
using StormEyeApi.Services;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StormEyeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GdacsController : ControllerBase
    {
        private readonly IGdacsService _gdacsService;

        public GdacsController(IGdacsService gdacsService)
        {
            _gdacsService = gdacsService;
        }

        /// <summary>
        /// GET /api/gdacs/last
        /// Retorna apenas o último evento ativo listado no JSON do GDACS.
        /// </summary>
        [HttpGet("last")]
        public async Task<IActionResult> GetLastEvent()
        {
            try
            {
                var rawJson = await _gdacsService.GetActiveEventsJsonAsync();

                using var doc = JsonDocument.Parse(rawJson);
                var root = doc.RootElement;

                JsonElement arrayElement;

                if (root.ValueKind == JsonValueKind.Array)
                {
                    arrayElement = root;
                }
                else if (root.TryGetProperty("features", out var features))
                {
                    arrayElement = features;
                }
                else if (root.TryGetProperty("entries", out var entries))
                {
                    arrayElement = entries;
                }
                else if (root.TryGetProperty("events", out var eventsProp))
                {
                    arrayElement = eventsProp;
                }
                else
                {
                    return Content(rawJson, "application/json");
                }

                if (arrayElement.GetArrayLength() == 0)
                    return NoContent();

                var lastIndex = arrayElement.GetArrayLength() - 1;
                var lastEvent = arrayElement[lastIndex];

                return Content(lastEvent.GetRawText(), "application/json");
            }
            catch (HttpRequestException ex)
            {

                return StatusCode(503, new { error = "Não foi possível obter dados do GDACS", details = ex.Message });
            }
        }
    }
}
