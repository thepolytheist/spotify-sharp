using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SavedTrack
    {
        public DateTime AddedAt { get; set; }

        public Track Track { get; set; }
    }
}