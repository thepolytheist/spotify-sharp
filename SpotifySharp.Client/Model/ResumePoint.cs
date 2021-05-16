using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ResumePoint
    {
        public bool FullyPlayed { get; set; }

        public int ResumePositionMs { get; set; }
    }
}
