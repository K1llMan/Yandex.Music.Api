namespace Yandex.Music.Api.Requests.Common
{
    public class YPassportRequestAttribute : YBasePathRequestAttribute
    {
        public YPassportRequestAttribute(string method, string url) : base(method, url)
        {
            basePath = "https://passport.yandex.ru";
        }
    }
}