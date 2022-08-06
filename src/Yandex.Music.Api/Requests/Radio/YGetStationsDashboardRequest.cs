using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Api.Requests.Radio
{
    internal class YGetStationsDashboardRequest : YRequest<YResponse<YStationsDashboard>>
    {
        public YGetStationsDashboardRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YStationsDashboard>> Create()
        {
            FormRequest($"{YEndpoints.API}/rotor/stations/dashboard");

            return this;
        }
    }
}