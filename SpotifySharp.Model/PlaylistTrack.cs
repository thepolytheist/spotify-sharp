using Newtonsoft.Json;
using System;

namespace SpotifySharp.Model
{
    public class PlaylistTrack
    {
        [JsonProperty("added_at", Required = Required.AllowNull)]
        public DateTime? AddedAt { get; set; }

        [JsonProperty("added_by", Required = Required.AllowNull)]
        public UserPublic? AddedBy { get; set; }

        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }

        public Track Track { get; set; }
    }
}