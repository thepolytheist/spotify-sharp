using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpotifySharp.Model
{
    public class PagingObject<T>
    {
        public string Href { get; set; }
        public IList<T> Items { get; set; }
        public int Limit { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string? Next { get; set; }
        public int Offset { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string? Previous { get; set; }

        public int Total { get; set; }
    }
}