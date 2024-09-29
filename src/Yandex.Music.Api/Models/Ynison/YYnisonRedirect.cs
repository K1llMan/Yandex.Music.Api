using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonRedirect
    {
        public string Host { get; set; }
        [JsonProperty("redirect_ticket")]
        public string RedirectTicket { get; set; }
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        [JsonProperty("keep_alive_params")]
        public YYnisonKeepAliveParams KeepAliveParams { get; set; }
    }
}