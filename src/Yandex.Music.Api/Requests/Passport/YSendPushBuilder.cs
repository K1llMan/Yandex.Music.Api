using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Passport
{
    [YPassportRequest(WebRequestMethods.Http.Post, "pwl-yandex/api/passport/auth/suggest-send-push")]
    public class YSendPushBuilder : YPassportRequestBuilder<YSendPushResult, string>
    {
        public YSendPushBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
        
        protected override HttpContent GetContent(string tuple)
        {
            return GetJsonContent(new {
                track_id = storage.AuthToken.TrackId,
                phone_number = tuple,
                can_use_anmon = true,
                force_show_code_in_notification = "1",
                country = storage.Country
            });
        }
    }
}