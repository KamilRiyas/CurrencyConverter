using System.Text.Json.Serialization;

namespace CurrencyConverter.API.Models;

public class HistoricalRate
{
    [JsonPropertyName("start_date")]
    [JsonPropertyOrder(3)]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    [JsonPropertyOrder(4)]
    public string? EndDate { get; set; }

    [JsonPropertyName("rates")]
    [JsonPropertyOrder(5)]
    public Dictionary<string, Dictionary<string, decimal>> Rates { get; set; }
        = new Dictionary<string, Dictionary<string, decimal>>();
}
