using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Common.Cover
{
    public class YCoverMosaic : YCover
    {
        public bool Custom { get; set; }
        public List<string> ItemsUri { get; set; }
    }
}