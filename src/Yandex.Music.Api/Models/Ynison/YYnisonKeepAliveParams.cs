using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonKeepAliveParams
    {
        [JsonProperty("keep_alive_time_seconds")]
        public int KeepAliveTimeSeconds { get; set; }
        [JsonProperty("keep_alive_timeout_seconds")]
        public int KeepAliveTimeoutSeconds { get; set; }
    }
}