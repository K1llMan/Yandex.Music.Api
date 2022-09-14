using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Search.Track;

namespace Yandex.Music.Api.Models.Search.Artist
{
    public class YSearchArtistModel: YArtist
    {
        public List<YSearchTrackModel> PopularTracks { get; set; }
        public List<string> Regions { get; set; }
    }
}