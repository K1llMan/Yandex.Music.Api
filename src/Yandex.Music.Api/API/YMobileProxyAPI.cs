using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;

namespace Yandex.Music.Api.API
{
    public partial class YMobileProxyAPI
    {
        public YAccessToken GetTokenBySessionId(AuthStorage storage)
        {
            return GetTokenBySessionIdAsync(storage).GetAwaiter().GetResult();
        }

        public YAccessToken GetTokenByAccessToken(AuthStorage storage, YAccessToken token)
        {
            return GetXTokenAsync(storage, token).GetAwaiter().GetResult();
        }
    }
}