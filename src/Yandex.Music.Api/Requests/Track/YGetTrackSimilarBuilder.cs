using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Track
{
    [YApiRequest(WebRequestMethods.Http.Get, "tracks/{trackId}/similar")]
    public class YGetTrackSimilarBuilder : YRequestBuilder<YResponse<YTrackSimilar>, string>
    {
        public YGetTrackSimilarBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions(string trackId)
        {
            return new Dictionary<string, string> {
                { "trackId", trackId }
            };
        }
    }
}