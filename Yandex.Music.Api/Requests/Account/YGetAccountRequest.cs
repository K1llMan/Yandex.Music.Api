using System.Net;

namespace Yandex.Music.Api.Requests.Account
{
    internal class YGetAccountRequest : YRequest
    {
        public YGetAccountRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string lang)
        {
            var url =
                $"https://music.yandex.ru/handlers/accounts.jsx?lang={lang}&external-domain=music.yandex.ru&overembed=false&ncrnd=0.7168345644602356";
            var request = GetRequest(url);

            return request;
        }
    }
}