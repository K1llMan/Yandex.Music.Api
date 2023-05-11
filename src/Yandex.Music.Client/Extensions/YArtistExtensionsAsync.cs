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
        public static Task<YArtistBriefInfo> BriefInfoAsync(this YArtist artist)
        {
            return artist.Context.API.Artist.GetAsync(artist.Context.Storage, artist.Id)
                .ContinueWith(t => t.Result.Result);
        }

        public static Task<YTracksPage> GetTracksAsync(this YArtist artist, int page = 0, int pageSize = 20)
        {
            return artist.Context.API.Artist.GetTracksAsync(artist.Context.Storage, artist.Id, page, pageSize)
                .ContinueWith(t => t.Result.Result);
        }

        public static Task<List<YTrack>> GetAllTracksAsync(this YArtist artist)
        {
            return artist.Context.API.Artist.GetAllTracksAsync(artist.Context.Storage, artist.Id)
                .ContinueWith(t => t.Result.Result.Tracks);
        }

        public static Task<string> AddLikeAsync(this YArtist artist)
        {
            return artist.Context.API.Library.AddArtistLikeAsync(artist.Context.Storage, artist)
                .ContinueWith(t => t.Result.Result);
        }

        public static Task<string> RemoveLikeAsync(this YArtist artist)
        {
            return artist.Context.API.Library.RemoveArtistLikeAsync(artist.Context.Storage, artist)
                .ContinueWith(t => t.Result.Result);
        }
    }
}
