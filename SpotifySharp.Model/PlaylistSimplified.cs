using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    public class PlaylistSimplified
    {
        public bool Collaborative { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string? Description { get; set; }

        [JsonProperty("externals_urls")]
        public Dictionary<string, string> ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public List<Image> Images { get; set; }

        public string Name { get; set; }

        public UserPublic Owner { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool? Public { get; set; }

        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; set; }

        public Tracks Tracks { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}