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

        public IList<ArtistSimplified> Artists { get; set; }

        public IList<string> AvailableMarkets { get; set; }

        public IList<Copyright> Copyrights { get; set; }

        public IDictionary<string, string> ExternalIds { get; set; }

        public IDictionary<string, string> ExternalUrls { get; set; }

        public IList<string> Genres { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public IList<Image> Images { get; set; }

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