using System.Threading.Tasks;

using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Extensions.API
{
    /// <summary>
    /// Методы-расширения для плейлиста
    /// </summary>
    public static partial class YPlaylistExtensions
    {
        public static async Task<YPlaylist> WithTracksAsync(this YPlaylist playlist)
        {
            return playlist.Tracks != null 
                ? playlist
                : (await playlist.Context.API.Playlist.GetAsync(playlist.Context.Storage, playlist))
                    .Result;
        }

        public static async Task<string> AddLikeAsync(this YPlaylist playlist)
        {
            return (await playlist.Context.API.Library.AddPlaylistLikeAsync(playlist.Context.Storage, playlist))
                .Result;
        }

        public static async Task<string> RemoveLikeAsync(this YPlaylist playlist)
        {
            return (await playlist.Context.API.Library.RemovePlaylistLikeAsync(playlist.Context.Storage, playlist))
                .Result;
        }

        public static async Task<YPlaylist> RenameAsync(this YPlaylist playlist, string newName)
        {
            return CheckUser(playlist)
                ? (await playlist.Context.API.Playlist.RenameAsync(playlist.Context.Storage, playlist, newName))
                    .Result
                : playlist;
        }

        public static async Task<bool> DeleteAsync(this YPlaylist playlist)
        {
            return CheckUser(playlist) && await playlist.Context.API.Playlist.DeleteAsync(playlist.Context.Storage, playlist);
        }

        public static async Task<YPlaylist> InsertTracksAsync(this YPlaylist playlist, params YTrack[] tracks)
        {
            return CheckUser(playlist)
                ? (await playlist.Context.API.Playlist.InsertTracksAsync(playlist.Context.Storage, playlist, tracks))
                    .Result
                : playlist;
        }

        public static async Task<YPlaylist> RemoveTracksAsync(this YPlaylist playlist, params YTrack[] tracks)
        {
            return CheckUser(playlist)
                ? (await playlist.Context.API.Playlist.DeleteTracksAsync(playlist.Context.Storage, playlist, tracks))
                    .Result
                : playlist;
        }

        public static async Task<bool> UploadTracksAsync(this YPlaylist playlist, string filePath, string fileName)
        {
            if (!CheckUser(playlist))
                return false;

            string target = (await playlist.Context.API.UserGeneratedContent.GetUgcUploadLinkAsync(playlist.Context.Storage, playlist, fileName))
                .PostTarget;

            return (await playlist.Context.API.UserGeneratedContent.UploadUgcTrackAsync(playlist.Context.Storage, target, filePath))
                .Result == "CREATED";
        }
    }
}
