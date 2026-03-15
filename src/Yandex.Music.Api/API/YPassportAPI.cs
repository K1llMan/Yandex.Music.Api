using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.Exceptions;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Passport;

namespace Yandex.Music.Api.API;

public partial class YPassportAPI
{
    private async Task<bool> GetCsrfTokenAsync(AuthStorage storage)
    {
        using HttpResponseMessage authMethodsResponse = await new YPwlYandexBuilder(api, storage)
            .Build(null)
            .GetResponseAsync();

        if (!authMethodsResponse.IsSuccessStatusCode)
            throw new HttpRequestException("Невозможно получить CFRF-токен.");

        string responseString = await authMethodsResponse.Content
            .ReadAsStringAsync();
        Match match = Regex.Match(responseString, @"window\.__CSRF__\s*=\s*""([^""]+)""");

        if (!match.Success || match.Groups.Count < 2)
        {
            throw new YApiException("Ошибка получения CFRF токена. Попробуйте позже.");
        }

        storage.AuthToken = new YAuthToken
        {
            CsfrToken = match.Groups[1].Value
        };

        return true;
    }

    public void CreateTrack(AuthStorage storage)
    {
        CreateTrackAsync(storage).GetAwaiter().GetResult();

        if (string.IsNullOrWhiteSpace(storage.AuthToken.TrackId))
            throw new AuthenticationException("Не удалось инициализировать процесс аутентификации");
    }

    public YYPassportUser LoginByPassword(AuthStorage storage, string password)
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

    public YYPassportUser MultistepPassword(AuthStorage storage, string password)
    {
        return MultistepPasswordAsync(storage, password).GetAwaiter().GetResult();
    }

    public YYPassportUser RfcOtpPassword(AuthStorage storage, string rfcOtp)
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