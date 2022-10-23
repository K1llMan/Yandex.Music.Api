using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Radio
{
    [YApiRequest(WebRequestMethods.Http.Get, "rotor/stations/list")]
    public class YGetStationsBuilder : YRequestBuilder<YResponse<List<YStation>>, object>
    {
        public YGetStationsBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
    }
}