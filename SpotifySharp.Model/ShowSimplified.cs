using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ShowSimplified
    {
        public IList<string> AvailableMarkets { get; set; }

        public IList<Copyright> Copyrights { get; set; }

        public string Description { get; set; }

        public bool Explicit { get; set; }

        public IDictionary<string, string> ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public IList<Image> Images { get; set; }

        public bool IsExternallyHosted { get; set; }

        public IList<string> Languages { get; set; }

        public string MediaType { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public int TotalEpisodes { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}