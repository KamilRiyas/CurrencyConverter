using CurrencyConverter.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace CurrencyConverter.API.Controllers;

[Route("api/")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly IFrankfureterService _frankfureterService;

    public CurrencyController(IFrankfureterService frankfureterService)
    {
        _frankfureterService = frankfureterService;
    }

    [HttpGet("latest")]
    [OutputCache]
    public async Task<ActionResult> GetLatestExchangeRatesAsync(string baseCurrency)
    {
        return Ok(await _frankfureterService.GetLatestRateAsync(baseCurrency));
    }

    [HttpGet("convert")]
    public async Task<ActionResult> ConvertCurrencyAsync(string fromCurrency, string toCurrency)
    {
        return Ok(await _frankfureterService.ConvertCurrecyAsync(fromCurrency, toCurrency));
    }

    [HttpGet("history")]
    public async Task<ActionResult> GetHistoricalRatesAsync(DateTime fromDate, DateTime toDate, string baseCurrency, int pageNumber=1, int pageSize = 10)
    {
        return Ok(await _frankfureterService.GetHistoricalRatesAsync(DateOnly.FromDateTime(fromDate), DateOnly.FromDateTime(toDate), baseCurrency, pageNumber, pageSize));
    }
}
