using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistCreateRequest : YRequest
    {
        public YPlaylistCreateRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string name)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "title", name },
                { "visibility", "public" },
            };

            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded")
            };

            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/create", body: GetQueryString(query), headers: headers, method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}