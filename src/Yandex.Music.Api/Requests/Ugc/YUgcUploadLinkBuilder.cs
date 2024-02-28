using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Web.Ugc;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Ugc
{
    [YWebApiRequest(WebRequestMethods.Http.Get, "handlers/ugc-upload.jsx")]
    public class YUgcUploadLinkBuilder : YRequestBuilder<YUgcUpload, (string FileName, string PlaylistId)>
    {
        private static readonly Lazy<Random> Random = new(() => new Random());

        public YUgcUploadLinkBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams((string FileName, string PlaylistId) tuple)
        {
            return new NameValueCollection
            {
                { "filename", tuple.FileName },
                { "kind", tuple.PlaylistId },
                { "visibility", "private" },
                { "external-domain", "music.yandex.ru" },
                { "ncrnd", Random.Value.NextDouble().ToString(CultureInfo.InvariantCulture) },
            };
        }
    }
}