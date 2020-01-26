using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpotifySharp.Client.Responses
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class AuthorizationResponse
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public int ExpiresIn { get; set; }
    }
}