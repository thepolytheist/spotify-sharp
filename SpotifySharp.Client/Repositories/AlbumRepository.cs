using SpotifySharp.Client.Responses;
using SpotifySharp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifySharp.Client.Repositories
{
    public class AlbumRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "albums/";
        
        public AlbumRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public AlbumRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public Task<Album> Get(string id)
        {
            return Get<Album>(new Uri(BaseUri, id));
        }

        public async Task<List<Album>> Get(string[] ids)
        {
            return (await Get<AlbumsResponse<List<Album>>>(new Uri(BaseUri, $"?ids={string.Join(",", ids)}"))).Albums;
        }

        public Task<PagingObject<TrackSimplified>> GetTracks(Album album)
        {
            return GetTracks(album.Id);
        }

        public Task<PagingObject<TrackSimplified>> GetTracks(string id)
        {
            return Get<PagingObject<TrackSimplified>>(new Uri(BaseUri, $"{id}/tracks"));
        }
    }
}