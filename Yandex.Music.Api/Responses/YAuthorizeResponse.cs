using Yandex.Music.Api.Models;

namespace Yandex.Music.Api.Responses
{
    public class YAuthorizeResponse
    {
        public bool IsAuthorized { get; set; }
        public YUser User { get; set; }
    }
}