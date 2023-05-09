using System.Threading.Tasks;

using Yandex.Music.Api.Models.Album;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для альбома
    /// </summary>
    public static partial class YAlbumExtensions
    {
        public static Task<YAlbum> WithTracksAsync(this YAlbum album)
        {
            return album.Volumes != null 
                ? Task.FromResult(album)
                : album.Context.API.Album.GetAsync(album.Context.Storage, album.Id)
                    .ContinueWith(t => t.Result.Result);
        }

        public static Task<string> AddLikeAsync(this YAlbum album)
        {
            return album.Context.API.Library.AddAlbumLikeAsync(album.Context.Storage, album)
                .ContinueWith(t => t.Result.Result);
        }

        public static Task<string> RemoveLikeAsync(this YAlbum album)
        {
            return album.Context.API.Library.RemoveAlbumLikeAsync(album.Context.Storage, album)
                .ContinueWith(t => t.Result.Result);
        }
    }
}
