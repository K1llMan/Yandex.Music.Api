using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YGetAuthInfoRequest : YRequest
    {
        public YGetAuthInfoRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            var query = new Dictionary<string, string> {
                {"external-domain", "music.yandex.ru"},
                {"overembed", "no"},
                {"__t", storage.Context.GetTimeInterval().ToString()}
            };

            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.Accept, storage),
                YRequestHeaders.Get(YHeader.AcceptEncoding, storage),
                YRequestHeaders.Get(YHeader.AcceptLanguage, storage),
                YRequestHeaders.Get(YHeader.AccessControlAllowMethods, storage),
                YRequestHeaders.Get(YHeader.Origin, storage),
                YRequestHeaders.Get(YHeader.Referer, storage),
                YRequestHeaders.Get(YHeader.SecFetchSite, storage),
                YRequestHeaders.Get(YHeader.XRequestedWith, storage),
                YRequestHeaders.Get(YHeader.XRetpathY, storage)
            };

            FormRequest("https://music.yandex.ru/api/v2.1/handlers/auth", query: query, headers: headers);

            return this;
        }
    }
}