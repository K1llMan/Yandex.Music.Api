using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthLetterStatus : YAuthBase
    {
        [JsonProperty("magic_link_confirmed")]
        public bool MagicLinkConfirmed { get; set; }

        [JsonProperty("track_id")]
        public string TrackId { get; set; }
    }
}