using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ExternalId
    {
        public string Ean { get; set; }

        public string Isrc { get; set; }

        public string Upc { get; set; }
    }
}
