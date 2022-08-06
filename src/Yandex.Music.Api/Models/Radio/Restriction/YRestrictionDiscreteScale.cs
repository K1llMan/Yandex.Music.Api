namespace Yandex.Music.Api.Models.Radio.Restriction
{
    public class YRestrictionDiscreteScale : YRestriction
    {
        public YRestrictionValue<int> Min { get; set; }
        public YRestrictionValue<int> Max { get; set; }
    }
}
