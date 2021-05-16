using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SavedShow
    {
        public DateTime AddedAt { get; set; }

        public ShowSimplified Show { get; set; }
    }
}