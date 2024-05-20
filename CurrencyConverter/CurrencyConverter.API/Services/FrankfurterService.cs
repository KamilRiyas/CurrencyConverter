using CurrencyConverter.API.Interfaces;
using CurrencyConverter.API.Models;

namespace CurrencyConverter.API.Services;

public class FrankfurterService : IFrankfureterService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public FrankfurterService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("FrankfurterApi:BaseUrl")!);
    }

    public async Task<LatestRate?> ConvertCurrecyAsync(string fromCurrency, string toCurrency)
    {
        return await _httpClient.GetFromJsonAsync<LatestRate>($"latest?from={fromCurrency}&to={toCurrency}");
    }

    public async Task<HistoricalRate?> GetHistoricalRatesAsync(DateOnly fromDate, DateOnly toDate, string baseCurrency, int pageCount = 1, int pageSize = 10)
    {
        var pageStartDate = fromDate.AddDays(pageSize * (pageCount - 1));
        var pageEndDate = pageStartDate.AddDays(pageSize) > toDate ? toDate
            : pageStartDate.AddDays(pageSize - 1);

        return await _httpClient.GetFromJsonAsync<HistoricalRate>($"{pageStartDate.ToString("yyyy-MM-dd")}..{pageEndDate.ToString("yyyy-MM-dd")}?from={baseCurrency}");
    }

    public async Task<LatestRate?> GetLatestRateAsync(string baseCurrency)
    {
        return await _httpClient.GetFromJsonAsync<LatestRate>($"latest?from={baseCurrency}");       
    }
}
