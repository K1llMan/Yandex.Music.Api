using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Landing.Entity.Entities.Context;
using Yandex.Music.Api.Models.Library;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Library
{
    [YApiRequest(WebRequestMethods.Http.Get, "/users/{uid}/contexts")]
    public class YGetLibraryRecentlyListenedBuilder : YRequestBuilder<YResponse<YRecentlyListenedContext>,
        (IEnumerable<YPlayContextType> contextTypes, int trackCount, int contextCount)>
    {
        public YGetLibraryRecentlyListenedBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams((IEnumerable<YPlayContextType> contextTypes, int trackCount, int contextCount ) tuple)
        {
            return new NameValueCollection {
                { "trackCount", tuple.trackCount.ToString() },
                { "contextCount", tuple.contextCount.ToString() },
                { "types", string.Join(",", tuple.contextTypes.Select(x => x.ToString().ToLowerInvariant())) }
            };
        }

        protected override Dictionary<string, string> GetSubstitutions((IEnumerable<YPlayContextType> contextTypes, int trackCount, int contextCount ) tuple)
        {
            return new Dictionary<string, string> {
                { "uid", storage.User.Uid }
            };
        }
    }
}