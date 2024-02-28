namespace Yandex.Music.Api.Requests.Common
{
    public class YWebApiRequestAttribute: YBasePathRequestAttribute
    {
        public YWebApiRequestAttribute(string method, string url) : base(method, url)
        {
            basePath = "https://music.yandex.ru";
        }
    }
}