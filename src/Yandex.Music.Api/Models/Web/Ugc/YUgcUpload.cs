using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Web.Ugc
{
    public class YUgcUpload
    {
        [JsonProperty("poll-result")]
        public string PollResult { get; set; }
        [JsonProperty("post-target")]
        public string PostTarget { get; set; }
        [JsonProperty("ugc-track-id")]
        public string UgcTrackId { get; set; }
    }
}