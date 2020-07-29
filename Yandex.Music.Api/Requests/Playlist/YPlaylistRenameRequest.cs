using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistRenameRequest : YRequest
    {
        public YPlaylistRenameRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string kinds, string name)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "value", name },
            };

            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded")
            };

            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/{kinds}/name", body: GetQueryString(query), headers: headers, method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}