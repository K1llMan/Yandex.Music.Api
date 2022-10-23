using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Radio
{
    [YApiRequest(WebRequestMethods.Http.Get, "rotor/station/{type}:{tag}/info")]
    public class YGetStationBuilder : YRequestBuilder<YResponse<List<YStation>>, (string type, string tag)>
    {
        public YGetStationBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((string type, string tag) tuple)
        {
            return new Dictionary<string, string> {
                { "type", tuple.type },
                { "tag", tuple.tag }
            };
        }
    }
}