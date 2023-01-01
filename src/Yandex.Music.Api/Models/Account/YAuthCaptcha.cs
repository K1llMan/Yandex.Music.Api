using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthCaptchaVoice
    {
        public string Url { get; set; }

        [JsonProperty("intro_url")]
        public string IntroUrl { get; set; }
    }

    public class YAuthCaptcha : YAuthBase
    {
        public string Id { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        public string Key { get; set; }

        public YAuthCaptchaVoice Voice { get; set; }
    }
}