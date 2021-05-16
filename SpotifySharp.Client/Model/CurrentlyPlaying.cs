using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CurrentlyPlaying<T>
    {
        public Context Context { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CurrentlyPlayingType CurrentlyPlayingType { get; set; }

        public bool IsPlaying { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public T Item { get; set; }

        public int ProgressMs { get; set; }

        public int Timestamp { get; set; }
    }
}
