using System.Collections.Generic;

namespace SpotifySharp.Model
{
    public class Recommendations
    {
        public List<RecommendationsSeed> Seeds { get; set; }

        public List<TrackSimplified> Tracks { get; set; }
    }
}