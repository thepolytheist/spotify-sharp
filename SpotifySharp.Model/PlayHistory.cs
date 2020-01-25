using Newtonsoft.Json;
using System;

namespace SpotifySharp.Model
{
    public class PlayHistory
    {
        public TrackSimplified Track { get; set; }

        [JsonProperty("played_at")]
        public DateTime PlayedAt { get; set; }

        public Context Context { get; set; }
    }
}