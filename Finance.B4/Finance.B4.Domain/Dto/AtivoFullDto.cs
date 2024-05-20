using Newtonsoft.Json;

namespace Finance.B4.Domain.Dto
{
    [Serializable]
    public class AtivoFullDto
    {
        [JsonProperty(PropertyName = "meta")]
        public AtivoDto Ativo { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public IEnumerable<long> TimeStamps { get; set; }
    }
}
