using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Track
{
    [YApiRequest(WebRequestMethods.Http.Post, "play-audio")]
    public class YSendTrackInfoBuilder : YRequestBuilder<string, (YTrack track, string from, bool fromcache, string playId, string playlistId, double totalPlayedSeconds, double endPositionSeconds)>
    {
        public YSendTrackInfoBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent((YTrack track, string from, bool fromcache, string playId, string playlistId, double totalPlayedSeconds, double endPositionSeconds) tuple)
        {
            Dictionary<string, string> formData = new Dictionary<string, string>
            {
                { "track_id", tuple.track.Id },
                { "from-cache", tuple.fromcache.ToString() },
                { "play_id", tuple.playId },
                { "uid", Storage.User.Uid },
                { "timestamp", DateTime.Now.ToString("o", CultureInfo.InvariantCulture) },
                { "client-now", DateTime.Now.ToString("o", CultureInfo.InvariantCulture) },
                { "album-id", tuple.track.Albums.FirstOrDefault()?.Id },
                { "from", tuple.from },
                { "playlist-id", tuple.playlistId },
                { "track-length-seconds", ((double)(tuple.track.DurationMs / 1000)).ToString(CultureInfo.InvariantCulture) },
                { "total-played-seconds", tuple.totalPlayedSeconds.ToString(CultureInfo.InvariantCulture) },
                { "end-position-seconds", tuple.endPositionSeconds.ToString(CultureInfo.InvariantCulture) },
            };

            return new FormUrlEncodedContent(formData);
        }
    }
}