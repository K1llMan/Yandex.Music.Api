namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonRedirect
    {
        public string Host { get; set; }
        public string RedirectTicket { get; set; }
        public string SessionId { get; set; }
        public YYnisonKeepAliveParams KeepAliveParams { get; set; }
    }
}
