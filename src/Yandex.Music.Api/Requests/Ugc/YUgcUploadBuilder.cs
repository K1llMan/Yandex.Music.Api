using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Ugc
{
    [YRequest(WebRequestMethods.Http.Post, "{postTargetLink}")]
    public class YUgcUploadBuilder : YRequestBuilder<YResponse<string>, (string postTargetLink, byte[] fileBytes)>
    {
        public YUgcUploadBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((string postTargetLink, byte[] fileBytes) tuple)
        {
            return new Dictionary<string, string> {
                { "postTargetLink", tuple.postTargetLink }
            };
        }

        protected override HttpContent GetContent((string postTargetLink, byte[] fileBytes) tuple)
        {
            return new MultipartFormDataContent {
                { new ByteArrayContent(tuple.fileBytes), "file" }
            };
        }
        
    }
}