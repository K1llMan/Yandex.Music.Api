using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Api.Requests.Radio
{
    internal class YGetStationTracksRequest : YRequest<YResponse<YStationSequence>>
    {
        public YGetStationTracksRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YStationSequence>> Create(YStationDescription station, string prevTrackId = "")
        {
            Dictionary<string, string> query = new()
            {
                { "settings2", "true" }
            };

            if (!string.IsNullOrEmpty(prevTrackId))
                query.Add("queue", prevTrackId);

            FormRequest($"{YEndpoints.API}/rotor/station/{station.Id.Type}:{station.Id.Tag}/tracks", query: query);

            return this;
        }
    }
}