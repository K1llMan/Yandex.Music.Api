using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YAuthInfoResponse
    {
        public string Csrf { get; set; }
        public string FreshCsrf { get; set; }
        public string Uid { get; set; }
        public string Login { get; set; }
        public string YandexuId { get; set; }
        public bool Logged { get; set; }
        public bool Premium { get; set; }
        public string Lang { get; set; }
        public long Timestamp { get; set; }
        public string Experements { get; set; }
        public bool BadRegion { get; set; }
        public bool NotFree { get; set; }
        public string DeviceId { get; set; }

        public static YAuthInfoResponse FromJson(JToken json)
        {
            return new YAuthInfoResponse
            {
                Csrf = json["csrf"].ToObject<string>(),
                FreshCsrf = json["freshCsrf"].ToObject<string>(),
                Uid = json["uid"].ToObject<string>(),
                Login = json["login"].ToObject<string>(),
                YandexuId = json["yandexuid"].ToObject<string>(),
                Logged = json["logged"].ToObject<bool>(),
                Premium = json["premium"].ToObject<bool>(),
                Lang = json["lang"].ToObject<string>(),
                Timestamp = json["timestamp"].ToObject<long>(),
                Experements = json["experiments"].ToString(),
                BadRegion = json["badRegion"].ToObject<bool>(),
                NotFree = json["notFree"].ToObject<bool>(),
                DeviceId = json["device_id"].ToObject<string>()
            };
        }
    }
}