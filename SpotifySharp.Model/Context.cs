using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    public class Context
    {
        [JsonProperty("externals_urls")]
        public Dictionary<string, string> ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}