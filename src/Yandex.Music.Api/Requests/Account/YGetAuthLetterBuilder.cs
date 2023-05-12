using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Account
{
    [YPassportRequest(WebRequestMethods.Http.Post, "registration-validations/auth/send_magic_letter")]
    internal class YGetAuthLetterBuilder : YRequestBuilder<Models.Account.YAuthLetter, string>
    {
        public YGetAuthLetterBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            if (storage.AuthToken == null)
            {
                throw new Exception("Не найдена сессия входа.");
            }

            return new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "csrf_token", storage.AuthToken.CsfrToken },
                { "track_id", storage.AuthToken.TrackId },
            });
        }
    }
}