using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Radio
{
    [YApiRequest(WebRequestMethods.Http.Post, "rotor/station/{type}:{tag}/feedback")]
    public class YSetStationFeedbackBuilder : YRequestBuilder<string, (YStationFeedbackType type, YStation station, YTrack track, string batchId, double totalPlayedSeconds)>
    {
        public YSetStationFeedbackBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((YStationFeedbackType type, YStation station, YTrack track, string batchId, double totalPlayedSeconds) tuple)
        {
            return new Dictionary<string, string>
            {
                { "type", tuple.station.Station.Id.Type },
                { "tag", tuple.station.Station.Id.Tag }
            };
        }

        protected override HttpContent GetContent((YStationFeedbackType type, YStation station, YTrack track, string batchId, double totalPlayedSeconds) tuple)
        {
            var timestamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

            JsonSerializerOptions settings = new()
            {
                Converters = {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                },
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            YStationFeedback feedBack = new YStationFeedback
            {
                Type = tuple.type,
                From = tuple.station.Station.IdForFrom,
                Timestamp = timestamp
            };

            if (tuple.track != null)
                feedBack.TrackId = tuple.track.Id;

            if (tuple.totalPlayedSeconds > 0)
                feedBack.TotalPlayedSeconds = tuple.totalPlayedSeconds;

            return JsonContent.Create(feedBack, new MediaTypeHeaderValue("application/json"), settings); ;
        }

        protected override NameValueCollection GetQueryParams((YStationFeedbackType type, YStation station, YTrack track, string batchId, double totalPlayedSeconds) tuple)
        {
            NameValueCollection query = new NameValueCollection();

            if (!string.IsNullOrWhiteSpace(tuple.batchId))
                query.Add("batch-id", tuple.batchId);

            return query;
        }
    }
}