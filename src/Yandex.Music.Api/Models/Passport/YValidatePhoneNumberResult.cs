using Newtonsoft.Json;
using Yandex.Music.Api.Models.Account;

namespace Yandex.Music.Api.Models.Passport
{
    public class YValidatePhoneNumberResult : YPassportResponseBase
    {
        [JsonProperty("phone_number")]
        public YPhoneNumber PhoneNumber { get; set; }

        [JsonProperty("valid_for_flash_call")]
        public bool ValidForFlashCall { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("valid_for_viber")]
        public bool ValidForViber { get; set; }

        [JsonProperty("valid_for_whatsapp")]
        public bool ValidForWhatsapp { get; set; }

        [JsonProperty("valid_for_telegram")]
        public bool ValidForTelegram { get; set; }

        [JsonProperty("valid_for_sms")]
        public bool ValidForSms { get; set; }

        [JsonProperty("track_id")]
        public string TrackId { get; set; }
    }
}