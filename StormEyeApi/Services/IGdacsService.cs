using System.Threading.Tasks;

namespace StormEyeApi.Services
{
    /// <summary>
    /// Abstração para chamar a API externa do GDACS.
    /// </summary>
    public interface IGdacsService
    {
        /// <summary>
        /// Obtém o JSON completo de eventos ativos do GDACS.
        /// </summary>
        Task<string> GetActiveEventsJsonAsync();
    }
}
