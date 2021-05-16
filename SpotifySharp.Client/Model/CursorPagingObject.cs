using Newtonsoft.Json;

namespace SpotifySharp.Model
{
    public class CursorPagingObject<T> : PagingObject<T>
    {
        public Cursor Cursors { get; set; }
    }
}