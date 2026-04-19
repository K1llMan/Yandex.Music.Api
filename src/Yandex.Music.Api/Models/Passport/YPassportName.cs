using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YPassportName
    {
        [JsonProperty("default_avatar")]
        public string DefaultAvatar { get; set; }

        public string Name { get; set; }
    }
}