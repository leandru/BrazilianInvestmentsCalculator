using System.Text.Json.Serialization;

namespace InvestmentCalculator.Business.Models
{
    public class CdiDay
    {
        [JsonPropertyName("data")]
        public string? Date  { get; set; }
        
        [JsonPropertyName("valor")]
        public string? Value { get; set; }
    }
}
