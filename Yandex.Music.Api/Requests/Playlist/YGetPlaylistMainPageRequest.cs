using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistMainPageRequest : YRequest
    {
        public YGetPlaylistMainPageRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "what", "home" },
                { "lang", storage.User.Lang },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" },
                { "ncrnd", "0.9963530980832063" }
            };

            FormRequest(YEndpoints.Main, query: query);

            return this;
        }
    }
}