using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Album
{
    public class YAlbum : YBaseModel
    {
        public YButton ActionButton { get; set; }
        public List<YArtist> Artists { get; set; }
        public bool Available { get; set; }
        public bool AvailableForMobile { get; set; }
        public bool AvailableForPremiumUsers { get; set; }
        public bool AvailablePartially { get; set; }
        public List<string> Bests { get; set; }
        public List<string> Buy { get; set; }
        public bool ChildContent { get; set; }
        public string ContentWarning { get; set; }
        public string CoverUri { get; set; }
        public List<YAlbum> Duplicates { get; set; }
        public string Genre { get; set; }
        public string Id { get; set; }
        public List<YLabel> Labels { get; set; }
        public int LikesCount { get; set; }
        public string MetaType { get; set; }
        public string OgImage { get; set; }
        public YPager Pager { get; set; }
        public List<YPrerolls> Prerolls { get; set; }
        public bool Recent { get; set; }
        public string ReleaseDate { get; set; }
        public YSortOrder SortOrder { get; set; }
        public string Title { get; set; }
        public int TrackCount { get; set; }
        public YTrackPosition TrackPosition { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public bool VeryImportant { get; set; }
        public List<List<YTrack>> Volumes { get; set; }
        public int Year { get; set; }
    }
}