using System.Collections.Generic;
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
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "lang", lang },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" },
                { "ncrnd", "0.7168345644602356" }
            };

            return GetRequest(YEndpoints.Accounts, query: query);
        }
    }
}