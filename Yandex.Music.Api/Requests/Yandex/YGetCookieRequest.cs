using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Yandex
{
    internal class YGetCookieRequest : YRequest
    {
        public YGetCookieRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.Origin, storage),
                YRequestHeaders.Get(YHeader.Referer, storage),
                YRequestHeaders.Get(YHeader.SecFetchMode, storage),
                YRequestHeaders.Get(YHeader.SecFetchSite, storage)
            };

            FormRequest("https://matchid.adfox.yandex.ru/getcookie", headers: headers);

            return this;
        }
    }
}