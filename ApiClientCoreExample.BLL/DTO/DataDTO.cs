using Newtonsoft.Json;

namespace ApiClientCoreExample.BLL.DTO
{
    public class DataDTO
    {
        [JsonProperty("time")]
        public decimal Time { get; set; }

        [JsonProperty("lastSeen")]
        public decimal LastSeen { get; set; }

        [JsonProperty("reportedHashrate")]
        public decimal ReportedHashrate { get; set; }

        [JsonProperty("averageHashrate")]
        public decimal AverageHashrate { get; set; }

        [JsonProperty("currentHashrate")]
        public decimal CurrentHashrate { get; set; }

        [JsonProperty("validShares")]
        public decimal ValidShares { get; set; }

        [JsonProperty("invalidShares")]
        public decimal InvalidShares { get; set; }

        [JsonProperty("staleShares")]
        public decimal StaleShares { get; set; }

        [JsonProperty("activeWorkers")]
        public decimal ActiveWorkers { get; set; }

        [JsonProperty("unpaid")]
        public decimal Unpaid { get; set; }

        [JsonProperty("unconfirmed")]
        public decimal Unconfirmed { get; set; }

        [JsonProperty("coinsPerMin")]
        public decimal CoinsPerMin { get; set; }

        [JsonProperty("usdPerMin")]
        public decimal UsdPerMin { get; set; }

        [JsonProperty("btcPerMin")]
        public decimal BtcPerMin { get; set; }
    }
}
