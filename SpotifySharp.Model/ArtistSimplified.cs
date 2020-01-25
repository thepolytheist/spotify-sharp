using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    public class ArtistSimplified
    {
        [JsonProperty("externals_urls")]
        public Dictionary<string, string> ExternalURLs { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}