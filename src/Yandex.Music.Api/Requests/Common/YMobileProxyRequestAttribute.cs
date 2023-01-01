namespace Yandex.Music.Api.Requests.Common
{
    public class YMobileProxyRequestAttribute : YBasePathRequestAttribute
    {
        public YMobileProxyRequestAttribute(string method, string url) : base(method, url)
        {
            basePath = "https://mobileproxy.passport.yandex.net";
        }
    }
}