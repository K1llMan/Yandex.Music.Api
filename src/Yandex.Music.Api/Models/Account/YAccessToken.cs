using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAccessToken
    {
        /*
         * 1-bundle-oauth-token_by_sessionid.json:
	     * Could not find member 'status' on object of type 'YAccessToken'. 
		 * Path 'status', line 1, position 10.
         */
        [JsonProperty("status")]
        public string Status { get; set; }
        //public YAuthStatus Status { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")]
        public string Expires { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        public string Uid { get; set; }
    }
}
