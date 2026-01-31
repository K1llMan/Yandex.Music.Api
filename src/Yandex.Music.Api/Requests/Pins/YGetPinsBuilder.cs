using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Pins;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Pins
{
    [YApiRequest(WebRequestMethods.Http.Get, "pins")]
    public class YGetPinsBuilder: YRequestBuilder<YResponse<YPins>, object>
    {
        public YGetPinsBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
    }
}