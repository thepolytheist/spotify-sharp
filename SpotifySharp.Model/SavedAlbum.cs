using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SavedAlbum
    {
        public DateTime AddedAt { get; set; }

        public Album Album { get; set; }
    }
}