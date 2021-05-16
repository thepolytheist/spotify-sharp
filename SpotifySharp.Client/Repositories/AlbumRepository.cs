using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<Album> Get(string id, string market = "")
        {
            if(!string.IsNullOrEmpty(market)) 
            {
                var queryParams = new Dictionary<string, string>();
                queryParams.Add("market", market);
                return Get<Album>(new Uri(BaseUri, id), queryParams);
            }

            return Get<Album>(new Uri(BaseUri, id));
        }

        public async Task<IList<Album>> Get(IEnumerable<string> ids, string market = "")
        {
            if(ids.Count() > 20) {
                throw new ArgumentException("A maximum of 20 album IDs may be retrieved at once.");
            }

            var queryParams = new Dictionary<string, string>();
            queryParams.Add("ids", string.Join(",", ids));
            if(!string.IsNullOrEmpty(market)) queryParams.Add("market", market);
            
            return (await Get<AlbumsResponse<IList<Album>>>(BaseUri, queryParams)).Albums;
        }

        public Task<PagingObject<TrackSimplified>> GetTracks(Album album, string market = "", int? limit = null, int? offset = null)
        {
            return GetTracks(album.Id, market, limit, offset);
        }

        public Task<PagingObject<TrackSimplified>> GetTracks(string id, string market = "", int? limit = null, int? offset = null)
        {
            var queryParams = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(market)) queryParams.Add("market", market);
            if(limit.HasValue) queryParams.Add("limit", limit.ToString());
            if(offset.HasValue) queryParams.Add("offset", offset.ToString());

            return Get<PagingObject<TrackSimplified>>(new Uri(BaseUri, $"{id}/tracks"), queryParams);
        }
    }
}