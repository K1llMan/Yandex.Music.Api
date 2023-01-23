using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthCaptcha : YAuthBase
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public string Label { get; set; }
        
        public string Mode { get; set; }
        
        public List<YAuthCaptchaError> Error { get; set; }

        public bool CountryFromAudioWhiteList { get; set; }
        
        public YAuthCaptchaOptions Options { get; set; }
        
        public YAuthCaptchaVoice Voice { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        public string Key { get; set; }

        public string Static { get; set; }
    }
}
