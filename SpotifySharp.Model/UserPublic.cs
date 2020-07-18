using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class UserPublic
    {
        public string DisplayName { get; set; }

        public IDictionary<string, string> ExternalUrls { get; set; }

        public Followers Followers { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public IList<Image> Images { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}