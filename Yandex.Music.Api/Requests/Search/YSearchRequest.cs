using System.Collections.Generic;
using System.Net;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Search
{
    internal class YSearchRequest : YRequest
    {
        public YSearchRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string searchText, YandexSearchType searchType, int page = 0)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "text", searchText },
                { "type", searchType.ToString() },
                { "page", page.ToString() },
                { "lang", "ru" },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" },
                { "ncrnd", "0.7060701951464323" }
            };

            return GetRequest(YEndpoints.Search, query: query);
        }
    }
}