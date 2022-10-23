using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Library;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Library
{
    [YApiRequest(WebRequestMethods.Http.Get, "users/{uid}/{type}/{section}")]
    public class YGetLibrarySectionBuilder<T>: YRequestBuilder<YResponse<T>, (YLibrarySection section, YLibrarySectionType type)>
    {
        public YGetLibrarySectionBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((YLibrarySection section, YLibrarySectionType type) tuple)
        {
            return new Dictionary<string, string> {
                { "uid", storage.User.Uid },
                { "type", tuple.type.ToString().ToLower() },
                { "section", tuple.section.ToString().ToLower() },
            };
        }
    }
}