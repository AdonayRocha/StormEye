using Microsoft.AspNetCore.Mvc;
using StormEye;

[ApiController]
[Route("api/[controller]")]
public class GdacsController : ControllerBase
{
    private readonly IGdacsService _gdacsService;
    private readonly ILogger<GdacsController> _logger;

    public GdacsController(
        IGdacsService gdacsService,
        ILogger<GdacsController> logger)
    {
        _gdacsService = gdacsService;
        _logger = logger;
    }

    [HttpGet("last")]
    public async Task<IActionResult> GetLastEvents()
    {
        try
        {
            var json = await _gdacsService.GetActiveEventsJsonAsync();
            return Content(json, "application/json");
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Falha na requisição GDACS");
            return StatusCode(503, new
            {
                error = "Serviço GDACS indisponível",
                details = ex.Message
            });
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Falha crítica");
            return StatusCode(500, new
            {
                error = "Erro interno de processamento",
                technicalDetails = ex.InnerException?.Message
            });
        }
    }
}