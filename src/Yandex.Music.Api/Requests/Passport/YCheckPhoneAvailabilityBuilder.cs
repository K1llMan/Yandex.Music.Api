using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Passport
{
    [YPassportRequest(WebRequestMethods.Http.Post, "pwl-yandex/api/passport/suggest/check_availability")]
    public class YCheckPhoneAvailabilityBuilder : YPassportRequestBuilder<YCheckAvailabilityResult, string>
    {
        public YCheckPhoneAvailabilityBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
        
        protected override HttpContent GetContent(string tuple)
        {
            Dictionary<string, string> formData = new()
            {
                { "track_id", storage.AuthToken.TrackId },
                { "phone_number", tuple },
                { "can_use_anmon", "true" },
                { "check_for_push", "true" },
                { "push_suggest_log_all_subscriptions", "false" }
            };

            return new FormUrlEncodedContent(formData);
        }
    }
}