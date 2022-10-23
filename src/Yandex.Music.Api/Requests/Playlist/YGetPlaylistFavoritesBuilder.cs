using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Get, "users/{uid}/playlists/list")]
    public class YGetPlaylistFavoritesBuilder: YRequestBuilder<YResponse<List<YPlaylist>>, object>
    {
        public YGetPlaylistFavoritesBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(object tuple)
        {
            return new Dictionary<string, string> {
                { "uid", storage.User.Uid }
            };
        }
    }
}