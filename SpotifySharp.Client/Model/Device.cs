using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Device
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string? Id { get; set; }

        public bool IsActive { get; set; }

        public bool IsPrivateSession { get; set; }

        public bool IsRestricted { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DeviceType Type { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public int? VolumePercent { get; set; }
    }
}
