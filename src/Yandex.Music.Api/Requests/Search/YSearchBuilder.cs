using System.Collections.Specialized;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Search
{
    [YApiRequest(WebRequestMethods.Http.Get, "search")]
    public class YSearchBuilder : YRequestBuilder<YResponse<YSearch>, (string searchText, YSearchType searchType, int page)>
    {
        public YSearchBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams((string searchText, YSearchType searchType, int page) tuple)
        {
            return new NameValueCollection {
                { "text", tuple.searchText },
                { "type", tuple.searchType.ToString() },
                { "page", tuple.page.ToString() }
            };
        }
    }
}