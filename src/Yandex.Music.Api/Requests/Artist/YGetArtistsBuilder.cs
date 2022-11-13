using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Artist
{
    [YApiRequest(WebRequestMethods.Http.Post, "artists")]
    public class YGetArtistsBuilder : YRequestBuilder<YResponse<List<YArtist>>, IEnumerable<string>>
    {
        public YGetArtistsBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(IEnumerable<string> artistIds)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "artist-Ids", string.Join(",", artistIds) }
            });
        }
    }
}