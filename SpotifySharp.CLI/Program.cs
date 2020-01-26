using System.ComponentModel;
using System.IO.Pipes;
using System.Net.WebSockets;
using Newtonsoft.Json;
using SpotifySharp.Client;
using SpotifySharp.Client.Responses;
using SpotifySharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySharp.CLI
{
    class Program
    {
        const string SPOTIFY_AUTH_TOKEN_URI = "https://accounts.spotify.com/api/token";

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

                    try 
                    {
                        var client = new SpotifyClient(authResponse.AccessToken);
                        var albums = await client.Albums.Get(new string[]{ "41MnTivkwTO3UUJ8DrqEJJ","6JWc4iAiJ9FjyK0B59ABb4","6UXCm6bOO4gFlDQZV5yL37" });
                        foreach(var album in albums)
                        {
                            Console.WriteLine(album.Artists[0].Name + " - " + album.Name);
                        }
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"Error while executing API request: {e.Message}");
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
