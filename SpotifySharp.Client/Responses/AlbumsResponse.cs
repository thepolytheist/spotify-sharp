namespace SpotifySharp.Client.Responses
{
    public class AlbumsResponse<T>
    {
        public string Message { get; set; }

        public T Albums { get; set; }
    }
}