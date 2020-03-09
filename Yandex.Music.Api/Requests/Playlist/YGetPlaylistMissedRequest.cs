using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistMissedRequest : YRequest
    {
        public YGetPlaylistMissedRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string kinds)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                {"kinds", kinds},
                {"lang", storage.User.Lang},
                {"owner", "yamusic-missed"},
                {"light", "true"},
                {"likeFilter", "all"},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"},
                {"ncrnd", "0.8392886758407374"}
            };

            FormRequest(YEndpoints.Playlist, query: query);

            return this;
        }
    }
}