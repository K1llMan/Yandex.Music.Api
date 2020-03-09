using System.Collections.Generic;
using System.Linq;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YStorageDownloadFileRequest : YRequest
    {
        public YStorageDownloadFileRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string src)
        {
            var query = new Dictionary<string, string> {
                {"format", "json"},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "no"},
                {"__t", storage.Context.GetTimeInterval().ToString()}
            };

            var parts = src.Split('?');
            parts[1].Split('&').ToList().ForEach(p =>
            {
                var param = p.Split('=');
                query.Add(param[0], param[1]);
            });

            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.Accept, storage),
                YRequestHeaders.Get(YHeader.Origin, storage),
                YRequestHeaders.Get(YHeader.Referer, storage),
                YRequestHeaders.Get(YHeader.SecFetchMode, storage),
                YRequestHeaders.Get(YHeader.SecFetchSite, storage)
            };

            FormRequest(parts[0], query: query, headers: headers);

            return this;
        }
    }
}