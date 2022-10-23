namespace Yandex.Music.Api.Requests.Common
{
    public class YApiRequestAttribute: YBasePathRequestAttribute
    {
        public YApiRequestAttribute(string method, string url) : base(method, url)
        {
            basePath = "https://api.music.yandex.net";
        }
    }
}