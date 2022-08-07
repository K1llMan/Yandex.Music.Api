using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Library;

namespace Yandex.Music.Api.Requests.Library
{
    internal class YLibraryRemoveRequest <T>: YRequest<YResponse<T>>
    {
        public YLibraryRemoveRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<T>> Create(string id, YLibrarySection section, YLibrarySectionType type = YLibrarySectionType.Likes)
        {
            Dictionary<string, string> body = new()
            {
                { $"{section.ToString().ToLower().TrimEnd('s')}-ids", id }
            };

            List<KeyValuePair<string, string>> headers = new()
            {
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded")
            };

            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/{type.ToString().ToLower()}/{section.ToString().ToLower()}/remove", 
                WebRequestMethods.Http.Post, body: GetQueryString(body), headers: headers);

            return this;
        }
    }
}