using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    public class AlbumSimplified
    {
        [JsonProperty("album_group")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AlbumGroup AlbumGroup { get; set; }

        [JsonProperty("album_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AlbumType AlbumType { get; set; }

        public List<ArtistSimplified> Artists { get; set; }

        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        [JsonProperty("externals_urls")]
        public Dictionary<string, string> ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public List<Image> Images { get; set; }

        public string Name { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("release_date_precision")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReleaseDatePrecision ReleaseDatePrecision { get; set; }

        public Restrictions Restrictions { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}