using CurrencyConverter.API.Models;
using System.Runtime.CompilerServices;

namespace CurrencyConverter.API.Interfaces;

public interface IFrankfureterService
{
    Task<LatestRate?> GetLatestRateAsync(string baseCurrency);
    Task<LatestRate?> ConvertCurrecyAsync(string fromCurrency, string toCurrency);
    Task<HistoricalRate?> GetHistoricalRatesAsync(DateOnly startDate, DateOnly endDate, string baseCurrency, int pageCount = 1, int pageSize = 10);
}
