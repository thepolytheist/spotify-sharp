using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifySharp.Client.Responses;

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
                throw await GetExceptionFromResponse(response);
            }
        }

        protected async Task Put<T>(Uri path, T data, IDictionary<string, string>? queryParams = null)
        {
            var queryString = DictionaryToQueryString(queryParams);

            using(var content = JsonContent.Create<T>(data))
            {
                var response = await HttpClient.PutAsync(path+queryString, content);
                if(!response.IsSuccessStatusCode)
                {
                    throw await GetExceptionFromResponse(response);
                }
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

        private async Task<Exception> GetExceptionFromResponse(HttpResponseMessage response)
        {
            return new Exception(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error.Message);
        }
    }
}