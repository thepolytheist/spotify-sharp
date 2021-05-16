using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SpotifySharp.Model;

namespace SpotifySharp.Client.Responses
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class RecommendationsResponse
    {
        public IList<RecommendationsSeed> Seeds { get; set; }

        public IList<TrackSimplified> Tracks { get; set; }
    }
}
