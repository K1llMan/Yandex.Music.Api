using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Landing.Entity;

namespace Yandex.Music.Api.Models.Landing
{
    public class YLandingBlock
    {
        public string Id { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string BackgroundVideoUrl { get; set; }
        public YLandingBlockData Data { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(YLandingEntityConverter))]
        public List<YLandingEntity> Entities { get; set; }
        public YLandingBlockPlayContext PlayContext { get; set; }
        public string Title { get; set; }
        public YLandingBlockType Type { get; set; }
        public string TypeForFrom { get; set; }
    }
}