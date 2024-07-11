using System.Net;

namespace Yandex.Music.Api.Requests.Common
{
    public class HttpContext
    {
        public CookieContainer Cookies;

        public HttpContext()
        {
            Cookies = new CookieContainer();
        }

        public IWebProxy WebProxy { get; set; }
    }
}
