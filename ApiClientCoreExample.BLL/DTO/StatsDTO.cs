using Newtonsoft.Json;


namespace ApiClientCoreExample.BLL.DTO
{
    public class StatsDTO
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("data")]
        public DataDTO Data { get; set; }
    }
}
