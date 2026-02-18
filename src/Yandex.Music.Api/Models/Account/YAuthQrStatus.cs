using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthQRStatus : YAuthBase
    {
        [JsonProperty("default_uid")]
        public int DefaultUid { get; set; }

        public string RetPath { get; set; }

        [JsonProperty("track_id")]
        public string TrackId { get; set; }

        public string Id { get; set; }

        public string State { get; set; }

        public YAuthCaptcha Captcha { get; set; }
    }
}
