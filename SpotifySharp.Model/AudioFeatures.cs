using Newtonsoft.Json;

namespace SpotifySharp.Model
{
    public class AudioFeatures
    {
        public float Acousticness { get; set; }

        [JsonProperty("analysis_url")]
        public string AnalysisUrl { get; set; }

        public float Danceability { get; set; }

        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        public float Energy { get; set; }

        public string Id { get; set; }

        public float Instrumentalness { get; set; }

        public int Key { get; set; }

        public float Liveness { get; set; }

        public float Loudness { get; set; }

        public int Mode { get; set; }

        public float Speechiness { get; set; }

        public float Tempo { get; set; }

        [JsonProperty("time_signature")]
        public int TimeSignature { get; set; }

        [JsonProperty("track_href")]
        public string TrackHref { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }

        public float Valence { get; set; }
    }
}