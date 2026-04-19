using System.Security.Authentication;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;

namespace Yandex.Music.Api.API
{
    public partial class YPassportAPI
    {
        public void CreateTrack(AuthStorage storage)
        {
            CreateTrackAsync(storage).GetAwaiter().GetResult();

            if (string.IsNullOrEmpty(storage.AuthToken.TrackId))
                throw new AuthenticationException("Не удалось инициализировать процесс аутентификации");
        }

        public YPassportUser LoginByPassword(AuthStorage storage, string password)
        {
            return LoginByPasswordAsync(storage, password).GetAwaiter().GetResult();
        }

        public bool GetPhoneConfirmation(AuthStorage storage)
        {
            return GetPhoneConfirmationAsync(storage).GetAwaiter().GetResult();
        }

        public YMultistepStart MultistepStart(AuthStorage storage, string login)
        {
            return MultistepStartAsync(storage, login).GetAwaiter().GetResult();
        }

        public YPassportUser MultistepPassword(AuthStorage storage, string password)
        {
            return MultistepPasswordAsync(storage, password).GetAwaiter().GetResult();
        }

        public YPassportUser RfcOtpPassword(AuthStorage storage, string rfcOtp)
        {
            return RfcOtpPasswordAsync(storage, rfcOtp).GetAwaiter().GetResult();
        }

        public YPassportSession CreateUserSession(AuthStorage storage)
        {
            return CreateUserSessionAsync(storage).GetAwaiter().GetResult();
        }

        public YPassportSessionStatus GetSessionState(AuthStorage storage)
        {
            return GetSessionStateAsync(storage).GetAwaiter().GetResult();
        }

        public YValidatePhoneNumberResult ValidatePhoneNumber(AuthStorage storage, string phone)
        {
            return ValidatePhoneNumberAsync(storage, phone).GetAwaiter().GetResult();
        }

        public YCheckAvailabilityResult CheckPhoneAvailability(AuthStorage storage, string phone)
        {
            return CheckPhoneAvailabilityAsync(storage, phone).GetAwaiter().GetResult();
        }

        public YSendPushResult SuggestSendPush(AuthStorage storage, string phone)
        {
            return SuggestSendPushAsync(storage, phone).GetAwaiter().GetResult();
        }

        public void CheckPushCode(AuthStorage storage, string code)
        {
            CheckPushCodeAsync(storage, code).GetAwaiter().GetResult();
        }

        public YValidateSquatter ValidateSquatter(AuthStorage storage, string phone)
        {
            return ValidateSquatterAsync(storage, phone).GetAwaiter().GetResult();
        }

        public YSuggestByPhoneResult SuggestByPhone(AuthStorage storage)
        {
            return SuggestByPhoneAsync(storage).GetAwaiter().GetResult();
        }
    }
}