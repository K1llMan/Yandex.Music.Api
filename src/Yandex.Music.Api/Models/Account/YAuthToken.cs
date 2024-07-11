using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthToken
    {
        [JsonProperty("csfr_token")]
        public string CsfrToken { get; set; }

        [JsonProperty("track_id")]
        public string TrackId { get; set; }
    }
}
