using System.Threading.Tasks;

using Yandex.Music.Api.Models.Album;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для альбома
    /// </summary>
    public static partial class YAlbumExtensions
    {
        public static async Task<YAlbum> WithTracksAsync(this YAlbum album)
        {
            return album.Volumes != null 
                ? album
                : (await album.Context.API.Album.GetAsync(album.Context.Storage, album.Id))
                    .Result;
        }

        public static async Task<string> AddLikeAsync(this YAlbum album)
        {
            return (await album.Context.API.Library.AddAlbumLikeAsync(album.Context.Storage, album))
                .Result;
        }

        public static async Task<string> RemoveLikeAsync(this YAlbum album)
        {
            return (await album.Context.API.Library.RemoveAlbumLikeAsync(album.Context.Storage, album))
                .Result;
        }
    }
}
