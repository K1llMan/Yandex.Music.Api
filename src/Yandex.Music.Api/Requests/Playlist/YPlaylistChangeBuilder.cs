using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Post, "users/{uid}/playlists/{kind}/change")]
    public class YPlaylistChangeBuilder: YRequestBuilder<YResponse<YPlaylist>, (YPlaylist playlist, IEnumerable<YPlaylistChange> changes)>
    {
        public YPlaylistChangeBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((YPlaylist playlist, IEnumerable<YPlaylistChange> changes) tuple)
        {
            return new Dictionary<string, string> {
                { "uid", storage.User.Uid },
                { "kind", tuple.playlist.Kind }
            };
        }

        protected override HttpContent GetContent((YPlaylist playlist, IEnumerable<YPlaylistChange> changes) tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "kind", tuple.playlist.Kind },
                { "revision", tuple.playlist.Revision.ToString() },
                { "diff", SerializeJson(tuple.changes) }
            });
        }
    }
}