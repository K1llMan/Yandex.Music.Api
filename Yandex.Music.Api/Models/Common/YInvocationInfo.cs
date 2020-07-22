using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Common
{
    public class YInvocationInfo
    {
        [JsonProperty("req-id")]
        public string ReqId { get; set; }
        public string HostName { get; set; }
        [JsonProperty("exec-duration-millis")]
        public int ExecDurationMillis { get; set; }
    }
}
