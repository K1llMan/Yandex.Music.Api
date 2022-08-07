using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistRenameRequest : YRequest<YResponse<YPlaylist>>
    {
        public YPlaylistRenameRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YPlaylist>> Create(string kinds, string name)
        {
            Dictionary<string, string> query = new()
            {
                { "value", name }
            };

            List<KeyValuePair<string, string>> headers = new()
            {
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded")
            };

            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/{kinds}/name", body: GetQueryString(query), headers: headers, method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}