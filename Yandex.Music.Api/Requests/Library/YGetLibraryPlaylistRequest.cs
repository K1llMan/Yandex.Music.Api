using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Library
{
    internal class YGetLibraryPlaylistRequest : YRequest
    {
        public YGetLibraryPlaylistRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            var query = new Dictionary<string, string> {
                {"owner", storage.User.Login},
                {"lang", storage.User.Lang},
                {"filter", "playlists"},
                {"likeFilter", "all"},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"},
                {"ncrnd", "0.17447934315877878"}
            };

            var headers = new List<KeyValuePair<string, string>> {
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
                YRequestHeaders.Get(YHeader.XRetpathY, storage)
            };

            FormRequest(YEndpoints.Library, query: query, headers: headers);

            return this;
        }
    }
}