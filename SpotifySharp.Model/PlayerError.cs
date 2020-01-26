using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifySharp.Model
{
    public class PlayerError
    {
        public int Status { get; set; }
        
        public string Message { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PlayerErrorReason Reason { get; set; }
    }
}