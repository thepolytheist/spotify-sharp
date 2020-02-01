using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using SpotifySharp.Model;

namespace SpotifySharp.Client.Repositories
{
    public class RecommendationsRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "recommendations";
        
        public RecommendationsRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public RecommendationsRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public async Task<Recommendations> GetRecommendations()
        {
            return (await Get<Recommendations>(this.BaseUri))
        }
    }
}