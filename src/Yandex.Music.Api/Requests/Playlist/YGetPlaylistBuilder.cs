using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Get, "users/{user}/playlists/{kind}")]
    public class YGetPlaylistBuilder : YRequestBuilder<YResponse<YPlaylist>, (string user, string kind)>
    {
        public YGetPlaylistBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((string user, string kind) tuple)
        {
            return new Dictionary<string, string> {
                { "user", tuple.user },
                { "kind", tuple.kind },
            };
        }
    }
}