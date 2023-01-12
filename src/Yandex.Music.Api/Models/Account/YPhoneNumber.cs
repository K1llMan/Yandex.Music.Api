using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YPhoneNumber
    {
        [JsonProperty("masked_e164")]
        public string MaskedE164 { get; set; }

        public string E164 { get; set; }

        public string International { get; set; }

        [JsonProperty("masked_original")]
        public string MaskedOriginal { get; set; }

        public string Original { get; set; }

        [JsonProperty("masked_international")]
        public string MaskedInternational { get; set; }
    }
}