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

        public SpotifyClient(string accessToken, string baseAddress = DEFAULT_BASE_ADDRESS)
        {
            this.AccessToken = accessToken;
            this.BaseUri = new Uri(baseAddress);
            this.CreateRepositories();
        }

        public SpotifyClient(string accessToken, Uri baseUri)
        {
            this.AccessToken = accessToken;
            this.BaseUri = baseUri;
            this.CreateRepositories();
        }

        private void CreateRepositories()
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);

            this.Albums = new AlbumRepository(this.HttpClient, new Uri(this.BaseUri, AlbumRepository.DEFAULT_ENDPOINT));
            this.Artists = new ArtistRepository(this.HttpClient, new Uri(this.BaseUri, ArtistRepository.DEFAULT_ENDPOINT));
        }
    }
}