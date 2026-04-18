using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YCheckPhoneConfirmation
    {
        [JsonProperty("isPhoneConfirmed")]
        public bool IsPhoneConfirmed { get; set; }
    }
}