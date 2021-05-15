using SpotifySharp.Client.Responses;
using SpotifySharp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifySharp.Client.Repositories
{
    public class SearchRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "search/";

        public SearchRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public SearchRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public Task<SearchResponse> Get(string query, IEnumerable<string> types, string market = "", int? limit = null, int? offset = null, bool includeExternal = false)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("q", query);
            queryParams.Add("type", string.Join(",", types));
            if(!string.IsNullOrEmpty(market)) queryParams.Add("market", market);
            if(limit.HasValue) queryParams.Add("limit", limit.ToString());
            if(offset.HasValue) queryParams.Add("offset", offset.ToString());
            if(includeExternal) queryParams.Add("include_external", "audio");

            return Get<SearchResponse>(BaseUri, queryParams);
        }
    }
}
