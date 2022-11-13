using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Album
{
    [YApiRequest(WebRequestMethods.Http.Post, "albums")]
    public class YGetAlbumsBuilder : YRequestBuilder<YResponse<List<YAlbum>>, IEnumerable<string>>
    {
        public YGetAlbumsBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(IEnumerable<string> albumIds)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "album-ids", string.Join(",", albumIds) }
            });
        }
    }
}