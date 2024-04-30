using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Landing
{
    [YApiRequest(WebRequestMethods.Http.Get, "children-landing/catalogue")]
    public class YGetChildrenLandingBuilder : YRequestBuilder<YResponse<YChildrenLanding>, object>
    {
        public YGetChildrenLandingBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
    }
}