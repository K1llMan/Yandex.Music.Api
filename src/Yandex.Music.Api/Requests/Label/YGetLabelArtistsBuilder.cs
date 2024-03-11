using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Label
{
    [YApiRequest(WebRequestMethods.Http.Get, "labels/{labelId}/artists")]
    public class YGetLabelArtistsBuilder : YRequestBuilder<YResponse<List<YArtist>>, (YLabel label, int pageNumber)>
    {
        public YGetLabelArtistsBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams((YLabel label, int pageNumber) tuple)
        {
            return new NameValueCollection
            {
                { "page", tuple.pageNumber.ToString() }
            };
        }

        protected override Dictionary<string, string> GetSubstitutions((YLabel label, int pageNumber) tuple)
        {
            return new Dictionary<string, string>
            {
                { "labelId", tuple.label.Id }
            };
        }
    }
}
