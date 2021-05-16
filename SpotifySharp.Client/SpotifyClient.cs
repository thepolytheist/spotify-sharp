using Newtonsoft.Json;
using SpotifySharp.Client.Repositories;
using SpotifySharp.Client.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySharp.Client
{
    public class SpotifyClient
    {
        const string DEFAULT_BASE_ADDRESS = "https://api.spotify.com/v1/";
        const string AUTH_TOKEN_URI = "https://accounts.spotify.com/api/token";

        Uri BaseUri { get; set; }
        HttpClient HttpClient { get; set; }
        string AccessToken { get; set; }

        public AlbumRepository Albums;
        public ArtistRepository Artists;
        public BrowseRepository Browse;
        public EpisodeRepository Episodes;
        public RecommendationsRepository Recommendations;

        private SearchRepository _search;

        public SpotifyClient(string accessToken, string baseAddress = DEFAULT_BASE_ADDRESS)
        {
            AccessToken = accessToken;
            BaseUri = new Uri(baseAddress);
            CreateRepositories();
        }

        public SpotifyClient(string accessToken, Uri baseUri)
        {
            AccessToken = accessToken;
            BaseUri = baseUri;
            CreateRepositories();
        }

        public static async Task<string> GetAccessToken(string clientId, string clientSecret)
        {
            using var authClient = new HttpClient();

                // Authorization header will always be the same
                authClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(string.Join(":", clientId, clientSecret)));

                var formContent = new Dictionary<string, string> {
                        { "grant_type", "client_credentials" }
                    };

                Console.WriteLine("Attempting to authenticate with Spotify...\n");
                var postResponse = await authClient.PostAsync(AUTH_TOKEN_URI, new FormUrlEncodedContent(formContent));
                postResponse.EnsureSuccessStatusCode();
                var authResponse = JsonConvert.DeserializeObject<AuthorizationResponse>(await postResponse.Content.ReadAsStringAsync());
                return authResponse.AccessToken;
        }

        public Task<SearchResponse> Search(string query, IEnumerable<string> types, string market = "", int? limit = null, int? offset = null, bool includeExternal = false)
        {
            return _search.Get(query, types, market, limit, offset, includeExternal);
        }

        private static string Base64Encode(string plainText) {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private void CreateRepositories()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            Albums = new AlbumRepository(HttpClient, new Uri(BaseUri, AlbumRepository.DEFAULT_ENDPOINT));
            Artists = new ArtistRepository(HttpClient, new Uri(BaseUri, ArtistRepository.DEFAULT_ENDPOINT));
            Browse = new BrowseRepository(HttpClient, new Uri(BaseUri, BrowseRepository.DEFAULT_ENDPOINT));
            Episodes = new EpisodeRepository(HttpClient, new Uri(BaseUri, EpisodeRepository.DEFAULT_ENDPOINT));
            Recommendations = new RecommendationsRepository(HttpClient, new Uri(BaseUri, RecommendationsRepository.DEFAULT_ENDPOINT));
            _search = new SearchRepository(HttpClient, new Uri(BaseUri, SearchRepository.DEFAULT_ENDPOINT));
        }
    }
}