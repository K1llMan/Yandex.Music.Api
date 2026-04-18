using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YPassportSessionStatus
    {
        [JsonProperty("session_is_correct")]
        public bool SessionIsCorrect { get; set; }

        [JsonProperty("session_has_users")]
        public bool SessionHasUsers { get; set; }
    }
}