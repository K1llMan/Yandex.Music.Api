using System;

namespace Yandex.Music.Api.Models.Landing.Entity.Entities
{
    public class YLandingEntityPodcast: YLandingEntity
    {
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public DateTime LastUpdated { get; set; }
        public YPodcast Data { get; set; }
    }
}