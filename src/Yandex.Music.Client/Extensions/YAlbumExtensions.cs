using System.Collections.Generic;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Track;

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

        public static YAlbum WithTracks(this YAlbum album)
        {
            if (album.Volumes != null)
                return album;

            List<List<YTrack>> volumes = album.Context.API.Album.Get(album.Context.Storage, album.Id)
                .Result
                .Volumes;

            album.Volumes = volumes;

            return album;
        }
    }
}
