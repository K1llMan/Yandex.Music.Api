using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.Exceptions;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Passport;

namespace Yandex.Music.Api.API
{
    public partial class YPassportAPI : YCommonAPI
    {
        #region Вспомогательные функции

        private async Task<bool> GetCsrfTokenAsync(AuthStorage storage)
        {
            using HttpResponseMessage authMethodsResponse =
                await new YPwlYandexBuilder(api, storage)
                    .Build(null)
                    .GetResponseAsync();

            if (!authMethodsResponse.IsSuccessStatusCode)
                throw new HttpRequestException("Невозможно получить CFRF-токен.");

            string responseString = await authMethodsResponse.Content
                .ReadAsStringAsync();

            Match match = Regex.Match(responseString, @"window\.__CSRF__\s*=\s*""([^""]+)""");

            if (!match.Success || match.Groups.Count < 2)
                throw new YApiException("Ошибка получения CFRF токена. Попробуйте позже.");

            storage.AuthToken = new YAuthToken {
                CsfrToken = match.Groups[1].Value
            };

            return true;
        }

        private void CheckSession(AuthStorage storage)
        {
            if (string.IsNullOrEmpty(storage.AuthToken.TrackId))
                throw new YApiException("На найдена сессия для входа");
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public async Task CreateTrackAsync(AuthStorage storage)
        {
            if (!await GetCsrfTokenAsync(storage))
                throw new Exception("Невозможно инициализировать сессию входа.");

            YPassportTrack passportTrack = await new YCreateTrackBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            storage.AuthToken.TrackId = passportTrack.Id;
        }

        public Task<YPassportUser> LoginByPasswordAsync(AuthStorage storage, string password)
        {
            return new YMultiStepPasswordBuilder(api, storage)
                .Build(password)
                .GetResponseAsync();
        }

        public async Task<bool> GetPhoneConfirmationAsync(AuthStorage storage)
        {
            YCheckPhoneConfirmation response = await new YCheckPhoneConfirmationBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();

            return response.IsPhoneConfirmed;
        }

        public async Task<YMultistepStart> MultistepStartAsync(AuthStorage storage, string login)
        {
            YMultistepStart response = await new YMultistepStartBuilder(api, storage)
                .Build(login)
                .GetResponseAsync();

            if (!string.IsNullOrEmpty(response.Error) || response.Errors is not null)
                throw new YApiException($"Ошибка 'multistep_start': {response.Errors}");

            return response;
        }

        public async Task<YPassportUser> MultistepPasswordAsync(AuthStorage storage, string password)
        {
            YPassportUser response = await new YMultiStepPasswordBuilder(api, storage)
                .Build(password)
                .GetResponseAsync();

            if (!string.IsNullOrEmpty(response.Error) || response.Errors is not null)
                throw new YApiException($"Ошибка 'multistep_start': {response.Errors}");

            return response;
        }

        public Task<YPassportUser> RfcOtpPasswordAsync(AuthStorage storage, string rfcOtp)
        {
            return new YRfcOtpBuilder(api, storage)
                .Build(rfcOtp)
                .GetResponseAsync();
        }

        public Task<YPassportSession> CreateUserSessionAsync(AuthStorage storage)
        {
            return new YGetSessionBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        public Task<YPassportSessionStatus> GetSessionStateAsync(AuthStorage storage)
        {
            return new YCheckSessionBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        public Task<YValidatePhoneNumberResult> ValidatePhoneNumberAsync(AuthStorage storage, string phone)
        {
            CheckSession(storage);

            return new YValidatePhoneNumberBuilder(api, storage)
                .Build(phone)
                .GetResponseAsync();
        }

        public Task<YCheckAvailabilityResult> CheckPhoneAvailabilityAsync(AuthStorage storage, string phone)
        {
            CheckSession(storage);

            return new YCheckPhoneAvailabilityBuilder(api, storage)
                .Build(phone)
                .GetResponseAsync();
        }

        public Task<YSendPushResult> SuggestSendPushAsync(AuthStorage storage, string phone)
        {
            CheckSession(storage);

            return new YSendPushBuilder(api, storage)
                .Build(phone)
                .GetResponseAsync();
        }

        public Task CheckPushCodeAsync(AuthStorage storage, string code)
        {
            CheckSession(storage);

            return new YCheckPushCode(api, storage)
                .Build(code)
                .GetResponseAsync();
        }


        public Task<YValidateSquatter> ValidateSquatterAsync(AuthStorage storage, string phone)
        {
            CheckSession(storage);

            return new YValidateSquatterBuilder(api, storage)
                .Build(phone)
                .GetResponseAsync();
        }

        public Task<YSuggestByPhoneResult> SuggestByPhoneAsync(AuthStorage storage)
        {
            CheckSession(storage);

            return new YSuggestByPhoneBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        #endregion Основные функции
        
        public YPassportAPI(YandexMusicApi yandex) : base(yandex)
        {
        }
    }
}