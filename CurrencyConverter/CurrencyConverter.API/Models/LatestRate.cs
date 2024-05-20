using System.Text.Json.Serialization;

namespace CurrencyConverter.API.Models;

public class LatestRate
{
    [JsonPropertyName("date")]
    [JsonPropertyOrder(3)]
    public string? Date { get; set; }

    [JsonPropertyName("rates")]
    [JsonPropertyOrder(4)]
    public Dictionary<string, decimal> Rates { get; set; }
        = new Dictionary<string, decimal>();
}
