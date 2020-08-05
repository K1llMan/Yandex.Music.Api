using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetStationTracksRequest : YRequest
    {
        public YGetStationTracksRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(YStationDescription station, string prevTrackId = "")
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "settings2", "true" }
            };

            if (!string.IsNullOrEmpty(prevTrackId))
                query.Add("queue", prevTrackId);

            FormRequest($"{YEndpoints.API}/rotor/station/{station.Id.Type}:{station.Id.Tag}/tracks", query: query);

            return this;
        }
    }
}