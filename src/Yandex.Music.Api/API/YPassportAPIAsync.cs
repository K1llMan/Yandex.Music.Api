using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Passport;

namespace Yandex.Music.Api.API;

public partial class YPassportAPI : YCommonAPI
{
    public YPassportAPI(YandexMusicApi yandex) : base(yandex)
    {
    }

    public async Task CreateTrackAsync(AuthStorage storage)
    {
        if (!await GetCsrfTokenAsync(storage))
            throw new Exception("Невозможно инициализировать сессию входа.");
        
        YPassportTrack passportTrack = await new YCreateTrackBuilder(api, storage)
            .Build(null)
            .GetResponseAsync();

        storage.AuthToken.TrackId = passportTrack.Id;
    }

    public async Task<YPassportUser> LoginByPasswordAsync(AuthStorage storage, string password)
    {
        YPassportUser response = await new YMultiStepPasswordBuilder(api, storage)
            .Build(password)
            .GetResponseAsync();

        return response;
    }

    public async Task<bool> GetPhoneConfirmationAsync(AuthStorage storage)
    {
        YCheckPhoneConfirmation response = await new YCheckPhoneConfirmationBuilder(api, storage)
            .Build(null)
            .GetResponseAsync();

        return response.IsPhoneConfirmed;
    }

    public Task<YMultistepStart> MultistepStartAsync(AuthStorage storage, string login)
    {
        return new YMultistepStartBuilder(api, storage)
            .Build(login)
            .GetResponseAsync();
    }

    public Task<YPassportUser> MultistepPasswordAsync(AuthStorage storage, string password)
    {
        return new YMultiStepPasswordBuilder(api, storage)
            .Build(password)
            .GetResponseAsync();
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
}