using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        headers.Add("process-uuid", "26d53636-13a9-41f4-af99-d404dce90363");
        headers.Add("Referer", "https://passport.yandex.ru/");
        headers.Add("Sec-Fetch-Dest", "empty");
        headers.Add("Sec-Fetch-Mode", "cors");
        headers.Add("Sec-Fetch-Site", "same-origin");
        headers.Add("tractor-location", "0");
        headers.Add("tractor-non-proxy", "1");
    }

    protected JsonContent GetJsonContent<RequestData>(RequestData data)
    {
        JsonSerializerOptions settings = new() {
            Converters = {
                new JsonStringEnumConverter()
            },
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        return JsonContent.Create(data, new MediaTypeHeaderValue("application/json"), settings);
    }
}