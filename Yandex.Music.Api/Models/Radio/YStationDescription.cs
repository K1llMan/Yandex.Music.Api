namespace Yandex.Music.Api.Models.Radio
{
    public class YStationDescription
    {
        public string FullImageUrl { get; set; }
        public YStationIcon GeocellIcon { get; set; }
        public YStationIcon Icon { get; set; }
        public YStationId Id { get; set; }
        public string IdForFrom { get; set; }
        public string MtsFullImageUrl { get; set; }
        public YStationIcon MtsIcon { get; set; }
        public string Name { get; set; }
        public YStationId ParentId { get; set; }
        public YStationRestrictions Restrictions { get; set; }
        public YStationRestrictions2 Restrictions2 { get; set; }
    }
}