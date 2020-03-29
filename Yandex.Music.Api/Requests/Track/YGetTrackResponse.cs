using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetTrackResponse : YRequest
    {
        public YGetTrackResponse(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string trackId)
        {
            FormRequest($"{YEndpoints.API}/tracks/{trackId}");

            return this;
        }
    }
}