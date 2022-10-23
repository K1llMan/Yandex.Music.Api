using System.Collections.Specialized;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Get, "landing3")]
    public class YGetPlaylistMainPageBuilder: YRequestBuilder<YResponse<YLanding>, object>
    {
        public YGetPlaylistMainPageBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams(object tuple)
        {
            return new NameValueCollection {
                { "blocks", "personalplaylists" }
            };
        }
    }
}