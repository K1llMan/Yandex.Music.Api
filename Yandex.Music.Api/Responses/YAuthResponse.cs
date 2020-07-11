using Newtonsoft.Json;

namespace Yandex.Music.Api.Responses
{
    public class YAuthResponse
    {
        public string Uid { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public string Expires { get; set; }
    }
}
