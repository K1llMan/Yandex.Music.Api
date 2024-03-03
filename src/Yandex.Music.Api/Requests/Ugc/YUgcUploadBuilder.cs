using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Web.Ugc;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Ugc
{
    [YRequest(WebRequestMethods.Http.Post, "{postTargetLink}")]
    public class YUgcUploadBuilder : YRequestBuilder<YResponse<string>, (string PostTargetLink, byte[] FileBytes)>
    {
        public YUgcUploadBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((string PostTargetLink, byte[] FileBytes) tuple)
        {
            return new Dictionary<string, string> {
                { "postTargetLink", tuple.PostTargetLink }
            };
        }

        protected override HttpContent GetContent((string PostTargetLink, byte[] FileBytes) tuple)
        {
            return new MultipartFormDataContent
            {
                {new ByteArrayContent(tuple.FileBytes), "file"}
            };
        }
        
    }
}