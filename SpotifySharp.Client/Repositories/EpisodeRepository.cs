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

        public Task<Episode> Get(string id)
        {
            return Get<Episode>(new Uri(BaseUri, id));
        }

        public async Task<IList<Episode>> Get(string[] ids)
        {
            return (await Get<EpisodesResponse<IList<Episode>>>(new Uri(BaseUri, $"?ids={string.Join(",", ids)}"))).Episodes;
        }
    }
}
