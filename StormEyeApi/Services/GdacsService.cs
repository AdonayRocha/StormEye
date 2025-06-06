using System.Xml.Linq;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using System.Text.Json;

public class GdacsService : IGdacsService
{
    private readonly HttpClient _httpClient;
    private readonly string _feedUrl;
    private readonly ILogger<GdacsService> _logger;

    public GdacsService(
        HttpClient httpClient,
        IConfiguration config,
        ILogger<GdacsService> logger)
    {
        _httpClient = httpClient;
        _feedUrl = config["Gdacs:FeedUrl"] ??
            throw new ArgumentException("Gdacs:FeedUrl não configurado");
        _logger = logger;

        // Configurações essenciais do HttpClient
        _httpClient.Timeout = TimeSpan.FromSeconds(15);
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36");
    }

    public async Task<string> GetActiveEventsJsonAsync()
    {
        try
        {
            // Configuração explícita de cabeçalhos
            var request = new HttpRequestMessage(HttpMethod.Get, _feedUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

            _logger.LogInformation($"Solicitando dados do GDACS: {_feedUrl}");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"Falha na requisição: {response.StatusCode}. Conteúdo: {errorContent}");
            }

            var xml = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Dados XML recebidos com sucesso");

            return ParseXmlToJson(xml);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Falha na obtenção de dados do GDACS");
            throw;
        }
    }

    private string ParseXmlToJson(string xml)
    {
        try
        {
            var xdoc = XDocument.Parse(xml);
            var channel = xdoc.Root?.Element("channel") ??
                throw new InvalidOperationException("Elemento <channel> não encontrado");

            var items = channel.Elements("item").Select(item => new
            {
                Title = (string)item.Element("title") ?? "",
                Link = (string)item.Element("link") ?? "",
                PubDate = (string)item.Element("pubDate") ?? "",
                Description = (string)item.Element("description") ?? "",
                Latitude = (string)item.Element(XName.Get("lat", "http://www.w3.org/2003/01/geo/wgs84_pos#")) ?? "",
                Longitude = (string)item.Element(XName.Get("long", "http://www.w3.org/2003/01/geo/wgs84_pos#")) ?? "",
                EventType = (string)item.Element("category") ?? "",
                Severity = (string)item.Element(XName.Get("alertlevel", "http://www.gdacs.org")) ?? ""
            }).ToList();

            return JsonSerializer.Serialize(new
            {
                ChannelTitle = (string)channel.Element("title") ?? "GDACS Events",
                RetrievedAt = DateTime.UtcNow,
                Items = items
            }, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Falha ao processar XML");
            throw new InvalidOperationException("Erro na conversão XML-JSON", ex);
        }
    }
}