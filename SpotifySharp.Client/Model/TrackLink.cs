using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TrackLink
    {
        public IDictionary<string, string> ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}