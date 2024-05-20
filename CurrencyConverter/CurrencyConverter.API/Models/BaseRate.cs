using System.Text.Json.Serialization;

namespace CurrencyConverter.API.Models;

public class BaseRate
{
    [JsonPropertyName("amount")]
    [JsonPropertyOrder(1)]
    public decimal Amount { get; set; }

    [JsonPropertyName("base")]
    [JsonPropertyOrder(2)]
    public string? Base { get; set; }

}
