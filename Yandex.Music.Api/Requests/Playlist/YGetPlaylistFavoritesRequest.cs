using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistFavoritesRequest : YRequest
    {
        public YGetPlaylistFavoritesRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            var query = new Dictionary<string, string> {
                {"owner", storage.User.Login},
                {"lang", storage.User.Lang},
                {"filter", "tracks"},
                {"likeFilter", "favorite"},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"},
                {"ncrnd", "0.7506943983987266"}
            };

            FormRequest(YEndpoints.Library, query: query);

            return this;
        }
    }
}