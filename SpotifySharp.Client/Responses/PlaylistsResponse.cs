namespace SpotifySharp.Client.Responses
{
    public class PlaylistsResponse<T>
    {
        public string Message { get; set; }

        public T Playlists { get; set; }
    }
}