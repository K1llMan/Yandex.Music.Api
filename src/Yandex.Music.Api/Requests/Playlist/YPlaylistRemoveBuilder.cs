using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Post, "users/{uid}/playlists/{kind}/name")]
    public class YPlaylistRenameBuilder : YRequestBuilder<YResponse<YPlaylist>, (string kind, string name)>
    {
        public YPlaylistRenameBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((string kind, string name) tuple)
        {
            return new Dictionary<string, string> {
                { "uid", storage.User.Uid },
                { "kind", tuple.kind }
            };
        }

        protected override HttpContent GetContent((string kind, string name) tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "value", tuple.name }
            });
        }
    }
}