using Yandex.Music.Api.Models.Album;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для альбома
    /// </summary>
    public static partial class YAlbumExtensions
    {
        public static YAlbum WithTracks(this YAlbum album)
        {
            return WithTracksAsync(album).GetAwaiter().GetResult();
        }

        public static string AddLike(this YAlbum album)
        {
            return AddLikeAsync(album).GetAwaiter().GetResult();
        }

        public static string RemoveLike(this YAlbum album)
        {
            return RemoveLikeAsync(album).GetAwaiter().GetResult();
        }
    }
}
