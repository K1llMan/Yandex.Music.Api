using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Radio
{
    [YApiRequest(WebRequestMethods.Http.Post, "rotor/station/{type}:{tag}/settings2")]
    public class YSetSettings2Builder: YRequestBuilder<YResponse<string>, (YStationDescription station, YStationSettings2 settings2)>
    {
        public YSetSettings2Builder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override Dictionary<string, string> GetSubstitutions((YStationDescription station, YStationSettings2 settings2) tuple)
        {
            return new Dictionary<string, string> {
                { "type", tuple.station.Id.Type },
                { "tag", tuple.station.Id.Tag },
            };
        }

        protected override HttpContent GetContent((YStationDescription station, YStationSettings2 settings2) tuple)
        {
            JsonSerializerOptions settings = new() {
                Converters = {
                    new JsonStringEnumConverter()
                },
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true
            };

            return JsonContent.Create(tuple.settings2, new MediaTypeHeaderValue("application/json"), settings);
        }
    }
}