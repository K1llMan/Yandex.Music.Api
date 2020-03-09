using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistRequest : YRequest
    {
        public YGetPlaylistRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string kinds)
        {
            var query = new Dictionary<string, string> {
                {"owner", "music.partners"},
                {"kinds", kinds}
            };

            FormRequest(YEndpoints.Playlist, WebRequestMethods.Http.Post, query);

            return this;
        }
    }
}