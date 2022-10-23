using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Track
{
    [YRequest(WebRequestMethods.Http.Get, "{src}")]
    public class YStorageDownloadFileBuilder: YRequestBuilder<YStorageDownloadFile, string>
    {
        public YStorageDownloadFileBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(string src)
        {
            return new Dictionary<string, string> {
                { "src", src.Split('?')[0] }
            };
        }

        protected override NameValueCollection GetQueryParams(string src)
        {
            NameValueCollection query = new() {
                { "format", "json" }
            };

            src.Split('?')[1]
                .Split('&')
                .ToList()
                .ForEach(p => {
                    string[] param = p.Split('=');
                    query.Add(param[0], param[1]);
                });

            return query;
        }
    }
}