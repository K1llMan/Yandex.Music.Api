using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YGetCookieResponse
    {
        public string CryptoId { get; set; }
        public string CryptoSign { get; set; }

        public static YGetCookieResponse FromJson(JToken json)
        {
            return new YGetCookieResponse
            {
                CryptoId = json["cryptouid"].ToObject<string>(),
                CryptoSign = json["cryptouid_sign"].ToObject<string>()
            };
        }
    }
}