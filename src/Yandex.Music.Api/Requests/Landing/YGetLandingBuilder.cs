using System.Collections.Specialized;
using System.Linq;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Landing
{
    [YApiRequest(WebRequestMethods.Http.Get, "landing3")]
    public class YGetLandingBuilder: YRequestBuilder<YResponse<YLanding>, YLandingBlockType[]>
    {
        public YGetLandingBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams(YLandingBlockType[] tuple)
        {
            string blocks = string.Join(",", tuple
                .Select(b => SerializeJson(b).Replace("\"", string.Empty)));

            return new NameValueCollection {
                { "blocks", blocks }
            };
        }
    }
}