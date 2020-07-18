using System.Collections.Generic;

namespace SpotifySharp.Model
{
    public class Recommendations
    {
        public IList<RecommendationsSeed> Seeds { get; set; }

        public IList<TrackSimplified> Tracks { get; set; }
    }
}