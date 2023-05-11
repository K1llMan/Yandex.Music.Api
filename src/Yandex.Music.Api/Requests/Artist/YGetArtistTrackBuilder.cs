using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Artist
{
    [YApiRequest(WebRequestMethods.Http.Get, "artists/{artistId}/tracks")]
    public class YGetArtistTrackBuilder: YRequestBuilder<YResponse<YTracksPage>, (string id, int page, int pageSize)>
    {
        public YGetArtistTrackBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth) { }

        protected override Dictionary<string, string> GetSubstitutions((string id, int page, int pageSize) tuple)
        {
            return new Dictionary<string, string> {
                { "artistId", tuple.id },
            };
        }

        protected override NameValueCollection GetQueryParams((string id, int page, int pageSize) tuple)
        {
            return new NameValueCollection {
                { "page", tuple.page.ToString() },
                { "pageSize", tuple.pageSize.ToString() },
            };
        }
    }
}