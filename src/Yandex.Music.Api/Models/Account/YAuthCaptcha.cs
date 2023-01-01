using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthCaptcha : YAuthBase
    {
        public string Id { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        public string Key { get; set; }

        public YAuthCaptchaVoice Voice { get; set; }
    }
}