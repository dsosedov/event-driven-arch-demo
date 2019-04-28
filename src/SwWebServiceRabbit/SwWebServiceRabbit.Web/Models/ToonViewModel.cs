using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SwWebServiceRabbit.Web.Models
{
    public class ToonViewModel
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Order Order { get; set; }
    }

    public enum Order
    {
        Jedi,
        Sith,
    }
}
