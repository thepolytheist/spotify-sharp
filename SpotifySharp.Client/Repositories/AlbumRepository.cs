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
            var response = await this.HttpClient.GetAsync(new Uri(this.BaseUri, id));
            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Album>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error.Message);
            }
        }

        public async Task<List<Album>> Get(string[] ids)
        {
            var response = await this.HttpClient.GetAsync(new Uri(this.BaseUri, $"?ids={string.Join(",", ids)}"));
            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AlbumsResponse<List<Album>>>(await response.Content.ReadAsStringAsync()).Albums;
            }
            else
            {
                throw new Exception(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error.Message);
            }
        }

        public async Task<PagingObject<TrackSimplified>> GetTracks(Album album)
        {
            return await GetTracks(album.Id);
        }

        public async Task<PagingObject<TrackSimplified>> GetTracks(string id)
        {
            var response = await this.HttpClient.GetAsync(new Uri(this.BaseUri, $"{id}/tracks"));
            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagingObject<TrackSimplified>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error.Message);
            }
        }
    }
}