using System.Collections.Generic;
using System.Linq;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Responses
{
    public class YTrackResponse
    {
        public string Id { get; set; }
        public List<YAlbumResponse> Albums { get; set; }
        public string RealId { get; set; }
        public string Title { get; set; }
        public YMajor Major { get; set; }
        public bool? Available { get; set; }
        public bool? AvailableForPremiumUsers { get; set; }
        public int? DurationMS { get; set; }
        public string StorageDir { get; set; }
        public int? FileSize { get; set; }
        public List<YArtistResponse> Artists { get; set; }
        public string OgImage { get; set; }


        public string GetKey()
        {
            return $"{Id}:{Albums.FirstOrDefault().Id}";
        }
    }
}