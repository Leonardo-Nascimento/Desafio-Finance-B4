using Newtonsoft.Json;

namespace Finance.B4.Domain.Dto
{
    [Serializable]
    public class AtivoDto
    {
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "exchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty(PropertyName = "instrumentType")]
        public string InstrumentType { get; set; }

        [JsonProperty(PropertyName = "firstTradeDate")]
        public long FirstTradeDate { get; set; }

        [JsonProperty(PropertyName = "regularMarketTime")]
        public long RegularMarketTime { get; set; }

        [JsonProperty(PropertyName = "gmtoffset")]
        public decimal Gmtoffset { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonProperty(PropertyName = "regularMarketPrice")]
        public decimal RegularMarketPrice { get; set; }

        [JsonProperty(PropertyName = "chartPreviousClose")]
        public double ChartPreviousClose { get; set; }

        [JsonProperty(PropertyName = "previousClose")]
        public double PreviousClose { get; set; }

        [JsonProperty(PropertyName = "scale")]
        public int Scale { get; set; }

        [JsonProperty(PropertyName = "priceHint")]
        public int PriceHint { get; set; }

        [JsonProperty(PropertyName = "dataGranularity")]
        public string DataGranularity { get; set; }

        [JsonProperty(PropertyName = "range")]
        public string Range { get; set; }

        [JsonProperty(PropertyName = "validRanges")]
        public IEnumerable<string> ValidRanges { get; set; }
    }
}
