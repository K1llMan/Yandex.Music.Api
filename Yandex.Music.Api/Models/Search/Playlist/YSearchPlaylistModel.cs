using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Search.Playlist
{
    public class YSearchPlaylistModel
    {
        #region Свойства

        public YCover Cover { get; set; }
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public string Kind { get; set; }
        public long? LikesCount { get; set; }
        public YOwner Owner { get; set; }
        public int? Revision { get; set; }
        public List<YTag> Tags { get; set; }
        public string Title { get; set; }
        public int? TrackCount { get; set; }

        #endregion
    }
}