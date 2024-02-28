using System;
using System.Net;
using System.Net.Http;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Web.Ugc;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Ugc
{
    [YWebApiRequest(WebRequestMethods.Http.Post, "")]
    public class YUgcUploadBuilder : YRequestBuilder<YUgcTrackUploadResult, (string PostTargetLink, byte[] FileBytes)>
    {
        public YUgcUploadBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Uri BuildUri((string PostTargetLink, byte[] FileBytes) tuple)
        {
            return new Uri(tuple.PostTargetLink);
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