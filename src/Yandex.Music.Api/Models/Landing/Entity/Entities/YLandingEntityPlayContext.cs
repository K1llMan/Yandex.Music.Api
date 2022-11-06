using Newtonsoft.Json;

using Yandex.Music.Api.Models.Landing.Entity.Entities.Context;

namespace Yandex.Music.Api.Models.Landing.Entity.Entities
{
    public class YLandingEntityPlayContext: YLandingEntity
    {
        [JsonConverter(typeof(YPlayContextConverter))]
        public YPlayContext Data { get; set; }
    }
}