namespace Yandex.Music.Api.Requests.Common
{
    public class YLoginRequestAttribute : YBasePathRequestAttribute
    {
        public YLoginRequestAttribute(string method, string url) : base(method, url)
        {
            basePath = "https://login.yandex.ru";
        }
    }
}