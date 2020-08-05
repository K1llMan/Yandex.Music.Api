using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetStationRequest : YRequest
    {
        public YGetStationRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string type, string tag)
        {
            FormRequest($"{YEndpoints.API}/rotor/station/{type}:{tag}/info");

            return this;
        }
    }
}