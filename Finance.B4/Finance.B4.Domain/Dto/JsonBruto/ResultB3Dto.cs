using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.B4.Domain.Dto.JsonBruto
{
    [Serializable]
    public class ResultB3Dto
    {
        [JsonProperty(PropertyName = "result")]
        public List<AtivoFullDto> Result { get; set; }
        public object error { get; set; }
    }
}
