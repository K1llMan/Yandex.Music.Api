using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для исполнителя
    /// </summary>
    public static class YArtistExtensions
    {
        public static YArtistBriefInfo BriefInfo(this YArtist artist)
        {
            return artist.Context.API.Artist.Get(artist.Context.Storage, artist.Id).Result;
        }

        public static string AddLike(this YArtist artist)
        {
            return artist.Context.API.Library.AddArtistLike(artist.Context.Storage, artist).Result;
        }

        public static string RemoveLike(this YArtist artist)
        {
            return artist.Context.API.Library.RemoveArtistLike(artist.Context.Storage, artist).Result;
        }
    }
}
