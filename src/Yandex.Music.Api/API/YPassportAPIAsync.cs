using System;
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
        
        YPassportTrack passportTrack = await new YCreateTrackMethodsBuilder(api, storage)
            .Build(null)
            .GetResponseAsync();
        
        storage.AuthToken.TrackId = passportTrack.Id;
    }
}