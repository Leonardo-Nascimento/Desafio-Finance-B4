using Finance.B4.Domain.Dto.JsonBruto;
using Newtonsoft.Json;

namespace Finance.B4.Domain.Dto.JsonBruto
{
    [Serializable]
    public class RootDto
    {
        [JsonProperty(PropertyName = "chart")]
        public ResultB3Dto Chart { get; set; }

    }
}
