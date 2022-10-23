using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Post, "users/{uid}/playlists/{kind}/delete")]
    public class YPlaylistRemoveBuilder : YRequestBuilder<HttpResponseMessage, string>
    {
        public YPlaylistRemoveBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(string kind)
        {
            return new Dictionary<string, string> {
                { "uid", storage.User.Uid },
                { "kind", kind }
            };
        }
    }
}