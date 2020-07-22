using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Search.Video
{
    public class YSearchVideoModel
    {
        #region Свойства

        public int Duration { get; set; }
        public string HtmlAutoPlayVideoPlayer { get; set; }
        public List<string> Regions { get; set; }
        public string Text { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string YoutubeUrl { get; set; }

        #endregion
    }
}