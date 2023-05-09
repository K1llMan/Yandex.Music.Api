using System.Threading.Tasks;

using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для плейлиста
    /// </summary>
    public static partial class YPlaylistExtensions
    {
        public static Task<YPlaylist> WithTracksAsync(this YPlaylist playlist)
        {
            return playlist.Tracks != null 
                ? Task.FromResult(playlist)
                : playlist.Context.API.Playlist.GetAsync(playlist.Context.Storage, playlist)
                    .ContinueWith(t => t.Result.Result);
        }

        public static Task<string> AddLikeAsync(this YPlaylist playlist)
        {
            return playlist.Context.API.Library.AddPlaylistLikeAsync(playlist.Context.Storage, playlist)
                .ContinueWith(t => t.Result.Result);
        }

        public static Task<string> RemoveLikeAsync(this YPlaylist playlist)
        {
            return playlist.Context.API.Library.RemovePlaylistLikeAsync(playlist.Context.Storage, playlist)
                .ContinueWith(t => t.Result.Result);
        }

        public static Task<YPlaylist> RenameAsync(this YPlaylist playlist, string newName)
        {
            return CheckUser(playlist)
                ? playlist.Context.API.Playlist.RenameAsync(playlist.Context.Storage, playlist, newName)
                    .ContinueWith(t => t.Result.Result)
                : Task.FromResult(playlist);
        }

        public static Task<bool> DeleteAsync(this YPlaylist playlist)
        {
            return CheckUser(playlist) 
                ? playlist.Context.API.Playlist.DeleteAsync(playlist.Context.Storage, playlist)
                : Task.FromResult(false);
        }

        public static Task<YPlaylist> InsertTracksAsync(this YPlaylist playlist, params YTrack[] tracks)
        {
            return CheckUser(playlist)
                ? playlist.Context.API.Playlist.InsertTracksAsync(playlist.Context.Storage, playlist, tracks)
                    .ContinueWith(t => t.Result.Result)
                : Task.FromResult(playlist);
        }

        public static Task<YPlaylist> RemoveTracksAsync(this YPlaylist playlist, params YTrack[] tracks)
        {
            return CheckUser(playlist)
                ? playlist.Context.API.Playlist.DeleteTracksAsync(playlist.Context.Storage, playlist, tracks)
                    .ContinueWith(t => t.Result.Result)
                : Task.FromResult(playlist);
        }
    }
}
