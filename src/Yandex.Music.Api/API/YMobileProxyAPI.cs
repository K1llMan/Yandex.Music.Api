using System.Security.Authentication;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.MobileProxy;

namespace Yandex.Music.Api.API;

public class YMobileProxyAPI : YCommonAPI
{
    public YMobileProxyAPI(YandexMusicApi yandex) : base(yandex)
    {
    }

    public YAccessToken GetTokenBySessionId(AuthStorage storage)
    {
        return GetTokenBySessionIdASync(storage).GetAwaiter().GetResult();
    }

    public async Task<YAccessToken> GetTokenBySessionIdASync(AuthStorage storage)
    {
        YAccessToken accessToken = await new YGetTokenBySessionIdBuilder(api, storage)
            .Build(null)
            .GetResponseAsync();

        storage.Token = accessToken.AccessToken;

        return accessToken;
    }

    public async Task<YAccessToken> GetToken(AuthStorage storage)
    {
        if (string.IsNullOrWhiteSpace(storage.Token))
            throw new AuthenticationException($"Не возможно получить код доступа. Выполните процесс логина {nameof(GetTokenBySessionIdASync)}");

        YAccessToken accessToken = await new YGetAccessTokenBuilder(api, storage)
            .Build(null)
            .GetResponseAsync();
        
        storage.Token = accessToken.AccessToken;
        
        return accessToken;
    }
}