using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthCaptchaVoice
    {
        public string Url { get; set; }

        [JsonProperty("intro_url")]
        public string IntroUrl { get; set; }
    }
}
