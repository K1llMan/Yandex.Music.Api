using System.Security.Authentication;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.MobileProxy;

namespace Yandex.Music.Api.API;

public partial class YMobileProxyAPI : YCommonAPI
{
    public YMobileProxyAPI(YandexMusicApi yandex) : base(yandex)
    {
    }

    public async Task<YAccessToken> GetTokenBySessionIdAsync(AuthStorage storage)
    {
        YAccessToken accessToken = await new YGetTokenBySessionIdBuilder(api, storage)
            .Build(null)
            .GetResponseAsync();

        storage.Token = accessToken.AccessToken;

        return accessToken;
    }

    public async Task<YAccessToken> GetXTokenAsync(AuthStorage storage, YAccessToken token)
    {
        if (string.IsNullOrWhiteSpace(storage.Token))
            throw new AuthenticationException($"Не возможно получить код доступа. Выполните процесс логина {nameof(GetTokenBySessionIdAsync)}");

        YAccessToken accessToken = await new YGetAccessTokenBuilder(api, storage)
            .Build(null)
            .GetResponseAsync();
        
        storage.Token = accessToken.AccessToken;
        
        return accessToken;
    }
}