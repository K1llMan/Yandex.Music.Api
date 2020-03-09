using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Album
{
    internal class YGetAlbumRequest : YRequest
    {
        public YGetAlbumRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string albumId)
        {
            var query = new Dictionary<string, string> {
                {"album", albumId},
                {"lang", storage.User.Lang},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"}
            };

            FormRequest(YEndpoints.Album, query: query);

            return this;
        }
    }
}