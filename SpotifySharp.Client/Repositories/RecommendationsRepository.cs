using SpotifySharp.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifySharp.Client.Repositories
{
    public class RecommendationsRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "recommendations";
        
        public RecommendationsRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public RecommendationsRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public Task<Recommendations> GetRecommendations()
        {
            return Get<Recommendations>(BaseUri);
        }
    }
}