using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Album
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public AlbumType AlbumType { get; set; }

        public List<ArtistSimplified> Artists { get; set; }

        public List<string> AvailableMarkets { get; set; }

        public List<Copyright> Copyrights { get; set; }

        public Dictionary<string, string> ExternalIds { get; set; }

        public Dictionary<string, string> ExternalUrls { get; set; }

        public List<string> Genres { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public List<Image> Images { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public string ReleaseDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ReleaseDatePrecision ReleaseDatePrecision { get; set; }

        public Restrictions Restrictions { get; set; }

        public PagingObject<TrackSimplified> Tracks { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}