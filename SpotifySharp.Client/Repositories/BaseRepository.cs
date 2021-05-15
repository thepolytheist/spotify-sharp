using Newtonsoft.Json;
using SpotifySharp.Client.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
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
            HttpClient = httpClient;
            BaseUri = new Uri(baseAddress);
        }

        public BaseRepository(HttpClient httpClient, Uri baseUri)
        {
            HttpClient = httpClient;
            BaseUri = baseUri;
        }

        protected async Task<T> Get<T>(Uri path, IDictionary<string, string>? queryParams = null)
        {
            var queryString = DictionaryToQueryString(queryParams);

            var response = await HttpClient.GetAsync(path+queryString);
            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error.Message);
            }
        }

        private string DictionaryToQueryString(IDictionary<string, string>? dictionary)
        {
            if(dictionary is object && dictionary.Any())
            {
                var queryFragments = dictionary.Select(kvp => string.Join("=", Uri.EscapeUriString(kvp.Key), Uri.EscapeUriString(kvp.Value)));
                return $"?{string.Join("&", queryFragments)}";
            }
            
            return string.Empty;
        }
    }
}