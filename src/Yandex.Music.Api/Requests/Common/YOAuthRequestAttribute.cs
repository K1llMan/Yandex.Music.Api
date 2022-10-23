namespace Yandex.Music.Api.Requests.Common
{
    public class YOAuthRequestAttribute : YBasePathRequestAttribute
    {
        public YOAuthRequestAttribute(string method, string url) : base(method, url)
        {
            basePath = "https://oauth.yandex.ru";
        }
    }
}