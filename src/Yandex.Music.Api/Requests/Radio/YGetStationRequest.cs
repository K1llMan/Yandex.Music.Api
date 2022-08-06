using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Api.Requests.Radio
{
    internal class YGetStationRequest : YRequest<YResponse<List<YStation>>>
    {
        public YGetStationRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<List<YStation>>> Create(string type, string tag)
        {
            FormRequest($"{YEndpoints.API}/rotor/station/{type}:{tag}/info");

            return this;
        }
    }
}