﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvestmentCalculator.src.Models
{
    public class CdiDay
    {
        [JsonPropertyName("data")]
        public string Date  { get; set; }
        
        [JsonPropertyName("valor")]
        public string Value { get; set; }
    }
}
