using System;
using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Search.Artist;

namespace Yandex.Music.Api.Models.Search.PodcastEpisode
{
    public class YSearchPodcastEpisodeModel
    {
        public List<YSearchAlbumModel> Albums { get; set; }
        public List<YSearchArtist> Artists { get; set; }
        public bool Available { get; set; }
        public bool AvailableAsRbt { get; set; }
        public bool AvailableForPremiumUsers { get; set; }
        public string CoverUri { get; set; }
        public long DurationMs { get; set; }
        public bool Explicit { get; set; }
        public bool LyricsAvailable { get; set; }
        public YLyricsInfo LyricsInfo { get; set; }
        public bool RememberPosition { get; set; }
        public string ShortDescription { get; set; }
        public YPodcastEpisodeType PodcastEpisodeType { get; set; }
        public DateTime PubDate { get; set; }
        public List<string> Regions { get; set; }
        public string Id { get; set; }
        public YTrackSharingFlag TrackSharingFlag { get; set; }
        public YTrackSource TrackSource { get; set; }
        public string Title { get; set; }
        public YSearchPodcastEpisodeType Type { get; set; }
    }
}