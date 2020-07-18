using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Playlist
    {
        public bool Collaborative { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string? Description { get; set; }

        public Dictionary<string, string> ExternalUrls { get; set; }

        public Followers Followers { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public IList<Image> Images { get; set; }

        public string Name { get; set; }

        public UserPublic Owner { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool? Public { get; set; }

        public string SnapshotId { get; set; }

        public PagingObject<PlaylistTrack> Tracks { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}