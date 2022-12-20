using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Radio
{
    [YApiRequest(WebRequestMethods.Http.Post, "rotor/station/{type}:{tag}/feedback")]
    public class YSetStationFeedbackBuilder : YRequestBuilder<string, (YStationFeedback type, YStationSequence sequence, YTrack track, string from, int totalPlayedSeconds)>
    {
        public YSetStationFeedbackBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((YStationFeedback type, YStationSequence sequence, YTrack track, string from, int totalPlayedSeconds) tuple)
        {
            return new Dictionary<string, string> {
                { "type", tuple.sequence.Id.Type },
                { "tag", tuple.sequence.Id.Tag }
            };
        }

        protected override HttpContent GetContent((YStationFeedback type, YStationSequence sequence, YTrack track, string from, int totalPlayedSeconds) tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "type", tuple.type.ToString() },
                { "timestamp", DateTime.Now.ToString() },
                { "batch-id", tuple.sequence.BatchId },
                { "trackId", tuple.track.GetKey().ToString() },
                { "from", tuple.from },
                { "totalPlayedSeconds", tuple.totalPlayedSeconds.ToString() }
            });
        }
    }
}