using System;
using System.Net.Http;
using System.Threading.Tasks;
using SpotifySharp.Client;

namespace SpotifySharp.CLI
{
    class Program
    {
        const string CLIENT_ID = "420b7ddc45c54b659c4676e819f41181";
        const string CLIENT_SECRET = "8920e70270a34446800184821c456836";

        static async Task Main(string[] args)
        {
            try
            {
                var token = await SpotifyClient.GetAccessToken(CLIENT_ID, CLIENT_SECRET);

                try
                {
                    var client = new SpotifyClient(token);

                    var searchResponse = await client.Search("Coheed & Cambria", new string[] { "track" });
                    foreach(var track in searchResponse.Tracks.Items)
                    {
                        Console.WriteLine(track.Name);
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error while executing API request: {e.Message}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error while authenticating: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Uncaught error: {e}");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
