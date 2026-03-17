using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Common
{
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
            headers.Add("process-uuid", "26d53636-13a9-41f4-af99-d404dce90363");
            headers.Add("Referer", "https://passport.yandex.ru/");
            headers.Add("Sec-Fetch-Dest", "empty");
            headers.Add("Sec-Fetch-Mode", "cors");
            headers.Add("Sec-Fetch-Site", "same-origin");
            headers.Add("tractor-location", "0");
            headers.Add("tractor-non-proxy", "1");
            headers.Add("Accept", "*/*");
            headers.Add("Accept-Language", "ru,en-US;q=0.9,en;q=0.8");
            headers.Add("c11n", "yandex_music");
            headers.Add("Connection", "keep-alive");
            headers.Add("Origin", "https://passport.yandex.ru");
            headers.Add("User-Agent", "Mozilla/5.0 (Linux; Android 7.1.1; ONEPLUS A3010 Build/NMF26F; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/103.0.5060.129 Safari/537.36 PassportSDK/7.50.2.750024597 ru.yandex.music/2026.02.3 #135gpr");
        }
    }
}