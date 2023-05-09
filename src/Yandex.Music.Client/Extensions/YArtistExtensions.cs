using Yandex.Music.Api.Models.Artist;

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
