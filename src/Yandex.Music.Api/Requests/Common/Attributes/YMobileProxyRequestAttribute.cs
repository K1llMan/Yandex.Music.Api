namespace Yandex.Music.Api.Requests.Common.Attributes
{
    public class YMobileProxyRequestAttribute : YBasePathRequestAttribute
    {
        public YMobileProxyRequestAttribute(string method, string url) : base(method, url)
        {
            basePath = "https://mobileproxy.passport.yandex.net";
        }
    }
}
