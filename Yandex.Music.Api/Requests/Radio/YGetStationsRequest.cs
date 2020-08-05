using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetStationsRequest : YRequest
    {
        public YGetStationsRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create()
        {
            FormRequest($"{YEndpoints.API}/rotor/stations/list");

            return this;
        }
    }
}