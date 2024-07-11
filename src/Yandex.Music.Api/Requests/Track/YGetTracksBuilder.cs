﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Track
{
    [YApiRequest(WebRequestMethods.Http.Post, "tracks")]
    public class YGetTracksBuilder : YRequestBuilder<YResponse<List<YTrack>>, IEnumerable<string>>
    {
        public YGetTracksBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(IEnumerable<string> trackIds)
        {
            Dictionary<string, string> formData = new()
            {
                { "track-ids", string.Join(",", trackIds) },
                { "with-positions", "true" }
            };

            return new FormUrlEncodedContent(formData);
        }
    }
}
