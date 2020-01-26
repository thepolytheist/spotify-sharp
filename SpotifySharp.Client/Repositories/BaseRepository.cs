using Newtonsoft.Json;
using SpotifySharp.Client.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

        protected async Task<T> Get<T>(Uri path)
        {
            var response = await this.HttpClient.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error.Message);
            }
        }
    }
}