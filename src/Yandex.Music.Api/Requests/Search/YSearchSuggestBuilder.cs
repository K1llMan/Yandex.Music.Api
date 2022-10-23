using System.Collections.Specialized;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Search
{
    [YApiRequest(WebRequestMethods.Http.Get, "search/suggest")]
    public class YSearchSuggestBuilder : YRequestBuilder<YResponse<YSearchSuggest>, string>
    {
        public YSearchSuggestBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams(string searchText)
        {
            return new NameValueCollection {
                { "part", searchText }
            };
        }
    }
}