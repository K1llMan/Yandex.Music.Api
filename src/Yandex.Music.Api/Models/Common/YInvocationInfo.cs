using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Common
{
    public class YInvocationInfo
    {
        [JsonProperty("app-name")]
        public string AppName { get; set; }
        [JsonProperty("exec-duration-millis")] 
        public int ExecDurationMillis { get; set; }
        public string HostName { get; set; }
        [JsonProperty("req-id")] 
        public string ReqId { get; set; }
    }
}