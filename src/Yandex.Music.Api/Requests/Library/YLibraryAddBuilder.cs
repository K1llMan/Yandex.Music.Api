using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Library;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Library
{
    [YApiRequest(WebRequestMethods.Http.Post, "users/{uid}/{type}/{section}/add-multiple")]
    public class YLibraryAddBuilder<T>: YRequestBuilder<YResponse<T>, (string id, YLibrarySection section, YLibrarySectionType type)>
    {
        public YLibraryAddBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((string id, YLibrarySection section, YLibrarySectionType type) tuple)
        {
            return new Dictionary<string, string> {
                { "uid", storage.User.Uid },
                { "type", tuple.type.ToString().ToLower() },
                { "section", tuple.section.ToString().ToLower() },
            };
        }

        protected override HttpContent GetContent((string id, YLibrarySection section, YLibrarySectionType type) tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { $"{tuple.section.ToString().ToLower().TrimEnd('s')}-ids", tuple.id }
            });
        }
    }
}