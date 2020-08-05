using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetStationsDashboardRequest : YRequest
    {
        public YGetStationsDashboardRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create()
        {
            FormRequest($"{YEndpoints.API}/rotor/stations/dashboard");

            return this;
        }
    }
}