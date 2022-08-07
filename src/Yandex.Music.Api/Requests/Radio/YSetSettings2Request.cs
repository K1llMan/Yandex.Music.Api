using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Api.Requests.Radio
{
    internal class YSetSettings2Request : YRequest<YResponse<string>>
    {
        #region Поля

        private JsonSerializerSettings settings = new()
        {
            Converters = new List<JsonConverter> {
                new StringEnumConverter {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            },
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        #endregion Поля

        public YSetSettings2Request(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<string>> Create(YStationDescription station, YStationSettings2 settings2)
        {
            List<KeyValuePair<string, string>> headers = new()
            {
                YRequestHeaders.Get(YHeader.ContentType, storage)
            };

            string body = JsonConvert.SerializeObject(settings2, settings);

            FormRequest($"{YEndpoints.API}/rotor/station/{station.Id.Type}:{station.Id.Tag}/settings2", WebRequestMethods.Http.Post, 
                headers: headers, body: body);

            return this;
        }
    }
}