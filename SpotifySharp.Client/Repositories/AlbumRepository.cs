using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SpotifySharp.Client.Responses;
using SpotifySharp.Model;

namespace SpotifySharp.Client.Repositories
{
    public class AlbumRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "albums/";
        
        public AlbumRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public AlbumRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public async Task<Album> Get(string id)
        {
            return await Get<Album>(new Uri(this.BaseUri, id));
        }

        public async Task<List<Album>> Get(string[] ids)
        {
            return (await Get<AlbumsResponse<List<Album>>>(new Uri(this.BaseUri, $"?ids={string.Join(",", ids)}"))).Albums;
        }

        public async Task<PagingObject<TrackSimplified>> GetTracks(Album album)
        {
            return await GetTracks(album.Id);
        }

        public async Task<PagingObject<TrackSimplified>> GetTracks(string id)
        {
            return await Get<PagingObject<TrackSimplified>>(new Uri(this.BaseUri, $"{id}/tracks"));
        }
    }
}