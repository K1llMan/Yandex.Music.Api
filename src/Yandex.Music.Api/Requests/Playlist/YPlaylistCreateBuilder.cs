using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Post, "users/{uid}/playlists/create")]
    public class YPlaylistCreateBuilder: YRequestBuilder<YResponse<YPlaylist>, string>
    {
        public YPlaylistCreateBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(string name)
        {
            return new Dictionary<string, string> {
                { "uid", storage.User.Uid }
            };
        }

        protected override HttpContent GetContent(string name)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "title", name },
                { "visibility", "public" }
            });
        }
    }
}