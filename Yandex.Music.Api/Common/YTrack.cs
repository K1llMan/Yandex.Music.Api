using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Common
{
    public class YTrack
    {
        public string Id { get; set; }
        public string RealId { get; set; }
        public string Title { get; set; }
        public YMajor Major { get; set; }
        public bool? Available { get; set; }
        public bool? AvailableForPremiumUsers { get; set; }
        public bool? AvailableFulWithoutPermission { get; set; }
        public long? DurationMs { get; set; }
        public string StorageDir { get; set; }
        public long? FileSize { get; set; }
        public YTrackNormalization Normalization { get; set; }
        private long? PreviewDurationMs { get; set; }
        public List<YArtist> Artists { get; set; }
        public List<YAlbum> Albums { get; set; }
        public string CoverUri { get; set; }
        public string OgImage { get; set; }
        public bool? LyricsAvailable { get; set; }
        public string Type { get; set; }
        public bool? RememberPosition { get; set; }
        public bool? EmbedPlayback { get; set; }
        public string Prefix { get; set; }

        internal static YTrack FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            var id = json.SelectToken("id")?.ToObject<string>();
            var realId = json.SelectToken("realId")?.ToObject<string>();
            var title = json.SelectToken("title")?.ToObject<string>();
            var major = YMajor.FromJson(json.SelectToken("major"));
            var available = json.SelectToken("available")?.ToObject<bool>();
            var availableForPremiumUsers = json.SelectToken("availableForPremiumUsers")?.ToObject<bool>();
            var availableFulWithoutPermission = json.SelectToken("availableFullWithoutPermission")?.ToObject<bool>();
            var durationMs = json.SelectToken("durationMs")?.ToObject<long>();
            var storageDir = json.SelectToken("storageDir")?.ToObject<string>();
            var fileSize = json.SelectToken("fileSize")?.ToObject<long>();
            var normalization = YTrackNormalization.FromJson(json.SelectToken("normalization"));
            var previewDurationMs = json.SelectToken("previewDurationMs")?.ToObject<long>();
            var artists = json.SelectToken("artists")?.Select(YArtist.FromJson).ToList();
            var albums = json.SelectToken("albums")?.Select(YAlbum.FromJson).ToList();
            var coverUri = json.SelectToken("coverUri")?.ToObject<string>();
            var ogImage = json.SelectToken("ogImage")?.ToObject<string>();
            var lyricsAvailable = json.SelectToken("lyricsAvailable")?.ToObject<bool>();
            var type = json.SelectToken("type")?.ToObject<string>();
            var rememberPosition = json.SelectToken("rememberPosition")?.ToObject<bool>();
            var embedPlayback = json.SelectToken("embedPlayback")?.ToObject<bool>();
            var prefix = json.SelectToken("prefix")?.ToObject<string>();

            return new YTrack
            {
                Id = id,
                RealId = realId,
                Title = title,
                Major = major,
                Available = available,
                AvailableForPremiumUsers = availableForPremiumUsers,
                AvailableFulWithoutPermission = availableFulWithoutPermission,
                DurationMs = durationMs,
                StorageDir = storageDir,
                FileSize = fileSize,
                Normalization = normalization,
                PreviewDurationMs = previewDurationMs,
                Artists = artists,
                Albums = albums,
                CoverUri = coverUri,
                OgImage = ogImage,
                LyricsAvailable = lyricsAvailable,
                Type = type,
                RememberPosition = rememberPosition,
                EmbedPlayback = embedPlayback,
                Prefix = prefix
            };
        }
    }
}
