using System.Net;

namespace Yandex.Music.Api.Requests
{
    public class HttpContext
    {
        public CookieContainer Cookies;
        public IWebProxy WebProxy { get; set; }
    }
}