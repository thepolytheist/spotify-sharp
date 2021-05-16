using Newtonsoft.Json;

namespace SpotifySharp.Model
{
    public class Image
    {
        [JsonProperty(Required = Required.AllowNull)]
        public int? Height { get; set; }
        
        public string Url { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public int? Width { get; set; }
    }
}