using System;
using System.Collections.Generic;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedPromotion
    {
        public string PromoId { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        public string ImagePosition { get; set; }
        public YFeedEventPromotionType PromotionType { get; set; }
        public DateTime StartDate { get; set; }
        public string SubTitle { get; set; }
        public string SubtitleUrl { get; set; }
        public string Title { get; set; }
        public string TitleUrl { get; set; }
        public List<YTag> Tags { get; set; }

        public List<YAlbum> Albums { get; set; }
        public List<YTrack> Tracks { get; set; }
    }
}