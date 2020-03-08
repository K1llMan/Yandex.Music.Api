using System.Collections.Generic;
using System.Net;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistChangeRequest : YRequest
    {
        public YPlaylistChangeRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string name)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                {"action", "add"},
                {"title", name},
                {"lang", "ru"},
                {"sign", storage.User.Sign },
                {"experiments", storage.User.Experiments },
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"}
            };

            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.Accept, storage),
                YRequestHeaders.Get(YHeader.AcceptEncoding, storage),
                YRequestHeaders.Get(YHeader.AcceptLanguage, storage),
                YRequestHeaders.Get(YHeader.AccessControlAllowMethods, storage),
                YRequestHeaders.Get(YHeader.Origin, storage),
                YRequestHeaders.Get(YHeader.Referer, storage),
                YRequestHeaders.Get(YHeader.SecFetchMode, storage),
                YRequestHeaders.Get(YHeader.SecFetchSite, storage),
                YRequestHeaders.Get(YHeader.XCurrentUID, storage),
                YRequestHeaders.Get(YHeader.XRequestedWith, storage),
                YRequestHeaders.Get(YHeader.XRetpathY, storage),
            };

            FormRequest(YEndpoints.ChangePlaylist, body: GetQueryString(query), headers: headers);

            return this;
        }
    }
}