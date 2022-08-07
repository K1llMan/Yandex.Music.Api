using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistCreateRequest : YRequest<YResponse<YPlaylist>>
    {
        public YPlaylistCreateRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YPlaylist>> Create(string name)
        {
            Dictionary<string, string> query = new()
            {
                { "title", name },
                { "visibility", "public" }
            };

            List<KeyValuePair<string, string>> headers = new()
            {
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded")
            };

            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/create", body: GetQueryString(query), headers: headers, method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}