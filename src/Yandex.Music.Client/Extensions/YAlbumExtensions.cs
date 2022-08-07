using Yandex.Music.Api.Models.Album;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для альбома
    /// </summary>
    public static class YAlbumExtensions
    {
        public static string AddLike(this YAlbum album)
        {
            return album.Context.API.Library.AddAlbumLike(album.Context.Storage, album).Result;
        }

        public static string RemoveLike(this YAlbum album)
        {
            return album.Context.API.Library.RemoveAlbumLike(album.Context.Storage, album).Result;
        }
    }
}
