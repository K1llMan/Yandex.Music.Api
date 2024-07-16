using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAccessToken
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("access_token")] 
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")] 
        public string Expires { get; set; }
        [JsonProperty("token_type")] 
        public string TokenType { get; set; }
        public string Uid { get; set; }
    }
}
