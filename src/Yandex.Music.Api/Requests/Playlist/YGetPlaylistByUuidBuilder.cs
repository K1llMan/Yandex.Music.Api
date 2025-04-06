using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Get, "playlist/{uuid}")]
    public class YGetPlaylistByUuidBuilder : YRequestBuilder<YResponse<YPlaylist>, string>
    {
        public YGetPlaylistByUuidBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(string uuid)
        {
            return new Dictionary<string, string> {
                { "uuid", uuid },
            };
        }
    }
}