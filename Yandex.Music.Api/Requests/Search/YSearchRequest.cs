using System.Collections.Generic;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Search
{
    internal class YSearchRequest : YRequest
    {
        public YSearchRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string searchText, YandexSearchType searchType, int page = 0)
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

            FormRequest(YEndpoints.Search, query: query);

            return this;
        }
    }
}