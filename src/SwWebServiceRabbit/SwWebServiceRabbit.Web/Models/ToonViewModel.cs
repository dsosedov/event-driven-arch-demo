using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SwWebServiceRabbit.Web.Data;

namespace SwWebServiceRabbit.Web.Models
{
    public class ToonViewModel
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Order Order { get; set; }
    }
}
