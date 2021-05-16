using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PlaylistTrack
    {
        [JsonProperty(Required = Required.AllowNull)]
        public DateTime? AddedAt { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public UserPublic? AddedBy { get; set; }

        public bool IsLocal { get; set; }

        public Track Track { get; set; }
    }
}