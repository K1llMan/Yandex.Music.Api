using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Artist
{
    [YApiRequest(WebRequestMethods.Http.Get, "artists/{artistId}/brief-info")]
    public class YGetArtistBuilder: YRequestBuilder<YResponse<YArtistBriefInfo>, string>
    {
        public YGetArtistBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(string artistId)
        {
            return new Dictionary<string, string> {
                { "artistId", artistId }
            };
        }
    }
}