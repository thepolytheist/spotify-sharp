using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PlayHistory
    {
        public TrackSimplified Track { get; set; }

        public DateTime PlayedAt { get; set; }

        public Context Context { get; set; }
    }
}