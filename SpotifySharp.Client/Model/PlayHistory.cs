using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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