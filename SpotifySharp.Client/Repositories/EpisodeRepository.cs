using SpotifySharp.Client.Responses;
using SpotifySharp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifySharp.Client.Repositories
{
    public class EpisodeRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "episodes/";

        public EpisodeRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public EpisodeRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public Task<Episode> Get(string id, string market = "")
        {
            var queryParams = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(market)) queryParams.Add("market", market);

            return Get<Episode>(new Uri(BaseUri, id), queryParams);
        }

        public async Task<IList<Episode>> Get(IEnumerable<string> ids, string market = "")
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("ids", string.Join(",", ids));
            if (!string.IsNullOrEmpty(market)) queryParams.Add("market", market);
            
            return (await Get<EpisodesResponse<IList<Episode>>>(BaseUri, queryParams)).Episodes;
        }
    }
}
