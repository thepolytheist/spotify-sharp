using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Artist
    {
        public Dictionary<string, string> ExternalUrls { get; set; }

        public Followers Followers { get; set; }

        public IList<string> Genres { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public IList<Image> Images { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}