namespace Yandex.Music.Api.Requests.Common.Attributes
{
    public class YOAuthMobileAttribute : YBasePathRequestAttribute
    {
        public YOAuthMobileAttribute(string method, string url) : base(method, url)
        {
            basePath = "https://oauth.mobile.yandex.net";
        }
    }
}
