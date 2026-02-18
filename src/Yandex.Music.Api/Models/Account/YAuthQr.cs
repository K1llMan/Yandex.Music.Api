using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthQR : YAuthBase
    {
        [JsonProperty("track_id")]
        public string TrackId { get; set; }

        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }
    }
}
