using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class UserPrivate
    {
        public string Country { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public IDictionary<string, string> ExternalUrls { get; set; }

        public Followers Followers { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public IList<Image> Images { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionLevel Product { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}