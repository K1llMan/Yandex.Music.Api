using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Album
{
    [YApiRequest(WebRequestMethods.Http.Get, "albums/{albumId}/with-tracks")]
    public class YGetAlbumBuilder: YRequestBuilder<YResponse<YAlbum>, string>
    {
        public YGetAlbumBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(string albumId)
        {
            return new Dictionary<string, string> {
                { "albumId", albumId }
            };
        }
    }
}