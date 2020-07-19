using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SavedShow
    {
        public DateTime AddedAt { get; set; }

        public ShowSimplified Show { get; set; }
    }
}