using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthBase
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}