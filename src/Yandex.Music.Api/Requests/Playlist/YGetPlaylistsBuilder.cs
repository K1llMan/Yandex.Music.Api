using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    [YApiRequest(WebRequestMethods.Http.Post, "playlists/list")]
    public class YGetPlaylistsBuilder : YRequestBuilder<YResponse<List<YPlaylist>>, IEnumerable<(string User, string Kind)>>
    {
        public YGetPlaylistsBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(IEnumerable<(string User, string Kind)> playlistIds)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "playlist-Ids", string.Join(",", playlistIds.Select(t => $"{t.User}:{t.Kind}")) }
            });
        }
    }
}