using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StormEyeWeb.Pages.Alertas
{
    public class AlertasModel : PageModel
    {
        public List<GdacsAlerta> UltimosAlertas { get; set; } = new();

        public async Task OnGetAsync()
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync("https://www.gdacs.org/gdacsapi/api/events/geteventlist/MAP");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Aqui simplificamos a desserialização. Em produção, é ideal criar um modelo real do JSON.
                    using var doc = JsonDocument.Parse(content);
                    var root = doc.RootElement;
                    if (root.TryGetProperty("features", out var features))
                    {
                        int count = 0;
                        foreach (var item in features.EnumerateArray())
                        {
                            if (count++ >= 5) break;

                            var properties = item.GetProperty("properties");

                            UltimosAlertas.Add(new GdacsAlerta
                            {
                                Tipo = properties.GetProperty("eventtype").GetString(),
                                Data = properties.GetProperty("fromdate").GetString(),
                                Local = properties.GetProperty("country").GetString(),
                                Nivel = properties.GetProperty("alertlevel").GetString()
                            });
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }

    public class GdacsAlerta
    {
        public string Tipo { get; set; }
        public string Data { get; set; }
        public string Local { get; set; }
        public string Nivel { get; set; }
    }
}
