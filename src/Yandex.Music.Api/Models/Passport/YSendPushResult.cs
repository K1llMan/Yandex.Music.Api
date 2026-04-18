using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YPushApp
    {
        [JsonProperty("App")]
        public string App { get; set; }

        [JsonProperty("Platform")]
        public string Platform { get; set; }
    }
    
    public class YSendPushResult
    {
        [JsonProperty("pushes_devices_list")]
        public List<object> PushesDevicesList { get; set; }

        [JsonProperty("deny_resend_until")]
        public int DenyResendUntil { get; set; }

        [JsonProperty("is_push_silent")] 
        public bool IsPushSilent { get; set; }

        [JsonProperty("apps_for_bright_push")]
        public List<YPushApp> AppsForBrightPush { get; set; }
    }
}