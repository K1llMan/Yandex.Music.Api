using System;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.Exceptions;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Passport;
using YValidateSquatter = Yandex.Music.Api.Models.Passport.YValidateSquatter;

namespace Yandex.Music.Api.API
{
    public partial class YPassportAPI : YCommonAPI
    {
        public YPassportAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        public async Task CreateTrackAsync(AuthStorage storage)
        {
            if (!await GetCsrfTokenAsync(storage))
                throw new Exception("Невозможно инициализировать сессию входа.");

            YPassportTrack passportTrack =
                await new YCreateTrackBuilder(api, storage)
                    .Build(null)
                    .GetResponseAsync();

            storage.AuthToken.TrackId = passportTrack.Id;
        }

        public async Task<YYPassportUser> LoginByPasswordAsync(AuthStorage storage, string password)
        {
            YYPassportUser response =
                await new YMultiStepPasswordBuilder(api, storage)
                    .Build(password)
                    .GetResponseAsync();

            return response;
        }

        public async Task<bool> GetPhoneConfirmationAsync(AuthStorage storage)
        {
            YCheckPhoneConfirmation response =
                await new YCheckPhoneConfirmationBuilder(api, storage)
                    .Build(null)
                    .GetResponseAsync();

            return response.IsPhoneConfirmed;
        }

        public async Task<YMultistepStart> MultistepStartAsync(AuthStorage storage, string login)
        {
            var response =
                await new YMultistepStartBuilder(api, storage)
                    .Build(login)
                    .GetResponseAsync();

            if (!string.IsNullOrWhiteSpace(response.Error) || response.Errors is not null)
            {
                throw new YApiException($"Ошибка 'multistep_start': {response.Errors}");
            }

            return response;
        }

        public async Task<YYPassportUser> MultistepPasswordAsync(AuthStorage storage, string password)
        {
            var response =
                await new YMultiStepPasswordBuilder(api, storage)
                    .Build(password)
                    .GetResponseAsync();

            if (!string.IsNullOrWhiteSpace(response.Error) || response.Errors is not null)
            {
                throw new YApiException($"Ошибка 'multistep_start': {response.Errors}");
            }

            return response;
        }

        public Task<YYPassportUser> RfcOtpPasswordAsync(AuthStorage storage, string rfcOtp)
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
            if (string.IsNullOrWhiteSpace(storage.AuthToken.TrackId))
                throw new YApiException("На найдена сессия для входа");

            return new YValidatePhoneNumberBuilder(api, storage)
                .Build(phone)
                .GetResponseAsync();
        }

        public Task<YCheckAvailabilityResult> CheckPhoneAvailabilityAsync(AuthStorage storage, string phone)
        {
            if (string.IsNullOrWhiteSpace(storage.AuthToken.TrackId))
                throw new YApiException("На найдена сессия для входа");

            return new YCheckPhoneAvailabilityBuilder(api, storage)
                .Build(phone)
                .GetResponseAsync();
        }

        public Task<YSendPushResult> SuggestSendPushAsync(AuthStorage storage, string phone)
        {
            if (string.IsNullOrWhiteSpace(storage.AuthToken.TrackId))
                throw new YApiException("На найдена сессия для входа");

            return new YSendPushBuilder(api, storage)
                .Build(phone)
                .GetResponseAsync();
        }

        public Task CheckPushCodeAsync(AuthStorage storage, string code)
        {
            if (string.IsNullOrWhiteSpace(storage.AuthToken.TrackId))
                throw new YApiException("На найдена сессия для входа");

            return new YCheckPushCode(api, storage)
                .Build(code)
                .GetResponseAsync();
        }


        public Task<YValidateSquatter> ValidateSquatterAsync(AuthStorage storage, string phone)
        {
            if (string.IsNullOrWhiteSpace(storage.AuthToken.TrackId))
                throw new YApiException("На найдена сессия для входа");

            return new YValidateSquatterBuilder(api, storage)
                .Build(phone)
                .GetResponseAsync();
        }

        public Task<YSuggestByPhoneResult> SuggestByPhoneAsync(AuthStorage storage)
        {
            if (string.IsNullOrWhiteSpace(storage.AuthToken.TrackId))
                throw new YApiException("На найдена сессия для входа");

            return new YSuggestByPhoneBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }
    }
}