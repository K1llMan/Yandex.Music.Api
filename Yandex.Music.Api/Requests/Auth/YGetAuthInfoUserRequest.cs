using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YGetAuthInfoUserRequest : YRequest
    {
        public YGetAuthInfoUserRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            var query = new Dictionary<string, string> {
                {"lang", storage.User.Lang},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "no"},
                {"ncrnd", "0.1822837925478349"}
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

            FormRequest(YEndpoints.Auth, query: query, headers: headers);

            return this;
        }
    }
}