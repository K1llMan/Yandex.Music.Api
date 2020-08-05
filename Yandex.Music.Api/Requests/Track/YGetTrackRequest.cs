using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetTrackRequest : YRequest
    {
        public YGetTrackRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string trackId)
        {
            FormRequest($"{YEndpoints.API}/tracks/{trackId}");

            return this;
        }
    }
}