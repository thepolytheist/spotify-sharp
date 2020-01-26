using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TrackLink
    {
        public Dictionary<string, string> ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}