using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YYPassportUser : YPassportResponseBase
    {
        [JsonProperty("track_id")]
        public string TrackId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("account")]
        public YPassportAccount Account { get; set; }
    }
}