using Newtonsoft.Json;

using Yandex.Music.Api.Models.Radio.Restriction;

namespace Yandex.Music.Api.Models.Radio
{
    public class YStationRestrictions2
    {
        [JsonConverter(typeof(YRestrictionConverter))]
        public YRestriction Diversity { get; set; }

        [JsonConverter(typeof(YRestrictionConverter))]
        public YRestriction Language { get; set; }

        [JsonConverter(typeof(YRestrictionConverter))]
        public YRestriction MoodEnergy { get; set; }
    }
}