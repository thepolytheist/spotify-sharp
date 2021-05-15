using SpotifySharp.Model;

namespace SpotifySharp.Client.Responses
{
    public class SearchResponse
    {
        public PagingObject<AlbumSimplified>? Albums { get; set; }

        public PagingObject<Artist>? Artists { get; set; }

        public PagingObject<EpisodeSimplified>? Episodes { get; set; }

        public PagingObject<PlaylistSimplified>? Playlists { get; set; }

        public PagingObject<ShowSimplified>? Shows { get; set; }

        public PagingObject<Track>? Tracks { get; set; }
    }
}