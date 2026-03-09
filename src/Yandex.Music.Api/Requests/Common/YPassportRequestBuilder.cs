using System.Net.Http.Headers;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Common;

public class YPassportRequestBuilder<ResponseType, ParamsTuple> : YRequestBuilder<ResponseType, ParamsTuple>
{
    public YPassportRequestBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
    {
    }
    
    protected override void SetCustomHeaders(HttpRequestHeaders headers)
    {
        if (!string.IsNullOrWhiteSpace(storage.AuthToken?.CsfrToken))
            headers.Add("x-csrf-token", storage.AuthToken.CsfrToken);

        headers.Add("X-Requested-With", "ru.yandex.music");
    }
}