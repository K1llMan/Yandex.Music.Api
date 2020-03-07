using System.Collections.Generic;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistDejaVuRequest : YRequest
    {
        public YGetPlaylistDejaVuRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "kinds", storage.User.Uid },
                { "lang", storage.User.Lang },
                { "owner", "yamusic-dejavu" },
                { "light", "true" },
                { "likeFilter", "all" },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" },
                { "ncrnd", "0.13048851242872916" }
            };

            FormRequest(YEndpoints.Playlist, query: query);

            return this;
        }
    }
}