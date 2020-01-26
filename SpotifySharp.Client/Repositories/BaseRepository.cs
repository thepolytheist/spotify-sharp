using System;
using System.Net.Http;

namespace SpotifySharp.Client.Repositories
{
    public class BaseRepository
    {
        public Uri BaseUri;
        public HttpClient HttpClient;

        public BaseRepository(HttpClient httpClient, string baseAddress)
        {
            this.HttpClient = httpClient;
            this.BaseUri = new Uri(baseAddress);
        }

        public BaseRepository(HttpClient httpClient, Uri baseUri)
        {
            this.HttpClient = httpClient;
            this.BaseUri = baseUri;
        }
    }
}