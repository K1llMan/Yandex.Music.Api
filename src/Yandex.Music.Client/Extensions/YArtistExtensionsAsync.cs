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
        public static async Task<YArtistBriefInfo> BriefInfoAsync(this YArtist artist)
        {
            return (await artist.Context.API.Artist.GetAsync(artist.Context.Storage, artist.Id))
                .Result;
        }

        public static async Task<YTracksPage> GetTracksAsync(this YArtist artist, int page = 0, int pageSize = 20)
        {
            return (await artist.Context.API.Artist.GetTracksAsync(artist.Context.Storage, artist.Id, page, pageSize))
                .Result;
        }

        public static async Task<List<YTrack>> GetAllTracksAsync(this YArtist artist)
        {
            return (await artist.Context.API.Artist.GetAllTracksAsync(artist.Context.Storage, artist.Id))
                .Result.Tracks;
        }

        public static async Task<string> AddLikeAsync(this YArtist artist)
        {
            return (await artist.Context.API.Library.AddArtistLikeAsync(artist.Context.Storage, artist))
                .Result;
        }

        public static async Task<string> RemoveLikeAsync(this YArtist artist)
        {
            return (await artist.Context.API.Library.RemoveArtistLikeAsync(artist.Context.Storage, artist))
                .Result;
        }
    }
}
