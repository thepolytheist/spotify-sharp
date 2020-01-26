using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TrackSimplified
    {
        public List<ArtistSimplified> Artists { get; set; }

        public List<string> AvailableMarkets { get; set; }

        public int DiscNumber { get; set; }

        public int DurationMs { get; set; }

        public bool Explicit { get; set; }

        public Dictionary<string, string> ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public bool IsPlayable { get; set; }

        public TrackLink LinkedFrom { get; set; }

        public Restrictions Restrictions { get; set; }

        public string Name { get; set; }

        public string PreviewUrl { get; set; }

        public int TrackNumber { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }

        public bool IsLocal { get; set; }
    }
}