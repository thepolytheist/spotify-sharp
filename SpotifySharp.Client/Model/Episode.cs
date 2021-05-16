using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Episode
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string? AudioPreviewUrl { get; set; }

        public string Description { get; set; }

        public int DurationMs { get; set; }

        public bool Explicit { get; set; }

        public IDictionary<string, string> ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public IList<Image> Images { get; set; }

        public bool IsExternallyHosted { get; set; }

        public bool IsPlayable { get; set; }

        public string Language { get; set; }

        public IList<string> Languages { get; set; }

        public string Name { get; set; }

        public string ReleaseDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ReleaseDatePrecision ReleaseDatePrecision { get; set; }

        public ResumePoint ResumePoint { get; set; }

        public ShowSimplified Show { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}
