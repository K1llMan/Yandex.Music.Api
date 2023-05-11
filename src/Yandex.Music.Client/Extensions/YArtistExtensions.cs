using System.Collections.Generic;
using System.Threading.Tasks;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для исполнителя
    /// </summary>
    public static partial class YArtistExtensions
    {
        public static YArtistBriefInfo BriefInfo(this YArtist artist)
        {
            return BriefInfoAsync(artist).GetAwaiter().GetResult();
        }

        public static YTracksPage GetTracks(this YArtist artist, int page = 0, int pageSize = 20)
        {
            return GetTracksAsync(artist, page, pageSize).GetAwaiter().GetResult();
        }

        public static List<YTrack> GetAllTracks(this YArtist artist)
        {
            return GetAllTracksAsync(artist).GetAwaiter().GetResult();
        }

        public static string AddLike(this YArtist artist)
        {
            return AddLikeAsync(artist).GetAwaiter().GetResult();
        }

        public static string RemoveLike(this YArtist artist)
        {
            return RemoveLikeAsync(artist).GetAwaiter().GetResult();
        }
    }
}
