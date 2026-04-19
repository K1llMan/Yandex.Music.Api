using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YPassportUser : YPassportResponseBase
    {
        [JsonProperty("track_id")]
        public string TrackId { get; set; }

        public string State { get; set; }

        public YPassportAccount Account { get; set; }
    }
}