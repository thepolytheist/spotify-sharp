using SpotifySharp.Client.Repositories;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SpotifySharp.Client
{
    public class SpotifyClient
    {
        const string DEFAULT_BASE_ADDRESS = "https://api.spotify.com/v1/";

        Uri BaseUri { get; set; }
        HttpClient HttpClient { get; set; }
        string AccessToken { get; set; }

        public AlbumRepository Albums;
        public ArtistRepository Artists;
        public BrowseRepository Browse;
        public EpisodeRepository Episodes;
        public RecommendationsRepository Recommendations;

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

        private void CreateRepositories()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            Albums = new AlbumRepository(HttpClient, new Uri(BaseUri, AlbumRepository.DEFAULT_ENDPOINT));
            Artists = new ArtistRepository(HttpClient, new Uri(BaseUri, ArtistRepository.DEFAULT_ENDPOINT));
            Browse = new BrowseRepository(HttpClient, new Uri(BaseUri, BrowseRepository.DEFAULT_ENDPOINT));
            Episodes = new EpisodeRepository(HttpClient, new Uri(BaseUri, EpisodeRepository.DEFAULT_ENDPOINT));
            Recommendations = new RecommendationsRepository(HttpClient, new Uri(BaseUri, RecommendationsRepository.DEFAULT_ENDPOINT));
        }
    }
}