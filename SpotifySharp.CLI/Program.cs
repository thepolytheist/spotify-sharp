using System.Net;
using System.Text;
using System.Net.Http.Headers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using SpotifySharp.Model;
using SpotifySharp.Model.Responses;
using Newtonsoft.Json;

namespace SpotifySharp.CLI
{
    class Program
    {
        const string SPOTIFY_AUTH_TOKEN_URI = "https://accounts.spotify.com/api/token";
        const string SPOTIFY_API_BASE_URI = "https://api.spotify.com";

        const string CLIENT_ID = "YOUR ID HERE";
        const string CLIENT_SECRET = "YOUR SECRET HERE";

        static async Task Main(string[] args)
        {
            try
            {
                using(var authClient = new HttpClient())
                {
                    // Authorization header will always be the same
                    authClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(string.Join(":", CLIENT_ID, CLIENT_SECRET)));

                    var formContent = new Dictionary<string, string> {
                        { "grant_type", "client_credentials" }
                    };

                    Console.WriteLine("Attempting to authenticate with Spotify...\n");
                    var postResponse = await authClient.PostAsync(SPOTIFY_AUTH_TOKEN_URI, new FormUrlEncodedContent(formContent));
                    postResponse.EnsureSuccessStatusCode();
                    var authResponse = JsonConvert.DeserializeObject<AuthorizationResponse>(await postResponse.Content.ReadAsStringAsync());

                    using(var apiClient = new HttpClient())
                    {
                        apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.AccessToken);

                        var getResponse = await apiClient.GetAsync(SPOTIFY_API_BASE_URI + "/v1/artists/1vCWHaC5f2uS3yhpwWbIA6/albums?market=ES&include_groups=appears_on&limit=2");
                        getResponse.EnsureSuccessStatusCode();
                        var albumsResponse = JsonConvert.DeserializeObject<PagingObject<Album>>(await getResponse.Content.ReadAsStringAsync());
                        foreach(var album in albumsResponse.Items) {
                            Console.WriteLine($"{album.Name}\t{string.Join(", ", album.Artists.Select(a => a.Name).ToArray())}");
                        }
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error while authenticating: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Uncaught error: {e.Message}");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
