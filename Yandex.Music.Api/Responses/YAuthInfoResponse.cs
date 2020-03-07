using System.Collections.Generic;

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
        public Dictionary<string, string> Experements { get; set; }
        public bool BadRegion { get; set; }
        public bool NotFree { get; set; }
        public string DeviceId { get; set; }
    }
}