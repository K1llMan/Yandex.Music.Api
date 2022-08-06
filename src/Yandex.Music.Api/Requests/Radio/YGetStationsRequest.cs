using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Api.Requests.Radio
{
    internal class YGetStationsRequest : YRequest<YResponse<List<YStation>>>
    {
        public YGetStationsRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<List<YStation>>> Create()
        {
            FormRequest($"{YEndpoints.API}/rotor/stations/list");

            return this;
        }
    }
}