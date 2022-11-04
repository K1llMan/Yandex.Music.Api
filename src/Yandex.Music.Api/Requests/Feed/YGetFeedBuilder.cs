using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Feed
{
    [YApiRequest(WebRequestMethods.Http.Get, "feed")]
    public class YGetFeedBuilder : YRequestBuilder<YResponse<YFeed>, object>
    {
        public YGetFeedBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
    }
}