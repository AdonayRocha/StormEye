public interface IGdacsService
{
    /// <summary>
    /// Obtém eventos ativos do GDACS em formato JSON
    /// </summary>
    /// <returns>JSON serializado com estrutura padronizada</returns>
    /// <exception cref="ApplicationException">
    /// Lançada em falhas de comunicação ou parsing
    /// </exception>
    Task<string> GetActiveEventsJsonAsync();
}