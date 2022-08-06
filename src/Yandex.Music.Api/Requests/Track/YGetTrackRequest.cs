using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetTrackRequest : YRequest<YResponse<List<YTrack>>>
    {
        public YGetTrackRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<List<YTrack>>> Create(string trackId)
        {
            FormRequest($"{YEndpoints.API}/tracks/{trackId}");

            return this;
        }
    }
}